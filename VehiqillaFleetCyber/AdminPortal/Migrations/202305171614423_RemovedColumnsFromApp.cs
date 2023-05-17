namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedColumnsFromApp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ECUApps", "Company_ID", "dbo.Companies");
            DropForeignKey("dbo.ECUApps", "Oem_ID", "dbo.Oems");
            DropIndex("dbo.ECUApps", new[] { "Company_ID" });
            DropIndex("dbo.ECUApps", new[] { "Oem_ID" });
            DropColumn("dbo.ECUApps", "Company_ID");
            DropColumn("dbo.ECUApps", "Oem_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ECUApps", "Oem_ID", c => c.Int());
            AddColumn("dbo.ECUApps", "Company_ID", c => c.Int());
            CreateIndex("dbo.ECUApps", "Oem_ID");
            CreateIndex("dbo.ECUApps", "Company_ID");
            AddForeignKey("dbo.ECUApps", "Oem_ID", "dbo.Oems", "ID");
            AddForeignKey("dbo.ECUApps", "Company_ID", "dbo.Companies", "ID");
        }
    }
}
