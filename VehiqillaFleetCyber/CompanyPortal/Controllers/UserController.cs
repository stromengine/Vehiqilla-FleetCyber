using CompanyPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CompanyPortal.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            UserViewModel model = new UserViewModel
            {
                ID = User.Identity.GetUserId()
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult Save(UserViewModel model)
        {
            try
            {
                using (Models.ApplicationDbContext db = new Models.ApplicationDbContext())
                {
                    UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                    ApplicationUser user = UserManager.FindById(model.ID);
                    if (!UserManager.CheckPassword(user, model.CurrentPassword))
                    {
                        return Json("Incorrect Current Password.", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        ApplicationUser obj = db.Users.FirstOrDefault(d => d.Id == model.ID);
                        if (!string.IsNullOrEmpty(model.Password))
                        {
                            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
                            if (userManager.HasPassword(model.ID))
                            {
                                userManager.RemovePassword(model.ID);
                                userManager.AddPassword(model.ID, model.Password);
                            }
                        }
                        db.SaveChanges();
                        ViewBag.ResultMessage = obj.UserName + " updated successfully!";
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString(), JsonRequestBehavior.AllowGet);
            }
            return Json("Password Changed Successfully", JsonRequestBehavior.AllowGet);
        }
    }
}