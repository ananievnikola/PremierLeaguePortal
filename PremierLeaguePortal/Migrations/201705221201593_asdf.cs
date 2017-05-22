namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blog", "Content");
        }
    }
}
