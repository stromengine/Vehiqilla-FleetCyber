using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CompanyPortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string Name { set; get; }
        public string Code { set; get; }
        public string Phone { set; get; }
        public bool Active { set; get; }
        public string Address { set; get; }
        public DateTime DateCreated { set; get; }
        public virtual Company Company { set; get; }
    }

    public class DbContextConfiguration : DbConfiguration
    {
        public DbContextConfiguration()
        {
            SqlProviderServices providerInstance = SqlProviderServices.Instance;
            SqlProviderServices.TruncateDecimalsToScale = false;
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
        }
    }

    [DbConfigurationType(typeof(DbContextConfiguration))]
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(string conn = "DefaultConnection")
            : base(conn, throwIfV1Schema: false)
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Company> Companies { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Supplier> Suppliers { set; get; }
        public DbSet<Oem> Oems { set; get; }
        public DbSet<ECUApp> ECUApps { set; get; }
        public DbSet<AppVulnerability> AppVulnerabilities { set; get; }
        public DbSet<AppBreach> AppBreachs { set; get; }
        public DbSet<KnowledgeCenter> KnowledgeCenters { set; get; }
        public DbSet<Notification> Notifications { set; get; }
        public DbSet<CaseNotification> CaseNotifications { set; get; }
        public DbSet<VehiAssureQuestionaire> VehiAssureQuestionaires { set; get; }
        public DbSet<VehiAssureQuestionaireCustomField> VehiAssureQuestionaireCustomFields { set; get; }
        public DbSet<VehiAssureQuestionGroup> VehiAssureQuestionGroups { set; get; }
        public DbSet<VehiAssureQuestion> VehiAssureQuestions { set; get; }
        public DbSet<VehiAssureQuestionOption> VehiAssureQuestionOptions { set; get; }
        public DbSet<VehiAssureAssessment> VehiAssureAssessments { set; get; }
        public DbSet<VehiAssureInvite> VehiAssureInvites { set; get; }
        public DbSet<VehiAssureAssessmentCustomField> VehiAssureAssessmentCustomFields { set; get; }
        public DbSet<Content> Contents { set; get; }
        public DbSet<Vehicle> Vehicles { set; get; }
        public DbSet<Fleet> Fleets { set; get; }
        public DbSet<AccessList> AccessLists { set; get; }
        public DbSet<AppVehicleMap> AppVehicleMaps { set; get; }
        public DbSet<CaseResponse> CaseResponses { set; get; }
        public DbSet<Case> Cases { set; get; }
        public DbSet<CaseAttachment> CaseAttachments { set; get; }

    }
    public class BaseFields
    {
        public BaseFields()
        {
            IsActive = true;
            IsActive = true;
            IsDeleted = false;
            ModifiedBy = HttpContext.Current.User.Identity.GetUserId();
            DateModified = DateTime.Now;
            if (ID == 0)
            {
                CreatedBy = HttpContext.Current.User.Identity.GetUserId();
                DateCreated = DateTime.Now;
            }
        }

        [Key]
        [Required]
        public int ID { set; get; }
        public bool IsActive { set; get; }
        public bool IsDeleted { set; get; }
        [Required]
        [StringLength(250)]
        public string CreatedBy { set; get; }
        public DateTime DateCreated { set; get; }
        [Required]
        [StringLength(250)]
        public string ModifiedBy { set; get; }
        public DateTime DateModified { set; get; }
    }
}