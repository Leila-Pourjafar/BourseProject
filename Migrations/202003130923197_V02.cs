namespace Bourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Symbols", "DownloadFile_Id", "dbo.DownloadFiles");
            DropIndex("dbo.Symbols", new[] { "DownloadFile_Id" });
            DropColumn("dbo.Symbols", "DownloadFile_Id");
            DropTable("dbo.DownloadFiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DownloadFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Symbols", "DownloadFile_Id", c => c.Int());
            CreateIndex("dbo.Symbols", "DownloadFile_Id");
            AddForeignKey("dbo.Symbols", "DownloadFile_Id", "dbo.DownloadFiles", "Id");
        }
    }
}
