namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blog", "Tags");
        }
    }
}
