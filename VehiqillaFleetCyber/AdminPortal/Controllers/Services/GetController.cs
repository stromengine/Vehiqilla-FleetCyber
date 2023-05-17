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
    public class GetController : ApiController
    {

        [HttpGet]
        [Route("get/company")]
        public CompanyViewModel company(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                CompanyViewModel o = db.Companies.Where(x => x.ID == id).Select(p=> new CompanyViewModel { 
                ID = p.ID,
                Name = p.Name,  
                Url = p.Url,    
                }).FirstOrDefault();
                return o ;
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
                AppViewModel o = db.ECUApps.Where(x => x.ID == id).Select(p => new AppViewModel
                {
                    ID = p.ID,
                    Name = p.Name,
                    Description = p.Description,
                    Supplier_ID = p.Supplier.ID,
                    Category_ID = p.Category.ID,
                }).FirstOrDefault();
                return o;
            }

        }
    }
}