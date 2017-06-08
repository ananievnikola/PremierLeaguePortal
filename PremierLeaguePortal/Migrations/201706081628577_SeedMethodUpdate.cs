namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMethodUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blog", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Image", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Image", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Blog", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
