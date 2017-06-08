namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUnusedTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Manager", "Image_Id", "dbo.Image");
            DropForeignKey("dbo.Player", "Image_Id", "dbo.Image");
            DropForeignKey("dbo.Player", "TeamOfTheWeek_Id", "dbo.TeamOfTheWeek");
            DropForeignKey("dbo.Team", "Manager_Id", "dbo.Manager");
            DropForeignKey("dbo.Player", "Team_Id", "dbo.Team");
            DropIndex("dbo.Manager", new[] { "Image_Id" });
            DropIndex("dbo.Player", new[] { "Image_Id" });
            DropIndex("dbo.Player", new[] { "TeamOfTheWeek_Id" });
            DropIndex("dbo.Player", new[] { "Team_Id" });
            DropIndex("dbo.Team", new[] { "Manager_Id" });
            DropTable("dbo.Manager");
            DropTable("dbo.Player");
            DropTable("dbo.TeamOfTheWeek");
            DropTable("dbo.Team");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Manager_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamOfTheWeek",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manager",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Image_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Team", "Manager_Id");
            CreateIndex("dbo.Player", "Team_Id");
            CreateIndex("dbo.Player", "TeamOfTheWeek_Id");
            CreateIndex("dbo.Player", "Image_Id");
            CreateIndex("dbo.Manager", "Image_Id");
            AddForeignKey("dbo.Player", "Team_Id", "dbo.Team", "Id");
            AddForeignKey("dbo.Team", "Manager_Id", "dbo.Manager", "Id");
            AddForeignKey("dbo.Player", "TeamOfTheWeek_Id", "dbo.TeamOfTheWeek", "Id");
            AddForeignKey("dbo.Player", "Image_Id", "dbo.Image", "Id");
            AddForeignKey("dbo.Manager", "Image_Id", "dbo.Image", "Id");
        }
    }
}
