namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IFrameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "IFrame", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blog", "IFrame");
        }
    }
}
