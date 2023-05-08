using AdminPortal.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdminPortal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Company()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.Companies.Where(x=>x.IsDeleted==false).ToList();
                return View(list);
            }
        }

        #region AspIdentitySetup
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private object con;

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
        [HttpPost]
        [Route("save/company")]
        public async Task<string> company(CompanyViewModel c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Company o = db.Companies.FirstOrDefault(x => x.ID == c.ID);
                bool newrecord = false;
                if (o == null)
                {
                    o = new Company();
                    newrecord = true;
                }
                o = c.toModel();
                if (newrecord)
                {
                    db.Companies.Add(o);
                }
                db.SaveChanges();

                foreach (ApplicationUser user in c.Users)
                {
                    var u = new ApplicationUser { UserName = user.UserName, Email = user.Email, Name = user.Name,Company=o };
                    var result = await UserManager.CreateAsync(user, "P@ssword@1");
                }

            }
            return "";
        }
        public ActionResult Categories()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.Categories.Where(x => x.IsDeleted == false).ToList();
                return View(list);
            }
        }
        public ActionResult Suppliers()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.Suppliers.Where(x => x.IsDeleted == false).ToList();
                return View(list);
            }
        }
        public ActionResult Oems()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.Oems.Where(x => x.IsDeleted == false).ToList();
                return View(list);
            }
        }
        public ActionResult Apps()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.ECUApps.Where(x => x.IsDeleted == false).ToList();
                return View(list);
            }
        }
        public ActionResult Breaches(int? ID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.AppBreachs.Where(x => x.IsDeleted == false && (x.ECUApp.ID == ID || ID == null)).ToList();
                return View(list);
            }
        }
        public ActionResult Vulnerabilities(int? ID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.AppVulnerabilities.Where(x => x.IsDeleted == false && (x.ECUApp.ID == ID || ID==null)).ToList();
                return View(list);
            }
        }


    }
}