namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorAdded : DbMigration
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
            
            AddColumn("dbo.Blog", "Autor_Id", c => c.Int());
            CreateIndex("dbo.Blog", "Autor_Id");
            AddForeignKey("dbo.Blog", "Autor_Id", "dbo.Author", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blog", "Autor_Id", "dbo.Author");
            DropIndex("dbo.Blog", new[] { "Autor_Id" });
            DropColumn("dbo.Blog", "Autor_Id");
            DropTable("dbo.Author");
        }
    }
}
