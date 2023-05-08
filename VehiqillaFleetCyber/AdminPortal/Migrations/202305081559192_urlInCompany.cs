namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class urlInCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "Url");
        }
    }
}
