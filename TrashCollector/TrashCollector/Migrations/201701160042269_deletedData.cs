namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "cityId", "dbo.Cities");
            DropForeignKey("dbo.Addresses", "stateId", "dbo.States");
            DropForeignKey("dbo.Addresses", "zipcodeId", "dbo.Zipcodes");
            DropForeignKey("dbo.RegisteredUsers", "addressId", "dbo.Addresses");
            DropIndex("dbo.Addresses", new[] { "cityId" });
            DropIndex("dbo.Addresses", new[] { "stateId" });
            DropIndex("dbo.Addresses", new[] { "zipcodeId" });
            DropIndex("dbo.RegisteredUsers", new[] { "addressId" });
            DropTable("dbo.Addresses");
            DropTable("dbo.Cities");
            DropTable("dbo.States");
            DropTable("dbo.Zipcodes");
            DropTable("dbo.RegisteredUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegisteredUsers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        phoneNumber = c.Int(nullable: false),
                        dob = c.DateTime(nullable: false),
                        addressId = c.Int(nullable: false),
                        eMail = c.String(),
                        isCurrentCustomer = c.Boolean(nullable: false),
                        membershipId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Zipcodes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        zipcode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        stateName = c.String(),
                        stateAbv = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cityName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        streetOne = c.String(),
                        streetTwo = c.String(),
                        cityId = c.Int(nullable: false),
                        stateId = c.Int(nullable: false),
                        zipcodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.RegisteredUsers", "addressId");
            CreateIndex("dbo.Addresses", "zipcodeId");
            CreateIndex("dbo.Addresses", "stateId");
            CreateIndex("dbo.Addresses", "cityId");
            AddForeignKey("dbo.RegisteredUsers", "addressId", "dbo.Addresses", "id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "zipcodeId", "dbo.Zipcodes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "stateId", "dbo.States", "id", cascadeDelete: true);
            AddForeignKey("dbo.Addresses", "cityId", "dbo.Cities", "id", cascadeDelete: true);
        }
    }
}
