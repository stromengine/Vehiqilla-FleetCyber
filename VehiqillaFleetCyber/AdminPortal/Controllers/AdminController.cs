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
                var list = db.Users.OrderByDescending(p => p.DateCreated).ToList();
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
                ApplicationUser o = db.Users.FirstOrDefault(x => x.Id == model.Id);
                if (o != null)
                {
                    o.Name = model.Name;    
                    o.Email = model.Email;
                    o.Address = model.Address;
                    o.Phone = model.Phone;
                    o.Company = db.Companies.FirstOrDefault(x=>x.ID==model.Company_ID);
                   
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
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name, Address = model.Address, Phone = model.Phone, Company = company, DateCreated = DateTime.UtcNow, Code = code, Active = true };
            StringBuilder body = new StringBuilder();
            string link = ConfigurationManager.AppSettings["baseUrl"];
            body.AppendFormat("Dear {0},<br> Please click on this <a href='{1}profile/verified?code={2}'>link</a> to verify your account.", model.Name, link, code);

            var result = await UserManager.CreateAsync(user, model.Password);
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
                var list = db.AppVulnerabilities.Include("ECUApp").Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult AppBreach(int? ID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ViewBag.Title = db.ECUApps.FirstOrDefault(x => x.ID == ID).Name + " Breaches";
                var list = db.AppBreachs.Include("ECUApp").Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
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
                var list = db.Contents.Where(x => x.IsDeleted == false && x.Type=="About").OrderByDescending(p => p.ID).ToList();
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
                o.Heading = vm.Heading;
                o.Description = vm.Description;
                o.FilePath = vm.FilePath;
                if (newrecord)
                {
                    db.KnowledgeCenters.Add(o);
                }
                int count = db.SaveChanges();
                return Json(new { Message="success" });
            }
        }
    }
}