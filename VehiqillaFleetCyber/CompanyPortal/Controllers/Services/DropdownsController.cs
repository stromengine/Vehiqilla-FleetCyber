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
    public class DropdownsController : ApiController
    {
        [HttpGet]
        [Route("dropdowns/fleets")]
        public List<NameValue> fleets()
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                List<NameValue> xx = db.Fleets.Select(p => new NameValue()
                {
                    ID = p.ID,
                    Name = p.Name
                }).OrderBy(s => s.Name).ToList();
                return xx;
            }
        }
        [HttpGet]
        [Route("dropdowns/vehicles")]
        public List<NameValue> vehicles(int ID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                List<NameValue> xx = db.Vehicles.Where(x=>x.Fleet == db.Fleets.FirstOrDefault(f => f.ID == ID)).Select(p => new NameValue()
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
        [Route("dropdowns/cyberrisktypes")]
        public List<NameValue> cyberrisktypes()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<NameValue> xx = db.CyberRiskTypes.Select(p => new NameValue()
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
    }
}