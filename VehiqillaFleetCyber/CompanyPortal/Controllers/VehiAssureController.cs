using CompanyPortal.Helpers;
using CompanyPortal.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Mvc;


namespace VehiQilla.Controllers
{
    [Authorize]
    public class VehiAssureController : Controller
    {
        // GET: VehiAssure
        public ActionResult Apps()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var list = db.ECUApps.Include("Supplier").Include("Category").Where(x => x.IsDeleted == false).OrderByDescending(p => p.ID).ToList();
                return View(list);
            }
        }
        public ActionResult App()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Invite()
        {
            List<VehiAssureInvite> vehiAssureInvites = new List<VehiAssureInvite>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                vehiAssureInvites = db.VehiAssureInvites.Include("Supplier").Include("ECUApp").ToList();
            }
            return View(vehiAssureInvites);
        }  
        [HttpPost]
        public int Invite(int AppID,int SupplierID)
        {
            int count = 0;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    VehiAssureInvite o = new VehiAssureInvite();
                    o.Supplier = db.Suppliers.FirstOrDefault(x=>x.ID==SupplierID);
                    o.ECUApp = db.ECUApps.FirstOrDefault(x=>x.ID== AppID);
                    o.InviteStatus = "Pending";
                    o.IsDeleted = true;
                    o.Token = Guid.NewGuid().ToString("N");
                    o.DateModified = DateTime.UtcNow;
                    o.DateRequested = DateTime.UtcNow;
                    o.RemindedOn = null;
                    Supplier supplier = db.Suppliers.Where(x => x.ID == SupplierID).FirstOrDefault();
                    o.CreatedBy = User.Identity.GetUserId();
                    o.DateCreated = DateTime.UtcNow;
                    o.ModifiedBy = User.Identity.GetUserId();
                    db.VehiAssureInvites.Add(o);
                    db.SaveChanges();

                    Supplier s = db.Suppliers.FirstOrDefault(d => d.ID == o.Supplier.ID);
                    ECUApp a = db.ECUApps.FirstOrDefault(d => d.ID == o.ECUApp.ID);
                    string link = ConfigurationManager.AppSettings["baseUrl"] + "VehiAssure/Assessment?Token=" + o.Token;
                    string image1 = ConfigurationManager.AppSettings["baseUrl"] + "EmailTemplates/image-1.png";
                    string image2 = ConfigurationManager.AppSettings["baseUrl"] + "EmailTemplates/image-3.png";
                    string FilePath = Path.Combine(Server.MapPath("~/App_Data/EmailTemplates/"), "Invite.html");
                    StreamReader str = new StreamReader(FilePath);
                    string MailText = str.ReadToEnd();
                    str.Close();
                    MailText = MailText.Replace("[[link]]", link);
                    MailText = MailText.Replace("[[image1]]", image1);
                    MailText = MailText.Replace("[[image2]]", image2);
                    var status = utility.Email("Vehi Assure Invite", s.ContactDetail, MailText);
                    o.IsDeleted = false;
                    count= db.SaveChanges();
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

            return count;
        }
        public ActionResult Archived()
        {
            return View();
        }
        [HttpGet]
        public ActionResult MinorEdits(int ID)
        {
            VehiAssureQuestionaire d;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                    d = db.VehiAssureQuestionaires.FirstOrDefault(x => x.ID == ID);
            }

            VehiAssureQuestionaireViewModel result = VehiAssureQuestionaireViewModel.ToViewModel(d);
            return View(result);
        }
        [HttpPost]
        public ActionResult MinorEdits(VehiAssureQuestionaire vm)
        {
            VehiAssureQuestionaireViewModel result;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    bool newData = false;
                    VehiAssureQuestionaire o = db.VehiAssureQuestionaires.FirstOrDefault(d => d.ID == vm.ID);
                    if (o == null)
                    {
                        newData = true;
                        o = new VehiAssureQuestionaire();
                        o.Status = false;
                    }
                    o.Name = vm.Name;
                    o.Instructions = vm.Instructions;
                    o.DueInDays = vm.DueInDays;
                  
                    o.ModifiedBy = User.Identity.GetUserId();
                    o.DateModified = DateTime.UtcNow;
                    if (newData == false)
                    {
                        db.SaveChanges();
                    }
                    else
                    {

                        o.CreatedBy = User.Identity.GetUserId();
                        o.DateCreated = DateTime.UtcNow;
                        db.VehiAssureQuestionaires.Add(o);
                        db.SaveChanges();
                    }
                    result = VehiAssureQuestionaireViewModel.ToViewModel(o);
                    return RedirectToAction("MinorEdits/" + o.ID, "VehiAssure");
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
            return View();
        }
        [HttpGet]
        [Route("Categories/Add/{ID?}")]
        public ActionResult Add(int? ID)
        {
            VehiAssureQuestionaire d;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (ID.HasValue)
                    d = db.VehiAssureQuestionaires.FirstOrDefault(x => x.ID == ID);
                else
                    d = new VehiAssureQuestionaire();
            }

            VehiAssureQuestionaireViewModel result = VehiAssureQuestionaireViewModel.ToViewModel(d);
            return View(result);
        }
        [HttpPost]
        public ActionResult Add(VehiAssureQuestionaire vm)
        {
            VehiAssureQuestionaireViewModel result;

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    bool newData = false;
                    VehiAssureQuestionaire o = db.VehiAssureQuestionaires.FirstOrDefault(d => d.ID == vm.ID);
                    if (o == null)
                    {
                        newData = true;
                        o = new VehiAssureQuestionaire();
                        o.Status = false;
                    }
                    o.Name = vm.Name;
                    o.Instructions = vm.Instructions;
                    o.DueInDays = vm.DueInDays;
              
                    o.ModifiedBy = User.Identity.GetUserId();
                    o.DateModified = DateTime.UtcNow;
                    if (newData == false)
                    {
                        db.SaveChanges();
                    }
                    else
                    {

                        o.CreatedBy = User.Identity.GetUserId();
                        o.DateCreated = DateTime.UtcNow;
                        db.VehiAssureQuestionaires.Add(o);
                        db.SaveChanges();
                    }
                    result = VehiAssureQuestionaireViewModel.ToViewModel(o);
                    return RedirectToAction("Add/" + o.ID, "VehiAssure");
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
            return View();
        }
        public ActionResult AssessmentsWaiting()
        {
            List<VehiAssureAssessmentViewModel> xx = new List<VehiAssureAssessmentViewModel>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = (from ass in db.VehiAssureAssessments
                      join app in db.ECUApps on ass.EcuAppID equals app.ID
                      join cat in db.Categories on app.Category.ID equals cat.ID
                      join supp in db.Suppliers on app.Supplier.ID equals supp.ID
                      where ass.Approved == false
                      select new VehiAssureAssessmentViewModel
                      {
                          ID = ass.ID,
                          CategoryName = cat.Name,
                          SupplierName =supp.Name,
                          AppName = app.Name,
                          UUID = ass.UUID,
                          AssessmentDate = ass.AssessmentDate
                      }
                      ).ToList();
                
            }

            return View(xx);
        }
        public ActionResult EditAssessments()
        {
            List<VehiAssureAssessmentViewModel> xx = new List<VehiAssureAssessmentViewModel>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = (from ass in db.VehiAssureAssessments
                      join app in db.ECUApps on ass.EcuAppID equals app.ID
                      join cat in db.Categories on app.Category.ID equals cat.ID
                      join supp in db.Suppliers on app.Supplier.ID equals supp.ID
                      where ass.Approved == true
                      select new VehiAssureAssessmentViewModel
                      {
                          ID = ass.ID,
                          CategoryName = cat.Name,
                          SupplierName = supp.Name,
                          AppName = app.Name,
                          UUID = ass.UUID,
                          AssessmentDate = ass.AssessmentDate
                      }
                      ).ToList();

            }

            return View(xx);
        }
        public ActionResult EditAssessment()
        {

            return View();
        }
        public ActionResult DeleteAssessments()
        {
            List<VehiAssureAssessmentViewModel> xx = new List<VehiAssureAssessmentViewModel>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = (from ass in db.VehiAssureAssessments
                      join app in db.ECUApps on ass.EcuAppID equals app.ID
                      join cat in db.Categories on app.Category.ID equals cat.ID
                      join supp in db.Suppliers on app.Supplier.ID equals supp.ID
                      where ass.Approved == true
                      select new VehiAssureAssessmentViewModel
                      {
                          ID = ass.ID,
                          CategoryName = cat.Name,
                          SupplierName = supp.Name,
                          AppName = app.Name,
                          UUID = ass.UUID,
                          AssessmentDate = ass.AssessmentDate
                      }
                      ).ToList();

            }

            return View(xx);
        }
        [AllowAnonymous]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AssessmentSaveEdits(FormCollection frm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                string uuid = frm["uuid"];
                VehiAssureAssessment va = db.VehiAssureAssessments.FirstOrDefault(x => x.UUID == uuid);
                VehiAssureInvite invite;
                DateTime AssessmentDate = DateTime.UtcNow;
                int QuestionaireID = va.QuestionaireID;
                string token = va.Token;
                invite = db.VehiAssureInvites.FirstOrDefault(x => x.Token == token);
                string UUID = Guid.NewGuid().ToString("N");//va.UUID;
                //List<VehiAssureAssessment> xDelete = db.VehiAssureAssessments.Where(x => x.UUID == uuid).ToList();
                //List<VehiAssureAssessmentCustomField> xDelete2 = db.VehiAssureAssessmentCustomFields.Where(x => x.Token == token).ToList();
                //foreach (VehiAssureAssessment v in xDelete)
                //{
                //    db.VehiAssureAssessments.Remove(v);
                //    db.SaveChanges();
                //}
                //foreach (VehiAssureAssessmentCustomField vx in xDelete2)
                //{
                //    db.VehiAssureAssessmentCustomFields.Remove(vx);
                //    db.SaveChanges();
                //}
                foreach (string key in frm.AllKeys)
                {
                    if (key.Contains("field"))
                    {
                        int id = int.Parse(key.Split('-')[1]);
                        string value = frm[key];
                        VehiAssureAssessmentCustomField field = new VehiAssureAssessmentCustomField();
                        field.AssessmentDate = AssessmentDate;
                        field.EcuAppID = va.EcuAppID;
                        field.SupplierID = va.SupplierID;
                        field.FieldID = id;
                        field.Value = value;
                        field.UUID = UUID;
                        field.Token = va.Token;
                        db.VehiAssureAssessmentCustomFields.Add(field);
                        db.SaveChanges();
                    }
                    if (key.Contains("question"))
                    {
                        string q = key.Split('-')[1];
                        int questionid = int.Parse(q.Split('[')[0]);
                        int optionid = int.Parse(q.Split('[')[1].Replace("]", ""));

                        VehiAssureAssessment question = new VehiAssureAssessment();
                        question.UUID = UUID;
                        question.Approved = false;
                        question.AssessmentDate = AssessmentDate;
                        question.EcuAppID = va.EcuAppID;
                        question.SupplierID = va.SupplierID;
                        question.Token = va.Token;
                        question.QuestionaireID = QuestionaireID;
                        question.QuestionID = questionid;
                        question.OptionID = optionid;
                        question.Remarks = string.Empty; //to be filled
                        db.VehiAssureAssessments.Add(question);
                        db.SaveChanges();
                    }
                    if (key.Contains("remarks"))
                    {
                        int questionid = int.Parse(key.Split('-')[1]);
                        VehiAssureAssessment question = db.VehiAssureAssessments.FirstOrDefault(x => x.Token == token && x.QuestionID == questionid);
                        question.Remarks = frm[key];
                        db.SaveChanges();
                    }

                }
            }

            return RedirectToAction("EditAssessments", "VehiAssure");
        }
        [Route("VehiAssure/GetRequiredFieldsForEdit")]
        public ActionResult GetRequiredFieldsForEdit(string UUID)
        {
            List<VehiAssureQuestionaireCustomFieldViewModel> xx = new List<VehiAssureQuestionaireCustomFieldViewModel>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = xx = (from c in db.VehiAssureAssessmentCustomFields
                           join F in db.VehiAssureQuestionaireCustomFields on c.FieldID equals F.ID
                           where c.UUID == UUID
                           select new VehiAssureQuestionaireCustomFieldViewModel
                           {
                               ID = F.ID,
                               Field = F.Field,
                               Value = c.Value
                           }
                     ).ToList(); ;
            }
            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetQuestionaires(bool type)
        {
            List<VehiAssureQuestionaire> xx = new List<VehiAssureQuestionaire>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = db.VehiAssureQuestionaires.Where(x=>x.Status==type).ToList();
            }

            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetResponses(int ID)
        {
            int xx ;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = db.VehiAssureAssessments.Where(x => x.QuestionaireID == ID).GroupBy(p=>p.UUID).Count();
            }

            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EnableQuestionaire(int ID)
        {
            List<VehiAssureQuestionaire> xx = new List<VehiAssureQuestionaire>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = db.VehiAssureQuestionaires.ToList();
                foreach(VehiAssureQuestionaire x in xx)
                {
                    if (x.ID != ID)
                    {
                        x.Status = false;
                        db.SaveChanges();
                    }
                    else
                    {
                        x.Status = true;
                        db.SaveChanges();
                    }
                }
                xx = db.VehiAssureQuestionaires.Where(x => x.Status == false).ToList();
            }

            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult LoadCustomFields(int ID)
        {
            List<VehiAssureQuestionaireCustomField> xx = new List<VehiAssureQuestionaireCustomField>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = db.VehiAssureQuestionaireCustomFields.Where(x => x.VehiAssureQuestionaireID == ID).ToList();
            }

            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult LoadQuestionaireByID(int ID)
        {
            List<Group> Groups = new List<Group>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<VehiAssureQuestionGroup> VehiAssureQuestionGroups = db.VehiAssureQuestionGroups.Where(x => x.VehiAssureQuestionaireID == ID).ToList();

                foreach (VehiAssureQuestionGroup VehiAssureQuestionGroup in VehiAssureQuestionGroups)
                {
                    List<Question> Questions = new List<Question>();
                    Group Group = new Group();
                    Group.id = VehiAssureQuestionGroup.ID;
                    Group.name = VehiAssureQuestionGroup.Name;
                    Group.maxScore = VehiAssureQuestionGroup.MaxScore;
                    Group.threshold = VehiAssureQuestionGroup.Threshold;
                    List<VehiAssureQuestion> VehiAssureQuestions = db.VehiAssureQuestions.Where(x => x.VehiAssureQuestionGroupID == VehiAssureQuestionGroup.ID).ToList();
                    foreach (VehiAssureQuestion VehiAssureQuestion in VehiAssureQuestions)
                    {
                        Question Question = new Question();
                        Question.id = VehiAssureQuestion.ID;
                        Question.name = VehiAssureQuestion.Name;
                        Question.questionScore = VehiAssureQuestion.Score;
                        Question.type = VehiAssureQuestion.Type;
                        List<Option> Options = new List<Option>();
                        List<VehiAssureQuestionOption> VehiAssureQuestionOptions = db.VehiAssureQuestionOptions.Where(x => x.VehiAssureQuestionID == VehiAssureQuestion.ID).ToList();
                        foreach (VehiAssureQuestionOption VehiAssureQuestionOption in VehiAssureQuestionOptions)
                        {
                            Option Option = new Option();
                            Option.id = VehiAssureQuestionOption.ID;
                            Option.name = VehiAssureQuestionOption.Name;
                            Option.score = VehiAssureQuestionOption.Score;
                            Options.Add(Option);

                        }
                        Question.options = Options;
                        Questions.Add(Question);

                    }
                    Group.questions = Questions;
                    Groups.Add(Group);
                }
            }

            return Json(Groups, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveCustomFields(int ID, CustomFieldsViewModel[] field)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    List<VehiAssureQuestionaireCustomField> xx = new List<VehiAssureQuestionaireCustomField>();
                    xx = db.VehiAssureQuestionaireCustomFields.Where(x => x.VehiAssureQuestionaireID == ID).ToList();
                    db.VehiAssureQuestionaireCustomFields.RemoveRange(xx);
                    foreach (CustomFieldsViewModel x in field)
                    {
                        VehiAssureQuestionaireCustomField o = new VehiAssureQuestionaireCustomField();
                        o.VehiAssureQuestionaireID = ID;
                        o.Field = x.field;
                        db.VehiAssureQuestionaireCustomFields.Add(o);
                        db.SaveChanges();
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
                            return Json(new { Message = errorMessage }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }

            return Json(new { Message = "Success" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveQuestionaire(int ID, Group[] Groups)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    //Delete Existing Data
                    List<VehiAssureQuestionGroup> groups = db.VehiAssureQuestionGroups.Where(x => x.VehiAssureQuestionaireID == ID).ToList();
                    foreach (VehiAssureQuestionGroup x in groups)
                    {
                        List<VehiAssureQuestion> questions = db.VehiAssureQuestions.Where(r => r.VehiAssureQuestionGroupID == x.ID).ToList();

                        foreach (VehiAssureQuestion y in questions)
                        {
                            List<VehiAssureQuestionOption> options = db.VehiAssureQuestionOptions.Where(r => r.VehiAssureQuestionID == y.ID).ToList();
                            db.VehiAssureQuestionOptions.RemoveRange(options);
                        }

                        db.VehiAssureQuestions.RemoveRange(questions);
                    }
                    db.VehiAssureQuestionGroups.RemoveRange(groups);
                    db.SaveChanges();


                    foreach (Group x in Groups)
                    {
                        VehiAssureQuestionGroup group = new VehiAssureQuestionGroup();
                        group.VehiAssureQuestionaireID = ID;
                        group.Name = x.name;
                        group.MaxScore = x.maxScore;
                        group.Threshold = x.threshold;
                        db.VehiAssureQuestionGroups.Add(group);
                        db.SaveChanges();
                        foreach (Question y in x.questions)
                        {
                            VehiAssureQuestion question = new VehiAssureQuestion();
                            question.VehiAssureQuestionGroupID = group.ID;
                            question.Name = y.name;
                            question.Type = y.type;
                            question.Score = y.questionScore;
                            db.VehiAssureQuestions.Add(question);
                            db.SaveChanges();
                            foreach (Option z in y.options)
                            {
                                VehiAssureQuestionOption option = new VehiAssureQuestionOption();
                                option.VehiAssureQuestionID = question.ID;
                                option.Name = z.name;
                                option.Score = z.score;
                                if (question.Type == "Multi-Select")
                                {
                                    option.Score = z.score;
                                }
                                else
                                {
                                    if (z.score.ToString() == "false" || z.score.ToString() == "0")
                                    {
                                        option.Score = 0;
                                    }
                                    else
                                    {
                                        option.Score = question.Score;
                                    }
                                }
                                db.VehiAssureQuestionOptions.Add(option);
                                db.SaveChanges();
                            }
                        }


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
                            return Json(new { Message = errorMessage }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }

            return Json(new { Message = "Success" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveMinorEdits(int ID, Group[] Groups)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    foreach (Group x in Groups)
                    {
                        VehiAssureQuestionGroup group = db.VehiAssureQuestionGroups.SingleOrDefault(z=>z.ID == x.id);
                        group.VehiAssureQuestionaireID = ID;
                        group.Name = x.name;
                        group.MaxScore = x.maxScore;
                        group.Threshold = x.threshold;
                        db.SaveChanges();
                        foreach (Question y in x.questions)
                        {
                            VehiAssureQuestion question =  db.VehiAssureQuestions.SingleOrDefault(z => z.ID == y.id);
                            question.VehiAssureQuestionGroupID = group.ID;
                            question.Name = y.name;
                            question.Score = y.questionScore;
                            db.SaveChanges();
                            foreach (Option z in y.options)
                            {
                                VehiAssureQuestionOption option = db.VehiAssureQuestionOptions.SingleOrDefault(zz => zz.ID == z.id);
                                option.VehiAssureQuestionID = question.ID;
                                option.Name = z.name;
                                option.Score = z.score;
                                if (question.Type == "Multi-Select")
                                {
                                    option.Score = z.score;
                                }
                                else
                                {
                                    if (z.score.ToString() == "false" || z.score.ToString() == "0")
                                    {
                                        option.Score = 0;
                                    }
                                    else
                                    {
                                        option.Score = question.Score;
                                    }
                                }
                                db.SaveChanges();
                            }
                        }


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
                            return Json(new { Message = errorMessage }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }

            return Json(new { Message = "Success" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveMinorEditsCustomFields(int ID, CustomFieldsViewModel[] field)
        {

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                try
                {
                    foreach (CustomFieldsViewModel x in field)
                    {
                        VehiAssureQuestionaireCustomField o = db.VehiAssureQuestionaireCustomFields.FirstOrDefault(xx=>xx.ID==x.id);
                        o.VehiAssureQuestionaireID = ID;
                        o.Field = x.field;
                        db.SaveChanges();
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
                            return Json(new { Message = errorMessage }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
            }

            return Json(new { Message = "Success" }, JsonRequestBehavior.AllowGet);
        }


        #region PublicFacingAssessment
        [AllowAnonymous]
        public ActionResult Assessment(string token)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VehiAssureInvite d = db.VehiAssureInvites.FirstOrDefault(x => x.Token == token);
                VehiAssureQuestionaire q = db.VehiAssureQuestionaires.FirstOrDefault(x => x.Status == true);


                if (d == null || d.DateCreated.AddDays(q.DueInDays) < DateTime.Now)
                {
                    return RedirectToAction("InvalidToken", "VehiAssure");
                }
                else
                {
                    VehiAssureAssessment xxx = db.VehiAssureAssessments.FirstOrDefault(x => x.Token == token);
                    if (xxx != null)
                    {
                        return RedirectToAction("ThankYou", "VehiAssure");
                    }
                }
            }

            return View();
        }
        [AllowAnonymous]
        [AcceptVerbs(HttpVerbs.Post)] //Public Facing Assessment Saved Here
        public ActionResult Assessment(FormCollection frm)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {


                VehiAssureInvite invite;
                DateTime AssessmentDate = DateTime.UtcNow;
                int QuestionaireID = int.Parse(frm["QuestionaireID"]);
                string token = frm["token"];
                invite = db.VehiAssureInvites.Include("Supplier").Include("EcuApp").FirstOrDefault(x => x.Token == token);
                string UUID = Guid.NewGuid().ToString("N");
                foreach (string key in frm.AllKeys)
                {
                    if (key.Contains("field"))
                    {
                        int id = int.Parse(key.Split('-')[1]);
                        string value = frm[key];
                        VehiAssureAssessmentCustomField field = new VehiAssureAssessmentCustomField();
                        field.AssessmentDate = AssessmentDate;
                        field.EcuAppID = invite.ECUApp.ID;
                        field.SupplierID = invite.Supplier.ID;
                        field.FieldID = id;
                        field.Value = value;
                        field.Token = invite.Token;
                        field.UUID = UUID;
                        db.VehiAssureAssessmentCustomFields.Add(field);
                        db.SaveChanges();
                    }
                    if (key.Contains("question"))
                    {
                        string q = key.Split('-')[1];
                        int questionid = int.Parse(q.Split('[')[0]);
                        int optionid = int.Parse(q.Split('[')[1].Replace("]", ""));

                        VehiAssureAssessment question = new VehiAssureAssessment();
                        question.UUID = UUID;
                        question.Approved = false;
                        question.AssessmentDate = AssessmentDate;
                        question.EcuAppID = invite.ECUApp.ID;
                        question.SupplierID = invite.Supplier.ID;
                        question.Token = invite.Token;
                        question.QuestionaireID = QuestionaireID;
                        question.QuestionID = questionid;
                        question.OptionID = optionid;
                        question.Remarks = string.Empty; //to be filled
                        db.VehiAssureAssessments.Add(question);
                        db.SaveChanges();
                    }
                    if (key.Contains("remarks"))
                    {
                        int questionid = int.Parse(key.Split('-')[1]);
                        VehiAssureAssessment question = db.VehiAssureAssessments.FirstOrDefault(x => x.Token == token && x.QuestionID == questionid);
                        question.Remarks = frm[key];
                        db.SaveChanges();
                    }

                }
            }

            return RedirectToAction("ThankYou", "VehiAssure");
        }
        [AllowAnonymous]
        public ActionResult InvalidToken(string token)
        {

            return View();
        }
        [AllowAnonymous]
        public ActionResult ThankYou(string token)
        {

            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("VehiAssure/GetQuestionaireData")]
        public ActionResult GetQuestionaireData()
        {
            VehiAssureQuestionaire xx = new VehiAssureQuestionaire();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = db.VehiAssureQuestionaires.Where(x => x.Status == true).FirstOrDefault();
            }
            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("VehiAssure/GetRequiredFields")]
        public ActionResult GetRequiredFields(int ID)
        {
            List<VehiAssureQuestionaireCustomField> xx = new List<VehiAssureQuestionaireCustomField>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = db.VehiAssureQuestionaireCustomFields.Where(x => x.VehiAssureQuestionaireID == ID).ToList();
            }
            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult LoadQuestionaire()
        {

            List<Group> Groups = new List<Group>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VehiAssureQuestionaire qx = db.VehiAssureQuestionaires.Where(x => x.Status == true).FirstOrDefault();
                int ID = qx.ID;
                List<VehiAssureQuestionGroup> VehiAssureQuestionGroups = db.VehiAssureQuestionGroups.Where(x => x.VehiAssureQuestionaireID == ID).ToList();

                foreach (VehiAssureQuestionGroup VehiAssureQuestionGroup in VehiAssureQuestionGroups)
                {
                    List<Question> Questions = new List<Question>();
                    Group Group = new Group();
                    Group.id = VehiAssureQuestionGroup.ID;
                    Group.name = VehiAssureQuestionGroup.Name;
                    Group.threshold = VehiAssureQuestionGroup.Threshold;
                    List<VehiAssureQuestion> VehiAssureQuestions = db.VehiAssureQuestions.Where(x => x.VehiAssureQuestionGroupID == VehiAssureQuestionGroup.ID).ToList();
                    foreach (VehiAssureQuestion VehiAssureQuestion in VehiAssureQuestions)
                    {
                        Question Question = new Question();
                        Question.id = VehiAssureQuestion.ID;
                        Question.name = VehiAssureQuestion.Name;
                        Question.type = VehiAssureQuestion.Type;
                        List<Option> Options = new List<Option>();
                        List<VehiAssureQuestionOption> VehiAssureQuestionOptions = db.VehiAssureQuestionOptions.Where(x => x.VehiAssureQuestionID == VehiAssureQuestion.ID).ToList();
                        foreach (VehiAssureQuestionOption VehiAssureQuestionOption in VehiAssureQuestionOptions)
                        {
                            Option Option = new Option();
                            Option.id = VehiAssureQuestionOption.ID;
                            Option.name = VehiAssureQuestionOption.Name;
                            Option.score = VehiAssureQuestionOption.Score;
                            Options.Add(Option);
                        }
                        Question.options = Options;
                        Questions.Add(Question);

                    }
                    Group.questions = Questions;
                    Groups.Add(Group);
                }
            }

            return Json(Groups, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AssessmentReview
        public ActionResult AssessmentsWaitingForReview()
        {
            return View();
        }
        public ActionResult AssessmentReview(string UUID)
        {
            return View();
        }
        [HttpGet]
        [Route("VehiAssure/GetAssessmentsWating")]
        public ActionResult GetAssessmentsWatingForReview()
        {
            List<VehiAssureAssessmentViewModel> xx = new List<VehiAssureAssessmentViewModel>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                xx = db.Database.SqlQuery<VehiAssureAssessmentViewModel>("GetAssessmentsWatingForReview").ToList();
            }
            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ApproveAssessmentAfterReview(string UUID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VehiAssureAssessment va = db.VehiAssureAssessments.FirstOrDefault(x => x.UUID == UUID);
                (from v in db.VehiAssureAssessments
                 where v.UUID == UUID
                 select v).ToList().ForEach(x => x.Reviewed = true );
                VehiAssureAssessment va1 = db.VehiAssureAssessments.FirstOrDefault(x => x.UUID == UUID);
                (from v in db.VehiAssureAssessments
                 where v.UUID == UUID
                 select v).ToList().ForEach(x => x.Approved = true);
                db.SaveChanges();
            }
            return Json(new { Message = "Success", RedirectUrl = "/VehiAssure/AssessmentsWaiting" }, JsonRequestBehavior.AllowGet);
            // return Content("<html><script>window.location.href = '/VehiAssure/AssessmentsWating';</script></html>"); //RedirectToAction("GetAssessmentsWating", "VehiAssure");
        }
        [HttpGet]
        public ActionResult DenyAssessmentAfterReview(string UUID)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<VehiAssureAssessment> va = db.VehiAssureAssessments.Where(x => x.UUID == UUID).ToList();
                List<VehiAssureAssessmentCustomField> vb = db.VehiAssureAssessmentCustomFields.Where(x => x.UUID == UUID).ToList();
                db.VehiAssureAssessments.RemoveRange(va);
                db.VehiAssureAssessmentCustomFields.RemoveRange(vb);
                db.SaveChanges();
            }
            return Json(new { Message = "Success", RedirectUrl = "/VehiAssure/AssessmentsWaiting" }, JsonRequestBehavior.AllowGet);

        }
        #endregion


        #region GeneralHelpers
        [HttpGet]
        public ActionResult GetAppByUUID(string UUID)
        {
            List<AppViewModel> xx = new List<AppViewModel>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@UUID", SqlDbType.NVarChar);
                param[0].Value = (string)UUID;
                xx = db.Database.SqlQuery<AppViewModel>("GetAppDetailsAssessmentReview @UUID", param).ToList();
            }
            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult LoadQuestionaireByUUID(string UUID)
        {
            List<Group> Groups = new List<Group>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<VehiAssureAssessment> VehiAssureAssessments = new List<VehiAssureAssessment>();
                VehiAssureAssessments = db.VehiAssureAssessments.Where(x => x.UUID == UUID).ToList();
                VehiAssureAssessment va = db.VehiAssureAssessments.FirstOrDefault(x => x.UUID == UUID);
                VehiAssureQuestionaire qx = db.VehiAssureQuestionaires.Where(x => x.ID == va.QuestionaireID).FirstOrDefault();
                int ID = qx.ID;
                List<VehiAssureQuestionGroup> VehiAssureQuestionGroups = db.VehiAssureQuestionGroups.Where(x => x.VehiAssureQuestionaireID == ID).ToList();
                foreach (VehiAssureQuestionGroup VehiAssureQuestionGroup in VehiAssureQuestionGroups)
                {
                    List<Question> Questions = new List<Question>();
                    Group Group = new Group();
                    Group.id = VehiAssureQuestionGroup.ID;
                    Group.name = VehiAssureQuestionGroup.Name;
                    Group.threshold = VehiAssureQuestionGroup.Threshold;
                    List<VehiAssureQuestion> VehiAssureQuestions = db.VehiAssureQuestions.Where(x => x.VehiAssureQuestionGroupID == VehiAssureQuestionGroup.ID).ToList();
                    foreach (VehiAssureQuestion VehiAssureQuestion in VehiAssureQuestions)
                    {
                        Question Question = new Question();
                        Question.id = VehiAssureQuestion.ID;
                        Question.name = VehiAssureQuestion.Name;
                        Question.type = VehiAssureQuestion.Type;
                        VehiAssureAssessment r = VehiAssureAssessments.FirstOrDefault(x => x.QuestionID == Question.id && x.Remarks != string.Empty);
                        Question.Remarks = r == null ? "" : r.Remarks;
                        List<Option> Options = new List<Option>();
                        List<VehiAssureQuestionOption> VehiAssureQuestionOptions = db.VehiAssureQuestionOptions.Where(x => x.VehiAssureQuestionID == VehiAssureQuestion.ID).ToList();
                        foreach (VehiAssureQuestionOption VehiAssureQuestionOption in VehiAssureQuestionOptions)
                        {
                            Option Option = new Option();
                            Option.id = VehiAssureQuestionOption.ID;
                            Option.name = VehiAssureQuestionOption.Name;
                            Option.score = VehiAssureQuestionOption.Score;
                            Option.selected = VehiAssureAssessments.Any(x => x.OptionID == Option.id); // checl if option is selected
                            Options.Add(Option);
                        }
                        Question.options = Options;
                        Questions.Add(Question);

                    }
                    Group.questions = Questions;
                    Groups.Add(Group);
                }
            }
            return Json(Groups, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult LoadQuestionsByUUID(string UUID, int GroupID)
        {
            List<Question> Questions = new List<Question>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<VehiAssureAssessment> VehiAssureAssessments = new List<VehiAssureAssessment>();
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@UUID", SqlDbType.NVarChar);
                param[1] = new SqlParameter("@GroupID", SqlDbType.Int);
                param[0].Value = UUID;
                param[1].Value = GroupID;
                VehiAssureAssessments = db.Database.SqlQuery<VehiAssureAssessment>("GetSelectedOptionsByUUID @UUID,@GroupID", param).ToList();


                VehiAssureQuestionaire qx = db.VehiAssureQuestionaires.Where(x => x.Status == true).FirstOrDefault();
                int ID = qx.ID;

                List<VehiAssureQuestion> VehiAssureQuestions = db.VehiAssureQuestions.Where(x => x.VehiAssureQuestionGroupID == GroupID).ToList();
                foreach (VehiAssureQuestion VehiAssureQuestion in VehiAssureQuestions)
                {
                    Question Question = new Question();
                    Question.id = VehiAssureQuestion.ID;
                    Question.name = VehiAssureQuestion.Name;
                    Question.type = VehiAssureQuestion.Type;
                    List<Option> Options = new List<Option>();
                    List<VehiAssureQuestionOption> VehiAssureQuestionOptions = db.VehiAssureQuestionOptions.Where(x => x.VehiAssureQuestionID == VehiAssureQuestion.ID).ToList();
                    foreach (VehiAssureQuestionOption VehiAssureQuestionOption in VehiAssureQuestionOptions)
                    {
                        Option Option = new Option();
                        Option.id = VehiAssureQuestionOption.ID;
                        Option.name = VehiAssureQuestionOption.Name;
                        Option.score = VehiAssureQuestionOption.Score;
                        Option.selected = VehiAssureAssessments.Any(x => x.OptionID == Option.id); // check if option is selected
                        Options.Add(Option);
                    }
                    Question.options = Options;
                    Questions.Add(Question);

                }
            }

            return Json(Questions, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [HttpGet]
        public JsonResult GetApp(int ID)
        {
            List<EcuAppViewModel> xx = new List<EcuAppViewModel>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@AppID", SqlDbType.Int);

                param[0].Value = ID;

                xx = db.Database.SqlQuery<EcuAppViewModel>("GetAppAssessment @AppID", param).ToList();
            }
            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetChart(int ID)
        {
            List<Chart> xx = new List<Chart>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@AppID", SqlDbType.Int);

                param[0].Value = ID;

                xx = db.Database.SqlQuery<Chart>("GetAssessmentChart @AppID", param).ToList();
            }
            return Json(xx, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult LoadQuestionaire(int AppID)
        {

            List<Group> Groups = new List<Group>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VehiAssureAssessment qx = db.VehiAssureAssessments.OrderByDescending(t => t.AssessmentDate).FirstOrDefault();
                int ID = qx.QuestionaireID;
                List<VehiAssureQuestionGroup> VehiAssureQuestionGroups = db.VehiAssureQuestionGroups.Where(x => x.VehiAssureQuestionaireID == ID).ToList();

                foreach (VehiAssureQuestionGroup VehiAssureQuestionGroup in VehiAssureQuestionGroups)
                {
                    List<Question> Questions = new List<Question>();
                    Group Group = new Group();
                    Group.id = VehiAssureQuestionGroup.ID;
                    Group.name = VehiAssureQuestionGroup.Name;
                    Group.threshold = VehiAssureQuestionGroup.Threshold;
                    Group.maxScore = VehiAssureQuestionGroup.MaxScore;
                    List<VehiAssureQuestion> VehiAssureQuestions = db.VehiAssureQuestions.Where(x => x.VehiAssureQuestionGroupID == VehiAssureQuestionGroup.ID).ToList();
                    foreach (VehiAssureQuestion VehiAssureQuestion in VehiAssureQuestions)
                    {
                        Question Question = new Question();
                        Question.id = VehiAssureQuestion.ID;
                        Question.name = VehiAssureQuestion.Name;
                        Question.type = VehiAssureQuestion.Type;
                        List<Option> Options = new List<Option>();
                        List<VehiAssureQuestionOption> VehiAssureQuestionOptions = db.VehiAssureQuestionOptions.Where(x => x.VehiAssureQuestionID == VehiAssureQuestion.ID).ToList();
                        foreach (VehiAssureQuestionOption VehiAssureQuestionOption in VehiAssureQuestionOptions)
                        {
                            Option Option = new Option();
                            Option.id = VehiAssureQuestionOption.ID;
                            Option.name = VehiAssureQuestionOption.Name;
                            Option.score = VehiAssureQuestionOption.Score;
                            Options.Add(Option);
                        }
                        Question.options = Options;
                        Questions.Add(Question);

                    }
                    Group.questions = Questions;
                    Groups.Add(Group);
                }
            }

            return Json(Groups, JsonRequestBehavior.AllowGet);
        }
        public class Chart
        {
            public DateTime AssessmentDate { set; get; }
            public int Score { set; get; }
        }
        [HttpGet]
        public ActionResult LoadQuestionaireByAppID(int AppID)
        {

            List<Group> Groups = new List<Group>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                VehiAssureAssessment qx = db.VehiAssureAssessments.OrderByDescending(t => t.AssessmentDate).FirstOrDefault();
                int ID = qx.QuestionaireID;
                List<VehiAssureQuestionGroup> VehiAssureQuestionGroups = db.VehiAssureQuestionGroups.Where(x => x.VehiAssureQuestionaireID == ID).ToList();

                foreach (VehiAssureQuestionGroup VehiAssureQuestionGroup in VehiAssureQuestionGroups)
                {
                    List<Question> Questions = new List<Question>();
                    Group Group = new Group();
                    Group.id = VehiAssureQuestionGroup.ID;
                    Group.name = VehiAssureQuestionGroup.Name;
                    Group.threshold = VehiAssureQuestionGroup.Threshold;
                    Group.maxScore = VehiAssureQuestionGroup.MaxScore;
                    List<VehiAssureQuestion> VehiAssureQuestions = db.VehiAssureQuestions.Where(x => x.VehiAssureQuestionGroupID == VehiAssureQuestionGroup.ID).ToList();
                    foreach (VehiAssureQuestion VehiAssureQuestion in VehiAssureQuestions)
                    {
                        Question Question = new Question();
                        Question.id = VehiAssureQuestion.ID;
                        Question.name = VehiAssureQuestion.Name;
                        Question.type = VehiAssureQuestion.Type;
                        List<Option> Options = new List<Option>();
                        List<VehiAssureQuestionOption> VehiAssureQuestionOptions = db.VehiAssureQuestionOptions.Where(x => x.VehiAssureQuestionID == VehiAssureQuestion.ID).ToList();
                        foreach (VehiAssureQuestionOption VehiAssureQuestionOption in VehiAssureQuestionOptions)
                        {
                            Option Option = new Option();
                            Option.id = VehiAssureQuestionOption.ID;
                            Option.name = VehiAssureQuestionOption.Name;
                            Option.score = VehiAssureQuestionOption.Score;
                            Options.Add(Option);
                        }
                        Question.options = Options;
                        Questions.Add(Question);

                    }
                    Group.questions = Questions;
                    Groups.Add(Group);
                }
            }

            return Json(Groups, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadQuestions(int AppID, int GroupID)
        {
            List<Question> Questions = new List<Question>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<VehiAssureAssessment> VehiAssureAssessments = new List<VehiAssureAssessment>();
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@AppID", SqlDbType.Int);
                param[1] = new SqlParameter("@GroupID", SqlDbType.Int);
                param[0].Value = AppID;
                param[1].Value = GroupID;
                VehiAssureAssessments = db.Database.SqlQuery<VehiAssureAssessment>("GetSelectedOptions @AppID,@GroupID", param).ToList();


                VehiAssureQuestionaire qx = db.VehiAssureQuestionaires.Where(x => x.Status == true).FirstOrDefault();
                int ID = qx.ID;

                List<VehiAssureQuestion> VehiAssureQuestions = db.VehiAssureQuestions.Where(x => x.VehiAssureQuestionGroupID == GroupID).ToList();
                foreach (VehiAssureQuestion VehiAssureQuestion in VehiAssureQuestions)
                {
                    Question Question = new Question();
                    Question.id = VehiAssureQuestion.ID;
                    Question.name = VehiAssureQuestion.Name;
                    Question.type = VehiAssureQuestion.Type;
                    List<Option> Options = new List<Option>();
                    List<VehiAssureQuestionOption> VehiAssureQuestionOptions = db.VehiAssureQuestionOptions.Where(x => x.VehiAssureQuestionID == VehiAssureQuestion.ID).ToList();
                    foreach (VehiAssureQuestionOption VehiAssureQuestionOption in VehiAssureQuestionOptions)
                    {
                        Option Option = new Option();
                        Option.id = VehiAssureQuestionOption.ID;
                        Option.name = VehiAssureQuestionOption.Name;
                        Option.score = VehiAssureQuestionOption.Score;
                        Option.selected = VehiAssureAssessments.Any(x => x.OptionID == Option.id); // checl if option is selected
                        Options.Add(Option);
                    }
                    Question.options = Options;
                    Questions.Add(Question);

                }
            }

            return Json(Questions, JsonRequestBehavior.AllowGet);
        }
    }
}