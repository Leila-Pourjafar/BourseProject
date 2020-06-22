namespace Bourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V06 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PotentialCustomers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CompanyName = c.String(nullable: false, maxLength: 200),
                        UnitName = c.String(nullable: false, maxLength: 200),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                        MobileNumber = c.String(maxLength: 11),
                        CreditNumber = c.Int(),
                        CreditAmount = c.Int(),
                        Campaign = c.Boolean(nullable: false),
                        Competition = c.Boolean(nullable: false),
                        BookClub = c.Boolean(nullable: false),
                        Gift = c.Boolean(nullable: false),
                        CustomerDescription = c.String(maxLength: 250),
                        StatusId = c.Byte(),
                        AdminDescription = c.String(maxLength: 250),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                        Price = c.Decimal(nullable: false, precision: 10, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.PotentialCustomers");
        }
    }
}
