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

        [HttpPost]
        [Route("save/company")]
        public int company(CompanyViewModel c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
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
        [Route("save/category")]
        public int category(CategoryViewModel c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Category o = db.Categories.FirstOrDefault(x => x.ID == c.ID);
                bool newrecord = false;
                if (o == null)
                {
                    o = new Category();
                    newrecord = true;
                }
                o.Name = c.Name;
                if (newrecord)
                {
                    db.Categories.Add(o);
                }
                int count = db.SaveChanges();
                return count;
            }

        }

        [HttpPost]
        [Route("save/supplier")]
        public int supplier(SupplierViewModel c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Supplier o = db.Suppliers.FirstOrDefault(x => x.ID == c.ID);
                bool newrecord = false;
                if (o == null)
                {
                    o = new Supplier();
                    newrecord = true;
                }
                o.Name = c.Name;
                o.Headoffice = c.Name;
                o.ContactDetail = c.ContactDetail;
                o.ContactPerson = c.ContactPerson;
                o.Country = c.Country;
                if (newrecord)
                {
                    db.Suppliers.Add(o);
                }
                int count = db.SaveChanges();
                return count;
            }

        }
        [HttpPost]
        [Route("save/oem")]
        public int oem(OemViewModel c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Oem o = db.Oems.FirstOrDefault(x => x.ID == c.ID);
                bool newrecord = false;
                if (o == null)
                {
                    o = new Oem();
                    newrecord = true;
                }
                o.Name = c.Name;
                o.Brand = c.Brand;
                o.Model = c.Model;
                o.YearManufactured = c.YearManufactured;
                o.Country = c.Country;
                if (newrecord)
                {
                    db.Oems.Add(o);
                }
                int count = db.SaveChanges();
                return count;
            }

        }
        [HttpPost]
        [Route("save/app")]
        public int app(AppViewModel c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ECUApp o = db.ECUApps.FirstOrDefault(x => x.ID == c.ID);
                bool newrecord = false;
                if (o == null)
                {
                    o = new ECUApp();
                    newrecord = true;
                }
                o.Name = c.Name;
                o.Description = c.Description;
                o.VehicleModel = c.VehicleModel;
                o.YearManufactured = c.YearManufactured;
                o.Breaches = c.Breaches;
                o.Vulnerabilities = c.Vulnerabilities;
                o.IsActive = c.IsActive;
                o.Category = db.Categories.FirstOrDefault(x=>x.ID==c.Category_ID);
                o.Supplier = db.Suppliers.FirstOrDefault(x => x.ID == c.Supplier_ID);
                if (newrecord)
                {
                    db.ECUApps.Add(o);
                }
                int count = db.SaveChanges();
                return count;
            }

        }
    }
}