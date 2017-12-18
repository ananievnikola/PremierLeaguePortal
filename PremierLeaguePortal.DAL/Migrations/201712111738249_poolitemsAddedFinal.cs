namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class poolitemsAddedFinal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PoolItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Label = c.String(),
                        CreatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Pool_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Pool", t => t.Pool_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Pool_Id);
            
            CreateTable(
                "dbo.Pool",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PoolName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsCurrentUserVoted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PoolItem", "Pool_Id", "dbo.Pool");
            DropForeignKey("dbo.PoolItem", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PoolItem", new[] { "Pool_Id" });
            DropIndex("dbo.PoolItem", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Pool");
            DropTable("dbo.PoolItem");
        }
    }
}
