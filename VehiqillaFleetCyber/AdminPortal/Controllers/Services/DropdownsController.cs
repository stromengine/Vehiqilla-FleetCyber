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
    }
}