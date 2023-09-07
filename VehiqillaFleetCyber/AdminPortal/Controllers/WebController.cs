using AdminPortal.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace AdminPortal.Controllers
{
    [Authorize]
    public partial class WebController : ApiController
    {
        [HttpGet]
        [Route("web/emailexists")]
        public bool emailexists(string email,string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<ApplicationUser> xx = db.Users.Where(x=>x.Email== email && x.Id!=id).ToList();
                return xx.Count()>0 ? false : true;
            }
        }


        [HttpGet]
        [Route("web/verifyemail")]
        public bool verifyemail(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser o = db.Users.FirstOrDefault(x => x.Id == id);
                o.EmailConfirmed = true;
                db.SaveChanges();
                return true;
            }
        }
    }
}