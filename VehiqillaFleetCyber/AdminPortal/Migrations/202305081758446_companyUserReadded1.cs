namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyUserReadded1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Company_ID", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "Company_ID" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Company_ID", newName: "CompanyID");
            AlterColumn("dbo.AspNetUsers", "CompanyID", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CompanyID");
            AddForeignKey("dbo.AspNetUsers", "CompanyID", "dbo.Companies", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CompanyID", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyID" });
            AlterColumn("dbo.AspNetUsers", "CompanyID", c => c.Int());
            RenameColumn(table: "dbo.AspNetUsers", name: "CompanyID", newName: "Company_ID");
            CreateIndex("dbo.AspNetUsers", "Company_ID");
            AddForeignKey("dbo.AspNetUsers", "Company_ID", "dbo.Companies", "ID");
        }
    }
}
