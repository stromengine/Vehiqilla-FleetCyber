namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class companyUserReadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Company_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Company_ID");
            AddForeignKey("dbo.AspNetUsers", "Company_ID", "dbo.Companies", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Company_ID", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "Company_ID" });
            DropColumn("dbo.AspNetUsers", "Company_ID");
        }
    }
}
