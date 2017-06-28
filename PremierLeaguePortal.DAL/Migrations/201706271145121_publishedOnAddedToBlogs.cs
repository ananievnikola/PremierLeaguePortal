namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publishedOnAddedToBlogs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "PublishedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blog", "PublishedOn");
        }
    }
}
