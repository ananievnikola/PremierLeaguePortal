namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validators : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PoolItem", "Label", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PoolItem", "Label", c => c.String());
        }
    }
}
