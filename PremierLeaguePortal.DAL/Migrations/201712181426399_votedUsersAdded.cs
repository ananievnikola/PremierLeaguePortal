namespace PremierLeaguePortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class votedUsersAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PoolItem_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "PoolItem_Id");
            AddForeignKey("dbo.AspNetUsers", "PoolItem_Id", "dbo.PoolItem", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "PoolItem_Id", "dbo.PoolItem");
            DropIndex("dbo.AspNetUsers", new[] { "PoolItem_Id" });
            DropColumn("dbo.AspNetUsers", "PoolItem_Id");
        }
    }
}
