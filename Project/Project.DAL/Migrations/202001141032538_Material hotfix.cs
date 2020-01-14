namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Materialhotfix : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Materials", name: "Author_Id", newName: "AuthorId");
            RenameIndex(table: "dbo.Materials", name: "IX_Author_Id", newName: "IX_AuthorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Materials", name: "IX_AuthorId", newName: "IX_Author_Id");
            RenameColumn(table: "dbo.Materials", name: "AuthorId", newName: "Author_Id");
        }
    }
}
