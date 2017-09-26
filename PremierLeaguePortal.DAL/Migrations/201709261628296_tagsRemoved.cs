namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tagsRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blog", "Tags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blog", "Tags", c => c.String());
        }
    }
}
