using CompanyPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace CompanyPortal.Controllers.Services
{
    public class SaveController : ApiController
    {

     
        [HttpPost]
        [Route("save/company")]
        public int company(CompanyViewModel c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                Company o = db.Companies.FirstOrDefault(x => x.ID == c.ID);
                bool newrecord = false;
                if (o == null)
                {
                    o = new Company();
                    newrecord = true;
                }
                o.Name = c.Name;    
                o.Url = c.Url;  
                if (newrecord)
                {
                    db.Companies.Add(o);
                }
                int count = db.SaveChanges();
                return count;
            }
        
        }

        [HttpPost]
        [Route("save/fleet")]
        public int fleet(FleetViewModel c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                Fleet o = db.Fleets.FirstOrDefault(x => x.ID == c.ID);
                bool newrecord = false;
                if (o == null)
                {
                    o = new Fleet();
                    newrecord = true;
                }
                o.Name = c.Name;
                if (newrecord)
                {
                    db.Fleets.Add(o);
                }
                int count = db.SaveChanges();
                return count;
            }

        }

        [HttpPost]
        [Route("save/vehicle")]
        public int vehicle(VehicleViewModel c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                Vehicle o = db.Vehicles.FirstOrDefault(x => x.ID == c.ID);
                bool newrecord = false;
                if (o == null)
                {
                    o = new Vehicle();
                    newrecord = true;
                }
                o.Name = c.Name;
                o.VehicleIdentifier = c.VehicleIdentifier;
                o.Brand = c.Brand;
                o.Model = c.Model;
                o.YearManufactured = c.YearManufactured;
                o.Fleet = db.Fleets.FirstOrDefault(x=>x.ID==c.Fleet_ID);
                if (newrecord)
                {
                    db.Vehicles.Add(o);
                }
                int count = db.SaveChanges();
                return count;
            }

        }
        [HttpGet]
        [Route("save/access")]
        public int access(int ID , string type)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                AccessList o = db.AccessLists.FirstOrDefault(x => x.Type == type && x.ItemID == ID);
                if(o== null)
                {
                    o = new AccessList();
                    o.ItemID = ID;      
                    o.Type = type;
                    db.AccessLists.Add(o);
                }
                else
                {
                    db.AccessLists.Remove(o);
                }
                int i = db.SaveChanges();
                return i;
            }

        }

    }
}