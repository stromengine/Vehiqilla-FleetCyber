using CompanyPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace CompanyPortal.Controllers.Services
{
    public class DeleteController : ApiController
    {

        [HttpGet]
        [Route("delete/company")]
        public bool company(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                Company o = db.Companies.FirstOrDefault(x => x.ID == id);
                db.Companies.Remove(o);
                db.SaveChanges();   
                return true;
            }
        
        }


        [HttpGet]
        [Route("delete/fleet")]
        public bool fleet(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                Fleet o = db.Fleets.FirstOrDefault(x => x.ID == id);
                db.Fleets.Remove(o);
                db.SaveChanges();
                return true;
            }

        }

        [HttpGet]
        [Route("delete/Vehicle")]
        public bool Vehicle(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                List<AppVehicleMap> xx = db.AppVehicleMaps.Where(x => x.Vehicle_ID == id).ToList();
                db.AppVehicleMaps.RemoveRange(xx);
                db.SaveChanges();

                Vehicle o = db.Vehicles.FirstOrDefault(x => x.ID == id);
                db.Vehicles.Remove(o);
                db.SaveChanges();
                return true;
            }

        }


        [HttpGet]
        [Route("delete/finding")]
        public bool Finding(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                Finding o = db.Findings.FirstOrDefault(x => x.ID == id);
                db.Findings.Remove(o);
                db.SaveChanges();
                return true;
            }

        }
    }
}