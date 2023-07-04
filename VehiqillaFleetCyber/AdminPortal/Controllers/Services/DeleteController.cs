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
    public class DeleteController : ApiController
    {

        [HttpGet]
        [Route("delete/company")]
        public bool company(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Company o = db.Companies.FirstOrDefault(x => x.ID == id);
                db.Companies.Remove(o);
                db.SaveChanges();   
                return true;
            }
        
        }

        [HttpGet]
        [Route("delete/category")]
        public bool category(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Category o = db.Categories.FirstOrDefault(x => x.ID == id);
                db.Categories.Remove(o);
                db.SaveChanges();
                return true;
            }

        }
        [HttpGet]
        [Route("delete/supplier")]
        public bool supplier(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Supplier o = db.Suppliers.FirstOrDefault(x => x.ID == id);
                db.Suppliers.Remove(o);
                db.SaveChanges();
                return true;
            }

        }
        [HttpGet]
        [Route("delete/oem")]
        public bool oem(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Oem o = db.Oems.FirstOrDefault(x => x.ID == id);
                db.Oems.Remove(o);
                db.SaveChanges();
                return true;
            }

        }
        [HttpGet]
        [Route("delete/app")]
        public bool app(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ECUApp o = db.ECUApps.FirstOrDefault(x => x.ID == id);
                db.ECUApps.Remove(o);
                db.SaveChanges();
                return true;
            }

        }
        [HttpGet]
        [Route("delete/vulnerability")]
        public bool vulnerability(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                AppVulnerability o = db.AppVulnerabilities.FirstOrDefault(x => x.ID == id);
                db.AppVulnerabilities.Remove(o);
                db.SaveChanges();
                return true;
            }

        }
        [HttpGet]
        [Route("delete/breach")]
        public bool breach(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                AppBreach o = db.AppBreachs.FirstOrDefault(x => x.ID == id);
                db.AppBreachs.Remove(o);
                db.SaveChanges();
                return true;
            }
        }
        [HttpGet]
        [Route("delete/invite")]
        public bool invite(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VehiAssureInvite o = db.VehiAssureInvites.FirstOrDefault(x => x.ID == id);
                db.VehiAssureInvites.Remove(o);
                db.SaveChanges();
                return true;
            }
        }
        [HttpGet]
        [Route("delete/KnowledgeCenter")]
        public bool KnowledgeCenter(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                KnowledgeCenter o = db.KnowledgeCenters.FirstOrDefault(x => x.ID == id);
                db.KnowledgeCenters.Remove(o);
                db.SaveChanges();
                return true;
            }
        }

    }
}