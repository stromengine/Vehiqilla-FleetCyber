using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyPortal.Models
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

        public int? License { set; get; }
        public int? Vehicles { set; get; }
        public int? Fleets { set; get; }

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
        public string Logo { set; get; }
    }
    public class Oem : BaseFields
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
    public class AppBreach : BaseFields
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
        public string AbsolutePath { set; get; }
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
    public class CaseNotification : BaseFields
    {
        public int CaseID { set; get; }
        [Required]
        public string Message { set; get; }
        public bool Read { set; get; }
        public virtual Company Company { set; get; }
    }



    public class VehiAssureAssessment
    {
        [Key]
        [Required]
        public int ID { set; get; }
        [StringLength(250)]
        public string UUID { set; get; }
        [Required]
        public DateTime AssessmentDate { set; get; }
        [Required]
        [StringLength(250)]
        public string Token { set; get; }
        [Required]
        public int SupplierID { set; get; }
        [Required]
        public int EcuAppID { set; get; }
        [Required]
        public int QuestionaireID { set; get; }
        [Required]
        public int QuestionID { set; get; }
        [Required]
        public int OptionID { set; get; }
        [StringLength(250)]
        public string Remarks { set; get; }
        public bool Approved { set; get; }
        public bool Reviewed { set; get; }
    }
    public class VehiAssureQuestionaire
    {
        [Key]
        [Required]
        public int ID { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Instructions { set; get; }
        [Required]
        public int DueInDays { set; get; }
        [Required]
        public bool Status { set; get; }
        [Required]
        [StringLength(250)]
        public string CreatedBy { set; get; }
        [Required]
        public DateTime DateCreated { set; get; }
        [Required]
        [StringLength(250)]
        public string ModifiedBy { set; get; }
        [Required]
        public DateTime DateModified { set; get; }
    }
    public class VehiAssureQuestionaireCustomField
    {
        [Key]
        [Required]
        public int ID { set; get; }
        [Required]
        public int VehiAssureQuestionaireID { set; get; }
        [Required]
        public string Field { set; get; }
    }
    public class VehiAssureQuestionGroup
    {
        [Key]
        [Required]
        public int ID { set; get; }
        public int VehiAssureQuestionaireID { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int MaxScore { set; get; }
        [Required]
        public int Threshold { set; get; }

    }
    public class VehiAssureQuestion
    {
        [Key]
        [Required]
        public int ID { set; get; }
        [Required]
        public int VehiAssureQuestionGroupID { set; get; }
        [Required]
        public string Type { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int Score { set; get; }

    }
    public class VehiAssureQuestionOption
    {
        [Key]
        [Required]
        public int ID { set; get; }
        [Required]
        public int VehiAssureQuestionID { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int Score { set; get; }
    }
    public class VehiAssureAssessmentCustomField
    {
        [Key]
        [Required]
        public int ID { set; get; }
        [Required]
        public DateTime AssessmentDate { set; get; }
        [Required]
        [StringLength(250)]
        public string Token { set; get; }
        [Required]
        public int SupplierID { set; get; }
        [Required]
        public int EcuAppID { set; get; }
        [Required]
        public int FieldID { set; get; }
        [Required]
        [StringLength(250)]
        public string Value { set; get; }
        public string UUID { set; get; }
    }
    public class VehiAssureInvite : BaseFields
    {
        public string InviteStatus { set; get; }
        public string Token { set; get; }
        public DateTime DateRequested { set; get; }
        public DateTime? RemindedOn { set; get; }
        public virtual Supplier Supplier { set; get; }
        public virtual ECUApp ECUApp { set; get; }
    }

    public class Content : BaseFields
    {

        [StringLength(250)]
        public string Type { set; get; }
        public string Heading { set; get; }
        public string Image { set; get; }
        public string Text { set; get; }
        public string File { set; get; }
        public string Url { set; get; }
        public string Name { set; get; }
        public string Designation { set; get; }

    }

    #region CompanyPortal
    public class Vehicle : BaseFields
    {
        [StringLength(250)]
        public string VehicleIdentifier { set; get; }
        [StringLength(250)]
        public string Name { set; get; }
        [StringLength(250)]
        public string Brand { set; get; }
        [StringLength(250)]
        public string Model { set; get; }
        [StringLength(250)]
        public string YearManufactured { set; get; }

        [Required]
        public int CompanyID { set; get; }

        public virtual Fleet Fleet { set; get; }

    }
    public class Fleet : BaseFields
    {
        [StringLength(250)]
        public string Name { set; get; }
        [Required]
        public int CompanyID { set; get; }
    }
    public class AccessList : BaseFields
    {
        [StringLength(250)]
        public string Type { set; get; }
        [Required]
        public int ItemID { set; get; }
    }
    public class AppVehicleMap
    {
        [Key]
        public int ID { set; get; }
        public int App_ID { set; get; }
        public int Vehicle_ID { set; get; }
    }
    public class Case
    {
        [Key]
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string AssignedTo { get; set; }
        public string Source { get; set; }
        public string Requestedby { get; set; }
        public string Priority { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ResolutionDate { get; set; }
    }
    public class CaseResponse
    {
        [Key]
        public int ID { get; set; }
        public int? CaseID { get; set; }
        public string Message { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string MessageFrom { get; set; }
    }

    public class CaseAttachment
    {
        [Key]
        public int ID { get; set; }
        public string AbsolutePath { get; set; }
        public string Address { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public string UploadedBy { get; set; }
        public int? TypeID { get; set; }
    }
    #endregion
    public class CyberRiskType : BaseFields
    {
        [StringLength(250)]
        public string Name { set; get; }
    }

    public class Finding :BaseFields
    {
        public string Name { get; set; }
        public int FleetID { get; set; }
        public int VehicleID { get; set; }
        public string Details { get; set; }
        public int CyberRiskTypeID { get; set; }
        public string RiskImpact { get; set; }
        public string RiskLikelyhood { get; set; }
        public string FindingRiskScore { get; set; }
        public string Recomendations { get; set; }
        public string Owner { get; set; }
    }

}