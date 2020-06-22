namespace Bourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Symbols", "SubCategoriesId", c => c.Int());
            CreateIndex("dbo.Symbols", "SubCategoriesId");
            AddForeignKey("dbo.Symbols", "SubCategoriesId", "dbo.SubCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Symbols", "SubCategoriesId", "dbo.SubCategories");
            DropIndex("dbo.Symbols", new[] { "SubCategoriesId" });
            DropColumn("dbo.Symbols", "SubCategoriesId");
        }
    }
}
