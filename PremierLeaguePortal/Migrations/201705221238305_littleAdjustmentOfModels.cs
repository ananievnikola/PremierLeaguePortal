namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class littleAdjustmentOfModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Author", "AuthorName", c => c.String());
            AddColumn("dbo.Author", "AuthorNickName", c => c.String());
            DropColumn("dbo.Author", "Name");
            DropColumn("dbo.Author", "NickName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Author", "NickName", c => c.String());
            AddColumn("dbo.Author", "Name", c => c.String());
            DropColumn("dbo.Author", "AuthorNickName");
            DropColumn("dbo.Author", "AuthorName");
        }
    }
}
