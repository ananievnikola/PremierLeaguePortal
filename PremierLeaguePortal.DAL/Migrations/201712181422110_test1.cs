namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PoolItem", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PoolItem", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Pool", "Author_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Pool", "Author_Id");
            AddForeignKey("dbo.Pool", "Author_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.PoolItem", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PoolItem", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Pool", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Pool", new[] { "Author_Id" });
            DropColumn("dbo.Pool", "Author_Id");
            CreateIndex("dbo.PoolItem", "ApplicationUser_Id");
            AddForeignKey("dbo.PoolItem", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
