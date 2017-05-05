namespace PremierLeaguePortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authorsaddedtodb : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Blog", name: "Autor_Id", newName: "Author_Id");
            RenameIndex(table: "dbo.Blog", name: "IX_Autor_Id", newName: "IX_Author_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Blog", name: "IX_Author_Id", newName: "IX_Autor_Id");
            RenameColumn(table: "dbo.Blog", name: "Author_Id", newName: "Autor_Id");
        }
    }
}
