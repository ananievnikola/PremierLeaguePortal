namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIsAuthorProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "IsAuthor", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsAuthor");
        }
    }
}
