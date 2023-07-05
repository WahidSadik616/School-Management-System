namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Madrasas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        Address = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        UserName = c.String(nullable: false, maxLength: 150),
                        Password = c.String(nullable: false, maxLength: 50),
                        PhoneNo = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 500),
                        Email = c.String(maxLength: 200),
                        DateOfBirth = c.String(nullable: false, maxLength: 150),
                        UserTypeId = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        BloodGroupId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        MadrasaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Madrasas", t => t.MadrasaId, cascadeDelete: true)
                .Index(t => t.MadrasaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfoes", "MadrasaId", "dbo.Madrasas");
            DropIndex("dbo.UserInfoes", new[] { "MadrasaId" });
            DropTable("dbo.UserInfoes");
            DropTable("dbo.Madrasas");
        }
    }
}
