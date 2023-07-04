using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using AdminPortal.Models;

namespace CompanyPortal.Controllers
{

    // GET: Case
    [Authorize]
    public class CaseController : Controller
    {
        // GET: Cases
        public ActionResult Index()
        {
            List<Case> cases = new List<Case>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                string id = User.Identity.GetUserId();
                cases = db.Cases.ToList();
            }
            return View(cases);
        }

        public ActionResult Preview(int id)
        {
            Case case1 = new Case();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                case1 = db.Cases.FirstOrDefault(x => x.ID == id);
            }
            return View(case1);
        }
        [HttpPost]
        public ActionResult Add(CaseViewModel vm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    Case o = new Case();
                    o.Subject = vm.Subject;
                    o.Details = vm.Details;
                    o.Summary = vm.Summary;
                    o.Category = vm.Category;
                    o.Priority = vm.Priority;
                    o.DateCreated = DateTime.Now;
                    o.Requestedby = User.Identity.GetUserId();
                    db.Cases.Add(o);
                    db.SaveChanges();

                    foreach (HttpPostedFileBase f in vm.Attachments)
                    {
                        CaseAttachment x = new CaseAttachment();
                        x.FileName = Path.GetFileName(f.FileName);
                        x.Address = Guid.NewGuid() + Path.GetExtension(x.FileName);
                        string directoryPath = Server.MapPath("~/Uploads/Cases");
                        Directory.CreateDirectory(directoryPath); // Create the directory if it doesn't exist
                        x.Address = Path.Combine(directoryPath, x.Address);
                        x.UploadedBy = User.Identity.GetUserId();
                        x.Type = "Cases";
                        x.TypeID = o.ID;
                        f.SaveAs(x.Address);
                        db.CaseAttachments.Add(x);
                        db.SaveChanges();
                        //utility.SendNotificationByRole(User.Identity.GetUserId(), "Corporate User - Supervisor", "New Case Opened By Fleet User", User.Identity.GetUserName() + " opened new case with  \"Case #" + o.ID.ToString("D4") + "\". Please review and assign analysts.");
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var errors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in errors.ValidationErrors)
                        {
                            // get the error message 
                            string errorMessage = validationError.ErrorMessage;
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Case");
        }
        [HttpGet]
        public ActionResult GetResponses(int CaseID)
        {
            List<CaseResponse> xx = new List<CaseResponse>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = db.CaseResponses.Where(x => x.CaseID == CaseID).OrderByDescending(x => x.DateCreated).ToList();
            }
            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Respond(int CaseID, string Message)
        {
            CaseResponse o = new CaseResponse();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                o.CaseID = CaseID;
                o.Message = Message;
                o.CreatedBy = User.Identity.GetUserId();
                o.DateCreated = DateTime.UtcNow;
                o.MessageFrom = "Admin";
                db.CaseResponses.Add(o);
                db.SaveChanges();
                //Case c = db.Cases.FirstOrDefault(x => x.ID == o.CaseID);
                //if (c.AssignedTo != null || c.AssignedTo != string.Empty)
                //{
                //    utility.SendNotification(User.Identity.GetUserId(), c.AssignedTo, "Case Update", User.Identity.GetUserName() + " sent a message for \"Case #" + o.ID.ToString("D4") + "\"");
                //}
                //else
                //{
                //    string[] corporateUsers = db.Users.Where(x => x.UserRole.Contains("Corporate User - Supervisor")).Select(p => p.Id).ToArray();
                //    foreach (string p in corporateUsers)
                //    {
                //        utility.SendNotification(User.Identity.GetUserId(), p, "Case Update", User.Identity.GetUserName() + " sent a message for \"Case #" + o.ID.ToString("D4") + "\"");
                //    }

                //}
            }
            return Json(o, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetAttachments(int ID)
        {
            List<CaseAttachment> xx = new List<CaseAttachment>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = db.CaseAttachments.Where(x => x.TypeID == ID && x.Type == "Cases").ToList();
            }
            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SetStatus(int CaseID, string Status)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Case o = db.Cases.FirstOrDefault(x => x.ID == CaseID);
                o.Status = Status;
                if (Status == "Closed")
                {
                    //if (o.AssignedTo != null || o.AssignedTo != string.Empty)
                    //{
                    //    utility.SendNotification(User.Identity.GetUserId(), o.AssignedTo, "Case Closed", User.Identity.GetUserName() + " closed \"Case #" + o.ID.ToString("D4") + "\"");
                    //}
                    //else
                    //{
                    //    string[] corporateUsers = db.Users.Where(x => x.UserRole.Contains("Corporate User - Supervisor")).Select(p => p.Id).ToArray();
                    //    foreach (string p in corporateUsers)
                    //    {
                    //        utility.SendNotification(User.Identity.GetUserId(), p, "Case Closed", User.Identity.GetUserName() + " closed \"Case #" + o.ID.ToString("D4") + "\"");
                    //    }

                    //}

                    o.ResolutionDate = DateTime.UtcNow;
                }

                else
                {
                    //utility.SendNotification(User.Identity.GetUserId(), o.AssignedTo, "Case Opened", User.Identity.GetUserName() + " opened \"Case #" + o.ID.ToString("D4") + "\"");
                    o.ResolutionDate = null;
                }
                db.SaveChanges();
            }
            return Json(new { Message = Status }, JsonRequestBehavior.AllowGet);
        }
    }
}