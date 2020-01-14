namespace Project.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ratinghotfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "Material_Id", "dbo.Materials");
            DropIndex("dbo.Ratings", new[] { "Material_Id" });
            RenameColumn(table: "dbo.Ratings", name: "Material_Id", newName: "MaterialId");
            RenameColumn(table: "dbo.Ratings", name: "Assigner_Id", newName: "AssignerId");
            RenameIndex(table: "dbo.Ratings", name: "IX_Assigner_Id", newName: "IX_AssignerId");
            AlterColumn("dbo.Ratings", "MaterialId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ratings", "MaterialId");
            AddForeignKey("dbo.Ratings", "MaterialId", "dbo.Materials", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "MaterialId", "dbo.Materials");
            DropIndex("dbo.Ratings", new[] { "MaterialId" });
            AlterColumn("dbo.Ratings", "MaterialId", c => c.Int());
            RenameIndex(table: "dbo.Ratings", name: "IX_AssignerId", newName: "IX_Assigner_Id");
            RenameColumn(table: "dbo.Ratings", name: "AssignerId", newName: "Assigner_Id");
            RenameColumn(table: "dbo.Ratings", name: "MaterialId", newName: "Material_Id");
            CreateIndex("dbo.Ratings", "Material_Id");
            AddForeignKey("dbo.Ratings", "Material_Id", "dbo.Materials", "Id");
        }
    }
}
