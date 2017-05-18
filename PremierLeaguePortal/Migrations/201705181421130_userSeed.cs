namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userSeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NickName = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Blog", "Author_Id", c => c.Int());
            CreateIndex("dbo.Blog", "Author_Id");
            AddForeignKey("dbo.Blog", "Author_Id", "dbo.Author", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blog", "Author_Id", "dbo.Author");
            DropIndex("dbo.Blog", new[] { "Author_Id" });
            DropColumn("dbo.Blog", "Author_Id");
            DropTable("dbo.Author");
        }
    }
}
