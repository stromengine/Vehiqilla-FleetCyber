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
            int maxFleetCount = 0;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                string id = HttpContext.Current.User.Identity.GetUserId();
                ApplicationUser user = db.Users.FirstOrDefault(x=>x.Id==id);
                Company company = db.Companies.FirstOrDefault(y=>y.ID==user.Company.ID);
                maxFleetCount = company.Fleets??0;

            }


            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {

                Fleet o = db.Fleets.FirstOrDefault(x => x.ID == c.ID);

              


                bool Duplicate = db.Fleets.Any(x => x.ID != c.ID && (x.Name == c.Name));
                if (Duplicate)
                {
                    return -1;
                }

                bool newrecord = false;
                if (o == null)
                {
                    o = new Fleet();
                    newrecord = true;

                    int countFleets = db.Fleets.Count();
                    if (countFleets >= maxFleetCount)
                    {
                        return -2;
                    }
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
            int maxFleetCount = 0;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                string id = HttpContext.Current.User.Identity.GetUserId();
                ApplicationUser user = db.Users.FirstOrDefault(x => x.Id == id);
                Company company = db.Companies.FirstOrDefault(y => y.ID == user.Company.ID);
                maxFleetCount = company.Vehicles ?? 0;

            }


            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                Vehicle o = db.Vehicles.FirstOrDefault(x => x.ID == c.ID);


              

                bool Duplicate = db.Vehicles.Any(x => x.ID != c.ID && (x.Name == c.Name || x.VehicleIdentifier == c.VehicleIdentifier));
                if (Duplicate)
                {
                    return -1;
                }
                bool newrecord = false;
                if (o == null)
                {
                    o = new Vehicle();
                    newrecord = true;
                    int countFleets = db.Vehicles.Count();
                    if (countFleets >= maxFleetCount)
                    {
                        return -2;
                    }

                }
                o.Name = c.Name;
                o.VehicleIdentifier = c.VehicleIdentifier;
                o.Brand = c.Brand;
                o.Model = c.Model;
                o.YearManufactured = c.YearManufactured;
                o.Fleet = db.Fleets.FirstOrDefault(x => x.ID == c.Fleet_ID);
                if (newrecord)
                {
                    db.Vehicles.Add(o);
                }
                int count = db.SaveChanges();
                return count;
            }

        }
        [HttpPost]
        [Route("save/finding")]
        public int finding(FindingViewModel c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                Finding o = db.Findings.FirstOrDefault(x => x.ID == c.ID);

                //bool Duplicate = db.Vehicles.Any(x => x.ID != c.ID && (x.Name == c.Name || x.VehicleIdentifier == c.VehicleIdentifier));
                //if (Duplicate)
                //{
                //    return -1;
                //}
                bool newrecord = false;
                if (o == null)
                {
                    o = new Finding();
                    newrecord = true;
                }
                o.Name = c.Name;
                o.FleetID = c.FleetID;
                o.VehicleID = c.VehicleID;
                o.Details = c.Details;
                o.CyberRiskTypeID = c.CyberRiskTypeID;
                o.RiskImpact = c.RiskImpact;
                o.RiskLikelyhood = c.RiskLikelyhood;
                o.FindingRiskScore = c.FindingRiskScore;
                o.Recomendations = c.Recomendations;
                o.Owner = c.Owner;
                if (newrecord)
                {
                    db.Findings.Add(o);
                }
                int count = db.SaveChanges();
                return count;
            }

        }
        [HttpGet]
        [Route("save/access")]
        public int access(int ID, string type)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                AccessList o = db.AccessLists.FirstOrDefault(x => x.Type == type && x.ItemID == ID);
                if (o == null)
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