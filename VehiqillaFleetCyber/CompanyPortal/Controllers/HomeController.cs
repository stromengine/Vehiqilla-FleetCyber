using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;

namespace CompanyPortal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public ActionResult Index(bool ShowDeleted = false)
        {
           

            return View();
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