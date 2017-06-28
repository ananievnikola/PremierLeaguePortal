namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xxx : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blog", "Header", c => c.String());
            AlterColumn("dbo.Blog", "SubHeader", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blog", "SubHeader", c => c.String(maxLength: 200));
            AlterColumn("dbo.Blog", "Header", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
