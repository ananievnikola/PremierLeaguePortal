namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iframerem : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blog", "IFrame");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blog", "IFrame", c => c.String());
        }
    }
}
