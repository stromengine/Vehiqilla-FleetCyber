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
    public class DropdownsController : ApiController
    {
        [HttpGet]
        [Route("dropdowns/companies")]
        public List<NameValue> companies()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<NameValue> xx = db.Companies.Select(p => new NameValue()
                {
                    ID = p.ID,
                    Name = p.Name
                }).OrderBy(s => s.Name).ToList();
                return xx;
            }
        }
        [HttpGet]
        [Route("dropdowns/categories")]
        public List<NameValue> categories()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<NameValue> xx = db.Categories.Select(p => new NameValue()
                {
                    ID = p.ID,
                    Name = p.Name
                }).OrderBy(s => s.Name).ToList();
                return xx;
            }
        }
        [HttpGet]
        [Route("dropdowns/suppliers")]
        public List<NameValue> suppliers()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<NameValue> xx = db.Suppliers.Select(p => new NameValue()
                {
                    ID = p.ID,
                    Name = p.Name
                }).OrderBy(s => s.Name).ToList();
                return xx;
            }
        }
        [HttpGet]
        [Route("dropdowns/apps")]
        public List<NameValue> apps()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<NameValue> xx = db.ECUApps.Select(p => new NameValue()
                {
                    ID = p.ID,
                    Name = p.Name
                }).OrderBy(s => s.Name).ToList();
                return xx;
            }
        }

        [HttpGet]
        [Route("dropdowns/appsbysupplier")]
        public List<NameValue> appsbysupplier(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<NameValue> xx = db.ECUApps.Where(x=>x.Supplier.ID==id).Select(p => new NameValue()
                {
                    ID = p.ID,
                    Name = p.Name
                }).OrderBy(s => s.Name).ToList();
                return xx;
            }
        }
    }
}