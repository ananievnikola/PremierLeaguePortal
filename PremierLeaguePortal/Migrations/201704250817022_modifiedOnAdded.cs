namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedOnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "ModifiedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blog", "ModifiedOn");
        }
    }
}
