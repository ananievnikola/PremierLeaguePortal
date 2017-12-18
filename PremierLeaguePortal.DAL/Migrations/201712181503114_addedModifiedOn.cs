namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedModifiedOn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pool", "ModifiedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pool", "ModifiedOn");
        }
    }
}
