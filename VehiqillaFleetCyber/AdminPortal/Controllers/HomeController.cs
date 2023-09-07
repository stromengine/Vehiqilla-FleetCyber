using AdminPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPortal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public ActionResult Index(bool ShowDeleted = false)
        {
           

            return View();
        }
        public ActionResult About()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var list = db.Contents.Where(x => x.IsDeleted == false && x.Type == "About").OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();

            IAuthenticationManager AuthenticationManager = HttpContext.GetOwinContext().Authentication;

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login", "Account");
        }
    }
}