namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        FatherName = c.String(nullable: false, maxLength: 500),
                        FatherNid = c.String(nullable: false, maxLength: 100),
                        MotherNid = c.String(nullable: false, maxLength: 100),
                        MotherName = c.String(nullable: false, maxLength: 500),
                        PhoneNo = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 500),
                        Email = c.String(maxLength: 200),
                        DateOfBirth = c.String(nullable: false, maxLength: 150),
                        GenderId = c.Int(nullable: false),
                        BloodGroupId = c.Int(nullable: false),
                        MadrasaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Madrasas", t => t.MadrasaId, cascadeDelete: true)
                .Index(t => t.MadrasaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "MadrasaId", "dbo.Madrasas");
            DropIndex("dbo.Students", new[] { "MadrasaId" });
            DropTable("dbo.Students");
        }
    }
}
