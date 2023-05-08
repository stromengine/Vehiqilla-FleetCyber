namespace AdminPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyRelation1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Companies", new[] { "User_Id" });
            AddColumn("dbo.AspNetUsers", "Company_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Company_ID");
            AddForeignKey("dbo.AspNetUsers", "Company_ID", "dbo.Companies", "ID");
            DropColumn("dbo.Companies", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.AspNetUsers", "Company_ID", "dbo.Companies");
            DropIndex("dbo.AspNetUsers", new[] { "Company_ID" });
            DropColumn("dbo.AspNetUsers", "Company_ID");
            CreateIndex("dbo.Companies", "User_Id");
            AddForeignKey("dbo.Companies", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
