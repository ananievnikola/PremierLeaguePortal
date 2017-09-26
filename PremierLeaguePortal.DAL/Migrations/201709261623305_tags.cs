namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tags : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blog", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blog", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
