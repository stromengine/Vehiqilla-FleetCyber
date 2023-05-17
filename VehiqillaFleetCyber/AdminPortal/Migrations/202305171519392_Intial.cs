namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppBreaches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Description = c.String(),
                        NewsSource = c.String(maxLength: 250),
                        VulnerabilityExploited = c.String(maxLength: 250),
                        Date = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                        ECUApp_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ECUApps", t => t.ECUApp_ID)
                .Index(t => t.ECUApp_ID);
            
            CreateTable(
                "dbo.ECUApps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Description = c.String(),
                        VehicleModel = c.String(maxLength: 250),
                        YearManufactured = c.String(maxLength: 250),
                        Breaches = c.String(maxLength: 250),
                        Vulnerabilities = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                        Category_ID = c.Int(),
                        Company_ID = c.Int(),
                        Oem_ID = c.Int(),
                        Supplier_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.Companies", t => t.Company_ID)
                .ForeignKey("dbo.Oems", t => t.Oem_ID)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.Company_ID)
                .Index(t => t.Oem_ID)
                .Index(t => t.Supplier_ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Abbreviation = c.String(maxLength: 250),
                        DisplayName = c.String(maxLength: 250),
                        logo = c.String(),
                        Address = c.String(maxLength: 250),
                        Country = c.String(maxLength: 250),
                        Email = c.String(),
                        Url = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Company_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_ID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Company_ID);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Oems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        Brand = c.String(maxLength: 250),
                        Model = c.String(maxLength: 250),
                        YearManufactured = c.Int(nullable: false),
                        Country = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        ContactPerson = c.String(maxLength: 250),
                        ContactDetail = c.String(maxLength: 250),
                        Headoffice = c.String(maxLength: 250),
                        Country = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AppVulnerabilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(maxLength: 250),
                        HackType = c.String(maxLength: 250),
                        CompanyImpacted = c.String(maxLength: 250),
                        CompanyImpactedType = c.String(maxLength: 250),
                        Access = c.String(maxLength: 250),
                        Range = c.String(maxLength: 250),
                        AttackVector = c.String(maxLength: 250),
                        AttackMethod = c.String(maxLength: 250),
                        Impact = c.String(maxLength: 250),
                        ResearchName = c.String(maxLength: 250),
                        Reference = c.String(maxLength: 250),
                        VideoLink = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                        ECUApp_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ECUApps", t => t.ECUApp_ID)
                .Index(t => t.ECUApp_ID);
            
            CreateTable(
                "dbo.CaseNotifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CaseID = c.Int(nullable: false),
                        Message = c.String(nullable: false),
                        Read = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                        Company_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.Company_ID)
                .Index(t => t.Company_ID);
            
            CreateTable(
                "dbo.KnowledgeCenters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Heading = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        FilePath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Heading = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Read = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.VehiAssureQuestionaireCustomFields",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VehiAssureQuestionaireID = c.Int(nullable: false),
                        Field = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VehiAssureQuestionaires", t => t.VehiAssureQuestionaireID, cascadeDelete: true)
                .Index(t => t.VehiAssureQuestionaireID);
            
            CreateTable(
                "dbo.VehiAssureQuestionaires",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Instructions = c.String(nullable: false),
                        DueInDays = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VehiAssureQuestionGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MaxScore = c.Int(nullable: false),
                        Threshold = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                        VehiAssureQuestionaire_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VehiAssureQuestionaires", t => t.VehiAssureQuestionaire_ID)
                .Index(t => t.VehiAssureQuestionaire_ID);
            
            CreateTable(
                "dbo.VehiAssureQuestionOptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Score = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                        VehiAssureQuestion_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VehiAssureQuestions", t => t.VehiAssureQuestion_ID)
                .Index(t => t.VehiAssureQuestion_ID);
            
            CreateTable(
                "dbo.VehiAssureQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Score = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                        VehiAssureQuestionGroup_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VehiAssureQuestionGroups", t => t.VehiAssureQuestionGroup_ID)
                .Index(t => t.VehiAssureQuestionGroup_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehiAssureQuestionOptions", "VehiAssureQuestion_ID", "dbo.VehiAssureQuestions");
            DropForeignKey("dbo.VehiAssureQuestions", "VehiAssureQuestionGroup_ID", "dbo.VehiAssureQuestionGroups");
            DropForeignKey("dbo.VehiAssureQuestionGroups", "VehiAssureQuestionaire_ID", "dbo.VehiAssureQuestionaires");
            DropForeignKey("dbo.VehiAssureQuestionaireCustomFields", "VehiAssureQuestionaireID", "dbo.VehiAssureQuestionaires");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Notifications", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CaseNotifications", "Company_ID", "dbo.Companies");
            DropForeignKey("dbo.AppVulnerabilities", "ECUApp_ID", "dbo.ECUApps");
            DropForeignKey("dbo.AppBreaches", "ECUApp_ID", "dbo.ECUApps");
            DropForeignKey("dbo.ECUApps", "Supplier_ID", "dbo.Suppliers");
            DropForeignKey("dbo.ECUApps", "Oem_ID", "dbo.Oems");
            DropForeignKey("dbo.ECUApps", "Company_ID", "dbo.Companies");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Company_ID", "dbo.Companies");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ECUApps", "Category_ID", "dbo.Categories");
            DropIndex("dbo.VehiAssureQuestions", new[] { "VehiAssureQuestionGroup_ID" });
            DropIndex("dbo.VehiAssureQuestionOptions", new[] { "VehiAssureQuestion_ID" });
            DropIndex("dbo.VehiAssureQuestionGroups", new[] { "VehiAssureQuestionaire_ID" });
            DropIndex("dbo.VehiAssureQuestionaireCustomFields", new[] { "VehiAssureQuestionaireID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Notifications", new[] { "User_Id" });
            DropIndex("dbo.CaseNotifications", new[] { "Company_ID" });
            DropIndex("dbo.AppVulnerabilities", new[] { "ECUApp_ID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Company_ID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ECUApps", new[] { "Supplier_ID" });
            DropIndex("dbo.ECUApps", new[] { "Oem_ID" });
            DropIndex("dbo.ECUApps", new[] { "Company_ID" });
            DropIndex("dbo.ECUApps", new[] { "Category_ID" });
            DropIndex("dbo.AppBreaches", new[] { "ECUApp_ID" });
            DropTable("dbo.VehiAssureQuestions");
            DropTable("dbo.VehiAssureQuestionOptions");
            DropTable("dbo.VehiAssureQuestionGroups");
            DropTable("dbo.VehiAssureQuestionaires");
            DropTable("dbo.VehiAssureQuestionaireCustomFields");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Notifications");
            DropTable("dbo.KnowledgeCenters");
            DropTable("dbo.CaseNotifications");
            DropTable("dbo.AppVulnerabilities");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Oems");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Companies");
            DropTable("dbo.Categories");
            DropTable("dbo.ECUApps");
            DropTable("dbo.AppBreaches");
        }
    }
}
