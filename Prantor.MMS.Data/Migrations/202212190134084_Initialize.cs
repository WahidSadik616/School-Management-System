namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
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
                        DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                        UserTypeId = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        BloodGroupId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInfoes");
        }
    }
}
