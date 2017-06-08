namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserNavPropInBlog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Blog", "ApplicationUser_Id");
            AddForeignKey("dbo.Blog", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blog", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Blog", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Blog", "ApplicationUser_Id");
        }
    }
}
