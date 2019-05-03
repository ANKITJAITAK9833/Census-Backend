namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HouseListing",
                c => new
                    {
                        HouseListingId = c.Int(nullable: false, identity: true),
                        ApartmentNumber = c.String(nullable: false),
                        StreetNumber = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        HeadName = c.String(nullable: false),
                        OwnerShipStatus = c.Int(nullable: false),
                        NumberOfRooms = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HouseListingId);
            
            CreateTable(
                "dbo.PopulationRegistration",
                c => new
                    {
                        PopulationRegistrationId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FullName = c.String(nullable: false),
                        CensusHouseNumberId = c.Int(nullable: false),
                        RelationToHead = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        AgeAtMarriage = c.Int(nullable: false),
                        Occupation = c.Int(nullable: false),
                        NatureOfOccupation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PopulationRegistrationId)
                .ForeignKey("dbo.HouseListing", t => t.CensusHouseNumberId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CensusHouseNumberId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        EmailId = c.String(nullable: false, maxLength: 120),
                        Password = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        ProfileImage = c.String(nullable: false),
                        AadharNumber = c.String(nullable: false, maxLength: 12),
                        IsApprover = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.EmailId, unique: true)
                .Index(t => t.AadharNumber, unique: true);
            
            CreateTable(
                "dbo.UserRequestStatus",
                c => new
                    {
                        UserRequestStatusId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RequestStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRequestStatusId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRequestStatus", "UserId", "dbo.User");
            DropForeignKey("dbo.PopulationRegistration", "UserId", "dbo.User");
            DropForeignKey("dbo.PopulationRegistration", "CensusHouseNumberId", "dbo.HouseListing");
            DropIndex("dbo.UserRequestStatus", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "AadharNumber" });
            DropIndex("dbo.User", new[] { "EmailId" });
            DropIndex("dbo.PopulationRegistration", new[] { "CensusHouseNumberId" });
            DropIndex("dbo.PopulationRegistration", new[] { "UserId" });
            DropTable("dbo.UserRequestStatus");
            DropTable("dbo.User");
            DropTable("dbo.PopulationRegistration");
            DropTable("dbo.HouseListing");
        }
    }
}
