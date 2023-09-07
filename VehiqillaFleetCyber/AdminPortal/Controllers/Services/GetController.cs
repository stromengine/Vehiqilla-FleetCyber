using AdminPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace AdminPortal.Controllers.Services
{
    public class GetController : ApiController
    {

        [HttpGet]
        [Route("get/company")]
        public CompanyViewModel company(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CompanyViewModel o = db.Companies.Where(x => x.ID == id).Select(p => new CompanyViewModel
                {
                    ID = p.ID,
                    Name = p.Name,
                    Url = p.Url,
                    License = p.License,
                    Fleets = p.Fleets,
                    Vehicles = p.Vehicles,
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
                List<UserModel> o = db.Users.Where(x=> x.Id != "f2d14967-211d-471b-92cf-892161c88e19").Select(p => new UserModel
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
        [Route("get/CyberRiskType")]
        public CyberRiskTypeViewModel CyberRiskType(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CyberRiskTypeViewModel o = db.CyberRiskTypes.Where(x => x.ID == id).Select(p => new CyberRiskTypeViewModel
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
                    FilePath = p.FilePath,
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

                string s  = db.Contents.Where(x=>x.Type=="About").Select(p=>p.Text).FirstOrDefault();
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

    }
}