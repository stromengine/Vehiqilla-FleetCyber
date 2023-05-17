using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Models
{
    public class Company : BaseFields
    {
  
        [StringLength(250)]
        public string Name { set; get; }
        [StringLength(250)]
        public string Abbreviation { set; get; }
        [StringLength(250)]
        public string DisplayName { set; get; }

        public string logo { set; get; }
        [StringLength(250)]
        public string Address { set; get; }
        [StringLength(250)]
        public string Country { set; get; }
        public string Email { set; get; }
        public string Url { set; get; }

        public virtual ICollection<ApplicationUser> Users { get; set; } 
     
    }
    public class Category : BaseFields
    {
        [StringLength(250)]
        public string Name { set; get; }
    }

    public class Supplier : BaseFields
    {
        [StringLength(250)]
        public string Name { set; get; }
        [StringLength(250)]
        public string ContactPerson { set; get; }
        [StringLength(250)]
        public string ContactDetail { set; get; }
        [StringLength(250)]
        public string Headoffice { set; get; }
        [StringLength(250)]
        public string Country { set; get; }
    }
    public class Oem :BaseFields
    {
        [StringLength(250)]
        public string Name { set; get; }
        [StringLength(250)]
        public string Brand { set; get; }
        [StringLength(250)]
        public string Model { set; get; }

        public int YearManufactured { set; get; }
        [StringLength(250)]
        public string Country { set; get; }
    }
    public class ECUApp : BaseFields
    {

        [StringLength(250)]
        public string Name { set; get; }
        public string Description { set; get; }
        [StringLength(250)]
        public string VehicleModel { set; get; }
        [StringLength(250)]
        public string YearManufactured { set; get; }
        [StringLength(250)]
        public string Breaches { set; get; }
        [StringLength(250)]
        public string Vulnerabilities { set; get; }

        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }
    }

    public class AppVulnerability : BaseFields
    {
        public string Name { set; get; }
        [StringLength(250)]
        public string Description { set; get; }
        [StringLength(250)]
        public string HackType { set; get; }
        [StringLength(250)]
        public string OemImpacted { set; get; }
        [StringLength(250)]
        public string Access { set; get; }
        [StringLength(250)]
        public string Range { set; get; }
        [StringLength(250)]
        public string AttackVector { set; get; }
        [StringLength(250)]
        public string AttackMethod { set; get; }
        [StringLength(250)]
        public string Impact { set; get; }
        [StringLength(250)]
        public string ResearchName { set; get; }
        [StringLength(250)]
        public string Reference { set; get; }
        [StringLength(250)]
        public string Link { set; get; }
        public virtual ECUApp ECUApp { get; set; }
    }
    public class AppBreach :BaseFields
    {
        [StringLength(250)]
        public string Name { set; get; }

        public string Description { set; get; }
        [StringLength(250)]
        public string NewsSource { set; get; }
        [StringLength(250)]
        public string VulnerabilityExploited { set; get; }
        public DateTime Date { set; get; }

        public virtual ECUApp ECUApp { get; set; }
    }

    public class KnowledgeCenter : BaseFields
    {
        [Required]
        public string Heading { set; get; }
        [Required]
        public string Description { set; get; }
        public string FilePath { set; get; }

    }
    public class Notification : BaseFields
    {
        [Required]
        public string Heading { set; get; }
        [Required]
        public string Description { set; get; }
        public bool Read { set; get; }

        public virtual ApplicationUser User { get; set; }   
    }
    public class CaseNotification:BaseFields
    {
        public int CaseID { set; get; }
        [Required]
        public string Message { set; get; }
        public bool Read { set; get; }
        public virtual  Company Company { set; get; }   
    }



    public class VehiAssureQuestionaire : BaseFields
    {
        [Required]
        public string Name { set; get; }
        [Required]
        public string Instructions { set; get; }
        [Required]
        public int DueInDays { set; get; }
        [Required]
        public bool Status { set; get; }
    }
    public class VehiAssureQuestionaireCustomField : BaseFields
    {
        [Required]
        public int VehiAssureQuestionaireID { set; get; }
        [Required]
        public string Field { set; get; }

        public virtual VehiAssureQuestionaire VehiAssureQuestionaire { set; get; }
    }
    public class VehiAssureQuestionGroup : BaseFields
    {
        [Required]
        public string Name { set; get; }
        [Required]
        public int MaxScore { set; get; }
        [Required]
        public int Threshold { set; get; }
        public virtual VehiAssureQuestionaire VehiAssureQuestionaire { set; get; }

    }
    public class VehiAssureQuestion:BaseFields
    {
        [Required]
        public string Type { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int Score { set; get; }
        public virtual VehiAssureQuestionGroup VehiAssureQuestionGroup { set; get; }

    }
    public class VehiAssureQuestionOption : BaseFields
    {
     
        [Required]
        public string Name { set; get; }
        [Required]
        public int Score { set; get; }

        public virtual VehiAssureQuestion VehiAssureQuestion { set; get; }
    }
}