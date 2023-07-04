using CompanyPortal.Helpers;
using CompanyPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CompanyPortal.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Admin
        #region AspIdentitySetup
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public CompanyController()
        {
        }
        public CompanyController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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

        public ActionResult Fleet()
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                var list = db.Fleets.Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult Vehicle()
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                var list = db.Vehicles.Include("Fleet").OrderByDescending(p => p.DateCreated).ToList();
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
                var list = db.Suppliers.Where(x => x.IsDeleted == false).Select(p => new SupplierViewModel
                {

                    ID = p.ID,
                    Name = p.Name,
                    ContactPerson = p.ContactPerson,
                    ContactDetail = p.ContactDetail,
                    Headoffice = p.Headoffice,
                    Country = p.Country,
                    Logo = p.Logo,

                }).OrderByDescending(o => o.ID).ToList();
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

                var list = db.ECUApps.Include("Supplier").Include("Category").Where(x => x.IsDeleted == false).Select(q => new AppViewModel
                {
                    Name = q.Name,
                    Supplier = q.Supplier,
                    Category = q.Category,
                    Description = q.Description,
                    ID = q.ID,


                }).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult Breaches(int? ID)
        {
            List<int> vs;
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                vs = db.AccessLists.Where(x => x.Type == "App").Select(p => p.ItemID).ToList();

            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var list = db.ECUApps.Include("Supplier").Include("Category").Where(x => x.IsDeleted == false && vs.Contains(x.ID)).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult Vulnerabilities(int? ID)
        {
            List<int> vs;
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                vs = db.AccessLists.Where(x => x.Type == "App").Select(p => p.ItemID).ToList();

            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.ECUApps.Include("Supplier").Include("Category").Where(x => x.IsDeleted == false && vs.Contains(x.ID)).OrderByDescending(p => p.ID).ToList();
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
        public ActionResult AppRisks(int? ID)
        {
            List<int> vs;
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                vs = db.AccessLists.Where(x => x.Type == "App").Select(p => p.ItemID).ToList();

            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.ECUApps.Include("Supplier").Include("Category").Where(x => x.IsDeleted == false && vs.Contains(x.ID)).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        #region VehiAssured Dashboard
        public ActionResult VehiAssured(int? ID)
        {
            List<int> vs;
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                vs = db.AccessLists.Where(x => x.Type == "App").Select(p => p.ItemID).ToList();

            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.ECUApps.Include("Supplier").Include("Category").Where(x => x.IsDeleted == false && vs.Contains(x.ID)).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }

        [HttpGet]
        public ActionResult CategoriesList()
        {
            List<Category> xx = new List<Category>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = db.Categories.Where(x => x.IsDeleted == false).ToList();
            }
            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        public class ECUAppViewModel
        {
            public int ID { set; get; }
            public string Name { set; get; }
            public int Supplier { set; get; }
            public string Description { set; get; }
            public int Category { set; get; }


            public DateTime DateCreated { set; get; }
            public DateTime AssessmentDate { set; get; }
            public string OemName { set; get; }
            public string SupplierName { set; get; }
            public string Logo { set; get; }
            public string CategoryName { set; get; }
            public string CreatedBy { set; get; }
            public DateTime DateModified { set; get; }
            public string RequestedBy { set; get; }
            public string Request { set; get; }
            public int? Score { set; get; }
            public int? Breaches { set; get; }
            public int? Vulnerabilities { set; get; }

            public List<NameValue> SuppliersList { set; get; }
            public List<NameValue> AppsList { set; get; }
            public List<NameValue> CategoriesList { set; get; }


        }
        [HttpGet]
        public ActionResult AppsByCategory(int CatID)
        {
            List<ECUAppViewModel> xx = new List<ECUAppViewModel>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@CatID", SqlDbType.Int);

                param[0].Value = CatID;

                xx = db.Database.SqlQuery<ECUAppViewModel>("GetAssessmentsOverallResult @CatID", param).ToList();
            }
            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult AppsList()
        {
            List<ECUAppViewModel> xx = new List<ECUAppViewModel>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@CatID", SqlDbType.Int);

                param[0].Value = -1;

                xx = db.Database.SqlQuery<ECUAppViewModel>("GetAssessmentsOverallResult @CatID", param).ToList();
            }
            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult Mapping()
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                var list = db.Vehicles.Include("Fleet").OrderByDescending(p => p.DateCreated).ToList();
                return View(list);
            }
        }

        public ActionResult MegaReport()
        {
            return View();
        }
    }
}