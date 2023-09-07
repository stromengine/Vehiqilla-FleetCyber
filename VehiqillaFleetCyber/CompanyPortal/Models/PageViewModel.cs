

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web;
namespace CompanyPortal.Models
{

    public class NameValue
    {
        public int? ID { set; get; }
        public string StringID { set; get; }
        public string Name { set; get; }

        public string Value { set; get; }

        public static string Serialize(NameValue data)
        {
            string json = new JavaScriptSerializer().Serialize(data);
            return json;
        }

        public static NameValue Deserialize(string Json)
        {
            NameValue NM = null;
            try
            {
                NM = new JavaScriptSerializer().Deserialize<NameValue>(Json);
            }
            catch
            {
                NM = null;
            }
            return NM;
        }
    }
    [NotMapped]
    public class CompanyViewModel : Company
    {

    }
    [NotMapped]
    public class FindingViewModel : Finding
    {
        public string Fleet { get; set; }
        public string Vehicle { get; set; }
        public string FindingNo { get; set; }
        public string CyberRiskType
        {
            get
            {
                using(ApplicationDbContext db = new ApplicationDbContext())
                {
                    return db.CyberRiskTypes.Where(x=>x.ID==CyberRiskTypeID).Select(p=>p.Name).First();
                }
            }
        }

    }
    [NotMapped]
    public class CategoryViewModel : Category
    {

    }
    [NotMapped]
    public class SupplierViewModel : Supplier
    {
        public bool Selected
        {
            get
            {
                using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
                {
                    AccessList o = db.AccessLists.FirstOrDefault(x => x.Type == "Supplier" && x.ItemID == ID);
                    if (o != null)
                        return true;

                    else
                        return false;
                }
            }
        }
    }
    [NotMapped]
    public class OemViewModel : Oem
    {

    }
    [NotMapped]
    public class AppViewModel : ECUApp
    {
        public int Category_ID { get; set; }
        public int Company_ID { get; set; }
        public int Oem_ID { get; set; }
        public int Supplier_ID { get; set; }

        public string CategoryName { set; get; }
        public string SupplierName { set; get; }
        public string Logo { set; get; }
        public int Score { set; get; }
        public DateTime AssessmentDate { set; get; }

        public bool Selected
        {
            get
            {
                using (ApplicationDbContext db = new ApplicationDbContext("CompanyConnection"))
                {
                    AccessList o = db.AccessLists.FirstOrDefault(x => x.Type == "App" && x.ItemID == ID);
                    if (o != null)
                        return true;

                    else
                        return false;
                }
            }
        }

        public bool MappedToVehicle
        {
            get; set;

        }

    }
    [NotMapped]
    public class EcuAppViewModel
    {
        public int Category_ID { get; set; }
        public int Company_ID { get; set; }
        public int Oem_ID { get; set; }
        public int Supplier_ID { get; set; }

        public int ID { set; get; }
        public string Name { set; get; }
        public string CategoryName { set; get; }
        public string SupplierName { set; get; }
        public string Logo { set; get; }
        public string FilePath { set; get; }
        public string Description { set; get; }
        public int Score { set; get; }
        public int Breaches { set; get; }
        public int Vulnerabilities { set; get; }
        public DateTime AssessmentDate { set; get; }
        public DateTime DateCreated { set; get; }



    }
    [NotMapped]
    public class VulnerabilityViewModel : AppVulnerability
    {
        public int EcuApp_ID { get; set; }
    }
    [NotMapped]
    public class BreachViewModel : AppBreach
    {
        public int EcuApp_ID { get; set; }
    }

    [NotMapped]
    public class VehiAssureInviteViewModel : VehiAssureInvite
    {
        public int EcuApp_ID { get; set; }
        public int Supplier_ID { get; set; }
    }

    [NotMapped]
    public class KnowledgerCenterViewModel : KnowledgeCenter
    {

    }


    public class CustomFieldsViewModel
    {
        public string field { set; get; }
        public int id { set; get; }
    }
    public class Option
    {
        public string name { set; get; }
        public int score { set; get; }
        public int? id { set; get; }
        public bool selected { set; get; }
    }

    public class Question
    {
        public string name { set; get; }
        public List<Option> options { set; get; }
        public int questionScore { set; get; }
        public int? id { set; get; }
        public string type { set; get; }
        public string Remarks { set; get; }
    }

    public class Group
    {
        public string name { set; get; }
        public int threshold { set; get; }
        public int maxScore { set; get; }
        public int? id { set; get; }

        public List<Question> questions { set; get; }
    }
    public class VehiAssureQuestionaireViewModel
    {
        public int ID { set; get; }
        [Display(Name = "Name")]
        public string Name { set; get; }
        [Display(Name = "Instructions")]
        public string Instructions { set; get; }
        [Display(Name = "Due In Days")]
        public int DueInDays { set; get; }
        [Display(Name = "Status")]
        public bool Status { set; get; }

        public static VehiAssureQuestionaireViewModel ToViewModel(VehiAssureQuestionaire x)
        {
            VehiAssureQuestionaireViewModel y = new VehiAssureQuestionaireViewModel();
            y.ID = x.ID;
            y.Name = x.Name;
            y.Instructions = x.Instructions;
            y.DueInDays = x.DueInDays;
            y.Status = x.Status;
            return y;
        }

    }
    public class VehiAssureQuestionaireCustomFieldViewModel
    {
        [Required]
        public int ID { set; get; }
        [Required]
        public int VehiAssureQuestionaireID { set; get; }
        [Required]
        public string Field { set; get; }
        public string Value { set; get; }
    }
    public class VehiAssureAssessmentViewModel
    {
        public int ID { set; get; }
        public string UUID { set; get; }
        public DateTime AssessmentDate { set; get; }
        public string Token { set; get; }
        public int SupplierID { set; get; }
        public int EcuAppID { set; get; }
        public int QuestionaireID { set; get; }
        public int QuestionID { set; get; }
        public int OptionID { set; get; }
        public string Remarks { set; get; }
        public string AppName { set; get; }
        public string SupplierName { set; get; }
        public string CategoryName { set; get; }
        public bool Approved { set; get; }
    }

    [NotMapped]
    public class FleetViewModel : Fleet
    {

    }
    [NotMapped]
    public class VehicleViewModel : Vehicle
    {
        public int Fleet_ID { set; get; }
    }
    [NotMapped]
    public class MegaReport
    {
        public string Fleet { set; get; }
        public string Vehicle { set; get; }
        public string Brand { set; get; }
        public string Model { set; get; }
        public string YearManufactured { set; get; }
        public string AppName { set; get; }
        public string OEM { set; get; }
        public string Supplier { set; get; }
        public string CategoryName { set; get; }
        public string CompanyName { set; get; }
        public string Breaches { set; get; }
        public string Vulnerabilities { set; get; }
        public int Score { set; get; }
        public int AppID { set; get; }
        public string COLOR { set; get; }

    }

    [NotMapped]
    public class CaseViewModel : Case
    {
        public HttpPostedFileBase[] Attachments { set; get; }
    }

}