using CompanyPortal.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace CompanyPortal.Controllers
{
    [Authorize]
    public partial class WebController : ApiController
    {
        [HttpGet]
        [Route("web/emailexists")]
        public bool emailexists(string email, string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<ApplicationUser> xx = db.Users.Where(x => x.Email == email && x.Id != id).ToList();
                return xx.Count() > 0 ? false : true;
            }
        }
        [HttpGet]
        [Route("web/MegaReport")]
        public List<MegaReport> MegaReport()
        {
            List<AppViewModel> applist = new List<AppViewModel>();
            List<MegaReport> report = new List<MegaReport>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                applist = db.Database.SqlQuery<AppViewModel>("Rpt_MegaReport").ToList();
            }
            using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
            {
                List<AppVehicleMap> list = db.AppVehicleMaps.ToList();

                foreach (AppVehicleMap m in list)
                {
                    AppViewModel a = applist.FirstOrDefault(x => x.ID == m.App_ID);
                 
                    Vehicle v = db.Vehicles.Include("Fleet").First(x => x.ID == m.Vehicle_ID);
                    if (a != null)
                    {
                        report.Add(new MegaReport
                        {
                            Fleet = v.Fleet.Name,
                            Vehicle = v.Name,
                            Brand = v.Brand,
                            Model = v.Model,
                            YearManufactured = v.YearManufactured,
                            AppName = a.Name,
                            Supplier = a.SupplierName,
                            CategoryName = a.CategoryName,
                            Breaches = a.Breaches,
                            Vulnerabilities = a.Vulnerabilities,
                            Score = a.Score,
                            AppID = a.ID,
                            COLOR = "",

                        });
                    }

                }

            }

            return report;
        }
    }
}