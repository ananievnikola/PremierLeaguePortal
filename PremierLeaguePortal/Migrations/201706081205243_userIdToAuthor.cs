namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userIdToAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Author", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Author", "UserId");
        }
    }
}
