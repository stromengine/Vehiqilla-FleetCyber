using AdminPortal.Models;
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
        [HttpPost]
        [Route("save/vulnerability")]
        public int vulnerability(VulnerabilityViewModel c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                AppVulnerability o = db.AppVulnerabilities.FirstOrDefault(x => x.ID == c.ID);
                bool newrecord = false;
                if (o == null)
                {
                    o = new AppVulnerability();
                    newrecord = true;
                }
                o.Name = c.Name;
                o.Description = c.Description;
                o.HackType = c.HackType;
                o.Access = c.Access;
                o.Range = c.Range;
                o.AttackVector = c.AttackVector;
                o.AttackMethod = c.AttackMethod;
                o.Impact = c.Impact;
                o.ResearchName = c.ResearchName;
                o.Reference = c.Reference;
                o.OemImpacted = c.OemImpacted;
                o.Link = c.Link;
                o.ECUApp = db.ECUApps.FirstOrDefault(x => x.ID == c.EcuApp_ID);
                if (newrecord)
                {
                    db.AppVulnerabilities.Add(o);
                }
                int count = db.SaveChanges();
                return count;
            }

        }
        [HttpPost]
        [Route("save/breach")]
        public int breach(BreachViewModel c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                AppBreach o = db.AppBreachs.FirstOrDefault(x => x.ID == c.ID);
                bool newrecord = false;
                if (o == null)
                {
                    o = new AppBreach();
                    newrecord = true;
                }
                o.Name = c.Name;
                o.Description = c.Description;
                o.NewsSource = c.NewsSource;
                o.VulnerabilityExploited = c.VulnerabilityExploited;
                o.Date = c.Date;
                o.ECUApp = db.ECUApps.FirstOrDefault(x => x.ID == c.EcuApp_ID);
                if (newrecord)
                {
                    db.AppBreachs.Add(o);
                }
                int count = db.SaveChanges();
                return count;
            }

        }
        public class NotificationViewModel
        {
            public string Emails { get; set; }
            public string Heading { get; set; }
            public string Description { get; set; }
        }

        [HttpPost]
        [Route("save/notification")]
        public int notification(NotificationViewModel model)
        {
            int count = 0;
            string value = (@"\<(.*?)\>");
            var emails = Regex.Matches(model.Emails, @value);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                foreach (var e in emails)
                {
                    string ex = e.ToString();
                    string email = ex.Replace("<", "");
                    email = email.Replace(">", "");
                    ApplicationUser user = db.Users.FirstOrDefault(x => x.Email == email);
                    Notification o = new Notification();
                    o.Heading = model.Heading;
                    o.Description = model.Description;
                    o.User = user;
                    o.IsDeleted = false;
                    o.Read = false;
                    o.ModifiedBy = User.Identity.GetUserId();
                    o.DateModified = DateTime.UtcNow;
                    o.CreatedBy = User.Identity.GetUserId();
                    o.DateCreated = DateTime.UtcNow;
                    db.Notifications.Add(o);
                    count =  db.SaveChanges();

                }
            }
            return count;
        }

        public class AboutViewModel
        {
            public string text { get; set; }
        }
        
        [HttpPost]
        [Route("save/about")]
        public int about(AboutViewModel text)
        {
            Content d;
            int count = 0;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                bool newrecord = false;
                d = db.Contents.FirstOrDefault(x => x.Type == "About");
                if (d == null)
                {
                    d = new Content();
                    d.Type = "About";
                    newrecord = true;
                }

                d.Text = text.text;

                if(newrecord)
                    db.Contents.Add(d);

                count = db.SaveChanges();


            }

            return count;
        }


     

    }
}