namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Company : DbMigration
    {
        public override void Up()
        {
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
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 250),
                        DateCreated = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false, maxLength: 250),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Companies");
        }
    }
}
