namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersAndOtherEntitiesOnSeparateDbs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false, maxLength: 50),
                        SubHeader = c.String(maxLength: 200),
                        Category = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        HeaderImage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Image", t => t.HeaderImage_Id)
                .Index(t => t.HeaderImage_Id);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageServerPath = c.String(),
                        ImagePhysicalPath = c.String(),
                        ImageName = c.String(),
                        Type = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blog", "HeaderImage_Id", "dbo.Image");
            DropIndex("dbo.Blog", new[] { "HeaderImage_Id" });
            DropTable("dbo.Image");
            DropTable("dbo.Blog");
        }
    }
}
