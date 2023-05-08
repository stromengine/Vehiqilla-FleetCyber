using AdminPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace AdminPortal.Controllers.Services
{
    public class SaveController : ApiController
    {

        //[HttpPost]
        //[Route("save/company")]
        //public async Task<string> company (CompanyViewModel c)
        //{
        //    using (Models.IdentityDbContext db = new Models.IdentityDbContext())
        //    {
        //        Company o = db.Companies.FirstOrDefault(x => x.ID == c.ID);
        //        bool newrecord = false; 
        //        if(o == null)
        //        {
        //            o = new Company();
        //            newrecord = true;
        //        }
        //        o = c.toModel();
        //        if (newrecord)
        //        {
        //            db.Companies.Add(o);
        //        }
        //        db.SaveChanges();   

        //        foreach(ApplicationUser user in c.Users)
        //        {
        //            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
        //            var u = new ApplicationUser { UserName = user.UserName, Email = user.Email, Name = user.Name };
        //            var result = await userManager.CreateAsync(u, "P@ssword@1");
        //        }   
               
        //    }
        //    return "";
        //}
    }
}