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
    public class GetController : ApiController
    {

        [HttpGet]
        [Route("get/fleet")]
        public FleetViewModel fleet(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                FleetViewModel o = db.Fleets.Where(x => x.ID == id).Select(p => new FleetViewModel
                {
                    ID = p.ID,
                    Name = p.Name,
                }).FirstOrDefault();
                return o;
            }

        }
        [HttpGet]
        [Route("get/vehicle")]
        public VehicleViewModel vehicle(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                VehicleViewModel o = db.Vehicles.Include("Fleet").Where(x => x.ID == id).Select(p => new VehicleViewModel
                {
                    ID = p.ID,
                    VehicleIdentifier = p.VehicleIdentifier,
                    Name = p.Name,
                    Brand = p.Brand,
                    Model = p.Model,
                    Fleet_ID = p.Fleet.ID,
                    YearManufactured = p.YearManufactured,
                }).FirstOrDefault();
                return o;
            }

        }
        [HttpGet]
        [Route("get/companyuser")]
        public UserModel companyuser(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                UserModel o = db.Users.Where(x => x.Id == id).Select(p => new UserModel
                {
                    Id = p.Id,
                    Company_ID = p.Company.ID,
                    Name = p.Name,
                    Address = p.Address,
                    Phone = p.Phone,
                    Email = p.Email,
                }).FirstOrDefault();
                return o;
            }

        }
        [HttpGet]
        [Route("get/companyusers")]
        public List<UserModel> companyusers()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<UserModel> o = db.Users.Select(p => new UserModel
                {
                    Id = p.Id,
                    Company_ID = p.Company.ID,
                    Name = p.Name,
                    Address = p.Address,
                    Phone = p.Phone,
                    Email = p.Email,
                }).ToList();
                return o;
            }

        }
        [HttpGet]
        [Route("get/category")]
        public CategoryViewModel category(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CategoryViewModel o = db.Categories.Where(x => x.ID == id).Select(p => new CategoryViewModel
                {
                    ID = p.ID,
                    Name = p.Name,
                }).FirstOrDefault();
                return o;
            }

        }


        [HttpGet]
        [Route("get/supplier")]
        public SupplierViewModel supplier(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                SupplierViewModel o = db.Suppliers.Where(x => x.ID == id).Select(p => new SupplierViewModel
                {
                    ID = p.ID,
                    Name = p.Name,
                    ContactPerson = p.ContactPerson,
                    ContactDetail = p.ContactDetail,
                    Country = p.Country,
                    Headoffice = p.Headoffice,
                }).FirstOrDefault();
                return o;
            }

        }

        [HttpGet]
        [Route("get/oem")]
        public OemViewModel oem(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                OemViewModel o = db.Oems.Where(x => x.ID == id).Select(p => new OemViewModel
                {
                    ID = p.ID,
                    Name = p.Name,
                    Brand = p.Brand,
                    Model = p.Model,
                    YearManufactured = p.YearManufactured,
                    Country = p.Country,
                }).FirstOrDefault();
                return o;
            }

        }
        [HttpGet]
        [Route("get/app")]
        public AppViewModel app(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                AppViewModel o = db.ECUApps.Include("Category").Where(x => x.ID == id).Select(p => new AppViewModel
                {
                    ID = p.ID,
                    Name = p.Name,
                    Category = p.Category,
                    Description = p.Description,
                    Supplier_ID = p.Supplier.ID,
                    Category_ID = p.Category.ID,
                }).FirstOrDefault();
                return o;
            }

        }

        [HttpGet]
        [Route("get/vulnerability")]
        public VulnerabilityViewModel vulnerability(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VulnerabilityViewModel o = db.AppVulnerabilities.Where(x => x.ID == id).Select(p => new VulnerabilityViewModel
                {
                    ID = p.ID,
                    Name = p.Name,
                    Description = p.Description,
                    HackType = p.HackType,
                    Access = p.Access,
                    Range = p.Range,
                    AttackVector = p.AttackVector,
                    AttackMethod = p.AttackMethod,
                    Impact = p.Impact,
                    ResearchName = p.ResearchName,
                    Reference = p.Reference,
                    OemImpacted = p.OemImpacted,
                    Link = p.Link,
                }).FirstOrDefault();
                return o;
            }

        }
        [HttpGet]
        [Route("get/breach")]
        public BreachViewModel breach(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                BreachViewModel o = db.AppBreachs.Where(x => x.ID == id).Select(p => new BreachViewModel
                {
                    ID = p.ID,
                    Name = p.Name,
                    Description = p.Description,
                    NewsSource = p.NewsSource,
                    VulnerabilityExploited = p.VulnerabilityExploited,
                    Date = p.Date,
                    EcuApp_ID = p.ECUApp.ID,
                }).FirstOrDefault();
                return o;
            }

        }

        [HttpGet]
        [Route("get/about")]
        public string about()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                string s = db.Contents.Where(x => x.Type == "About").Select(p => p.Text).FirstOrDefault();
                return s;
            }

        }

        [HttpGet]
        [Route("get/knowledgecenter")]
        public KnowledgerCenterViewModel knowledgecenter(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                KnowledgerCenterViewModel o = db.KnowledgeCenters.Where(x => x.ID == id).Select(p => new KnowledgerCenterViewModel
                {
                    ID = p.ID,
                    Heading = p.Heading,
                    Description = p.Description,
                    FilePath = p.FilePath,
                }).FirstOrDefault();
                return o;
            }

        }
        [HttpGet]
        [Route("get/vehicleapps")]
        public List<AppViewModel> vehicleapps(int id)
        {
            List<AppViewModel> o;
            List<int> vs;

         
            List<int> map;
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                vs = db.AccessLists.Where(x => x.Type == "App").Select(p => p.ItemID).ToList();
                map = db.AppVehicleMaps.Where(x => x.Vehicle_ID == id).Select(p => p.App_ID).ToList();
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                o = db.ECUApps.Where(x => vs.Contains(x.ID)).Select(p => new AppViewModel
                {
                    ID = p.ID,
                    Name = p.Name,
                }).ToList();

            }
            for (int i = 0; i < o.Count; i++)
            {
                if (map.Contains(o[i].ID))
                {
                    o[i].MappedToVehicle = true;
                }
                else
                {
                    o[i].MappedToVehicle = false;
                }
            }


            return o;
        }   
        [HttpGet]
        [Route("get/vehiclemap")]
        public bool vehicleapps(int aid,int vid)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                AppVehicleMap o = db.AppVehicleMaps.FirstOrDefault(x => x.App_ID == aid && x.Vehicle_ID == vid);
                if(o == null)
                {
                    o = new AppVehicleMap();
                    o.App_ID = aid;
                    o.Vehicle_ID = vid;
                    db.AppVehicleMaps.Add(o);
                    db.SaveChanges();
                }
                else
                {
                    db.AppVehicleMaps.Remove(o);
                    db.SaveChanges();
                }
            }
         
            return true;
        }
    }
}