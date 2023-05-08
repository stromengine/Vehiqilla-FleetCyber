namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyUserReadded2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CompanyID", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "CompanyID" });
            RenameColumn(table: "dbo.AspNetUsers", name: "CompanyID", newName: "Company_ID");
            AlterColumn("dbo.AspNetUsers", "Company_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Company_ID");
            AddForeignKey("dbo.AspNetUsers", "Company_ID", "dbo.Companies", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Company_ID", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "Company_ID" });
            AlterColumn("dbo.AspNetUsers", "Company_ID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.AspNetUsers", name: "Company_ID", newName: "CompanyID");
            CreateIndex("dbo.AspNetUsers", "CompanyID");
            AddForeignKey("dbo.AspNetUsers", "CompanyID", "dbo.Companies", "ID", cascadeDelete: true);
        }
    }
}
