namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Companies", "User_Id");
            AddForeignKey("dbo.Companies", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Companies", new[] { "User_Id" });
            DropColumn("dbo.Companies", "User_Id");
        }
    }
}
