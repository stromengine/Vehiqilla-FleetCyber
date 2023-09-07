using AdminPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPortal.Controllers
{
    public class EmailVerificationController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index(string code)
        {
            try
            {
                #region Load Existing Details

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    if (!String.IsNullOrEmpty(code))
                    {
                        ApplicationUser user = db.Users.FirstOrDefault(d => d.Code == code);
                        if (user != null)
                        {
                            user.Code = null;
                            user.EmailConfirmed = true;
                            db.SaveChanges();
                            ViewBag.Title = "Email Verification Complete";
                            ViewBag.Url = db.Companies.FirstOrDefault(x=>x.ID==user.Company_ID).Url;
                            ViewBag.ResultMessage = "  Your email verification is now complete.";
                        }
                        else
                        {
                            ViewBag.Title = "Verification Failed.";
                            ViewBag.ResultMessage = "The Authentication Link has expired please contact Administrator.";
                        }
                    }
                    else
                    {
                        ViewBag.Title = "Verification Failed.";
                        ViewBag.ResultMessage = "The Authentication Link has expired please contact Administrator.";
                    }
                }

                #endregion

            }
            catch (Exception ex)
            {
                ViewBag.ResultMessage = "Error: " + ex.Message;
            }


            return View();
        }
    }
}