namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movedInSepProj : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blog", "Author_Id", "dbo.Author");
            DropIndex("dbo.Blog", new[] { "Author_Id" });
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "NickName", c => c.String());
            DropColumn("dbo.Blog", "Author_Id");
            DropTable("dbo.Author");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                        AuthorNickName = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        UserId = c.String(),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Blog", "Author_Id", c => c.Int());
            DropColumn("dbo.AspNetUsers", "NickName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            CreateIndex("dbo.Blog", "Author_Id");
            AddForeignKey("dbo.Blog", "Author_Id", "dbo.Author", "Id");
        }
    }
}
