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
                var list = db.Companies.Where(x=>x.IsDeleted==false).OrderByDescending(p=>p.ID).ToList();
                return View(list);
            }
        }

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
                var list = db.AppVulnerabilities.Include("EcuApp").Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }

    }
}