using AdminPortal.Helpers;
using AdminPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;

namespace AdminPortal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        #region AspIdentitySetup
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public AdminController()
        {
        }
        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        public ActionResult Company()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.Companies.Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult CompanyUser()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.Users.Include("Company").Where(x => x.Id != "f2d14967-211d-471b-92cf-892161c88e19").OrderByDescending(p => p.DateCreated).ToList();
                return View(list);
            }
        }

        [HttpPost]
        public async Task<int> CompanyUser(UserModel model)
        {
            Company company;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                company = db.Companies.FirstOrDefault(x => x.ID == model.Company_ID);

                bool Duplicate = db.Users.Any(x => x.Id != model.Id && x.Company.ID == model.Company_ID);
                if (Duplicate)
                {
                    return -1;
                }
                ApplicationUser o = db.Users.FirstOrDefault(x => x.Id == model.Id);
                if (o != null)
                {
                    o.Name = model.Name;
                    o.Email = model.Email;
                    o.Address = model.Address;
                    o.Phone = model.Phone;
                    o.Company = db.Companies.FirstOrDefault(x => x.ID == model.Company_ID);

                    if (!String.IsNullOrEmpty(model.Password))
                    {
                        if (UserManager.HasPassword(model.Id))
                        {
                            UserManager.RemovePassword(model.Id);
                            UserManager.AddPassword(model.Id, model.Password);
                        }
                    }
                    db.SaveChanges();
                    return 1;
                }


            }

            Guid obj = Guid.NewGuid();
            string code = obj.ToString();
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name, Address = model.Address, Phone = model.Phone, DateCreated = DateTime.UtcNow, Code = code, Active = true };
            StringBuilder body = new StringBuilder();
            string link = ConfigurationManager.AppSettings["baseUrl"];
            body.AppendFormat("Dear {0},<br> Please click on this <a href='{1}emailverification/index?code={2}'>link</a> to verify your account.", model.Name, link, code);

            var result = await UserManager.CreateAsync(user, model.Password);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser applicationUser = db.Users.FirstOrDefault(x => x.Id == user.Id);
                applicationUser.Company_ID = company.ID;
                db.SaveChanges();
            }
            if (result.Succeeded)
            {
                utility.Email("Vehiqilla Email Verification", model.Email, body.ToString());
            }

            return 1;

        }

        public ActionResult Categories()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.Categories.Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult CyberRiskTypes()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.CyberRiskTypes.Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult Suppliers()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.Suppliers.Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult Oems()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.Oems.Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult Apps()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var list = db.ECUApps.Include("Supplier").Include("Category").Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        [HttpPost]
        public ActionResult Apps(string model, HttpPostedFileBase[] files)
        {
            AppViewModel vm = JsonConvert.DeserializeObject<AppViewModel>(model);
            using (ApplicationDbContext db = new ApplicationDbContext())
            {


                ECUApp o = db.ECUApps.FirstOrDefault(x => x.ID == vm.ID);

                bool Duplicate = db.ECUApps.Any(x => x.ID != vm.ID && (x.Name == vm.Name));
                if (Duplicate)
                {
                    return Json(new { Message = "duplicate" });
                }

                bool newrecord = false;
                if (o == null)
                {
                    o = new ECUApp();
                    newrecord = true;
                }



                if (files[0] != null && files[0].ContentLength > 0)
                {
                    if (o.FilePath != null)
                    {
                        // string s = "~/App_Data" + o.FilePath.Split(new string[] { "App_Data" }, StringSplitOptions.None)[1];
                        try
                        {
                            FileInfo fi2 = new FileInfo(o.FilePath);
                            fi2.Delete();
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    string directory = "~/App_Data/Uploads/AppLogos";
                    bool exists = System.IO.Directory.Exists(Server.MapPath(directory));
                    if (!exists)
                        System.IO.Directory.CreateDirectory(Server.MapPath(directory));
                    var fileName = Path.GetFileName(files[0].FileName);
                    fileName = Guid.NewGuid() + "_" + fileName;
                    var path = Path.Combine(Server.MapPath(directory), fileName);
                    files[0].SaveAs(path);
                    //o.FilePath = "/Uploads/AppLogos/" + fileName;
                    string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
Request.ApplicationPath.TrimEnd('/') + "/";
                    o.FilePath = baseUrl + "App_Data/Uploads/AppLogos/" + fileName;
                }



                o.Name = vm.Name;
                o.Description = vm.Description;
                o.VehicleModel = vm.VehicleModel;
                o.YearManufactured = vm.YearManufactured;
                o.Breaches = vm.Breaches;
                o.Vulnerabilities = vm.Vulnerabilities;
                o.IsActive = vm.IsActive;
                o.Category = db.Categories.FirstOrDefault(x => x.ID == vm.Category_ID);
                o.Supplier = db.Suppliers.FirstOrDefault(x => x.ID == vm.Supplier_ID);
                if (newrecord)
                {
                    db.ECUApps.Add(o);
                }
                int count = db.SaveChanges();
                return Json(new { Message = "success" });
            }

        }
        public ActionResult Breaches(int? ID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.ECUApps.Include("Supplier").Include("Category").Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult Vulnerabilities(int? ID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.ECUApps.Include("Supplier").Include("Category").Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult AppVulnerability(int? ID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ViewBag.Title = db.ECUApps.FirstOrDefault(x => x.ID == ID).Name + " Vulnerabilities";
                var list = db.AppVulnerabilities.Include("ECUApp").Where(x => x.IsDeleted == false && x.ECUApp.ID == ID).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult AppBreach(int? ID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ViewBag.Title = db.ECUApps.FirstOrDefault(x => x.ID == ID).Name + " Breaches";
                var list = db.AppBreachs.Include("ECUApp").Where(x => x.IsDeleted == false && x.ECUApp.ID == ID).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult Notifications()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.Notifications.Include("User").Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult About()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.Contents.Where(x => x.IsDeleted == false && x.Type == "About").OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult KnowledgeCenter()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.KnowledgeCenters.Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult KnowledgeCenter(string model, HttpPostedFileBase[] files)
        {
            KnowledgerCenterViewModel vm = JsonConvert.DeserializeObject<KnowledgerCenterViewModel>(model);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                KnowledgeCenter o = db.KnowledgeCenters.FirstOrDefault(x => x.ID == vm.ID);
                bool newrecord = false;
                if (o == null)
                {
                    o = new KnowledgeCenter();
                    newrecord = true;
                }

                if (files[0] != null && files[0].ContentLength > 0)
                {
                    if (o.FilePath != null)
                    {
                        FileInfo fi2 = new FileInfo(Server.MapPath(o.FilePath));
                        fi2.Delete();
                    }

                    string directory = "~/App_Data/Uploads/KnowledgeCenter";
                    bool exists = System.IO.Directory.Exists(Server.MapPath(directory));
                    if (!exists)
                        System.IO.Directory.CreateDirectory(Server.MapPath(directory));
                    var fileName = Path.GetFileName(files[0].FileName);
                    fileName = Guid.NewGuid() + "_" + fileName;
                    var path = Path.Combine(Server.MapPath(directory), fileName);
                    files[0].SaveAs(path);
                    o.FilePath = "/App_Data/Uploads/KnowledgeCenter/" + fileName;
                    string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
    Request.ApplicationPath.TrimEnd('/') + "/";
                    o.AbsolutePath = baseUrl + "App_Data/Uploads/KnowledgeCenter/" + fileName;
                }



                o.Heading = vm.Heading;
                o.Description = vm.Description;

                if (newrecord)
                {
                    db.KnowledgeCenters.Add(o);
                }
                int count = db.SaveChanges();
                return Json(new { Message = "success" });
            }
        }



    }
}