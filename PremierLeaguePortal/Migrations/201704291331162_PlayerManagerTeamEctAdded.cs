namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerManagerTeamEctAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manager",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Image_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Image", t => t.Image_Id)
                .Index(t => t.Image_Id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ICTIndex = c.Double(nullable: false),
                        BonusPoints = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Image_Id = c.Int(),
                        TeamOfTheWeek_Id = c.Int(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Image", t => t.Image_Id)
                .ForeignKey("dbo.TeamOfTheWeek", t => t.TeamOfTheWeek_Id)
                .ForeignKey("dbo.Team", t => t.Team_Id)
                .Index(t => t.Image_Id)
                .Index(t => t.TeamOfTheWeek_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.TeamOfTheWeek",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Manager_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manager", t => t.Manager_Id)
                .Index(t => t.Manager_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "Team_Id", "dbo.Team");
            DropForeignKey("dbo.Team", "Manager_Id", "dbo.Manager");
            DropForeignKey("dbo.Player", "TeamOfTheWeek_Id", "dbo.TeamOfTheWeek");
            DropForeignKey("dbo.Player", "Image_Id", "dbo.Image");
            DropForeignKey("dbo.Manager", "Image_Id", "dbo.Image");
            DropIndex("dbo.Team", new[] { "Manager_Id" });
            DropIndex("dbo.Player", new[] { "Team_Id" });
            DropIndex("dbo.Player", new[] { "TeamOfTheWeek_Id" });
            DropIndex("dbo.Player", new[] { "Image_Id" });
            DropIndex("dbo.Manager", new[] { "Image_Id" });
            DropTable("dbo.Team");
            DropTable("dbo.TeamOfTheWeek");
            DropTable("dbo.Player");
            DropTable("dbo.Manager");
        }
    }
}
