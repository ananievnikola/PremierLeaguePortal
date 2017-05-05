namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userBugFix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "IsAuthor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "IsAuthor", c => c.Boolean(nullable: false));
        }
    }
}
