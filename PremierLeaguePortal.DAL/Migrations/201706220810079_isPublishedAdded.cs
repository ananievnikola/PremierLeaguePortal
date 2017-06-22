namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isPublishedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "IsPublished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blog", "IsPublished");
        }
    }
}
