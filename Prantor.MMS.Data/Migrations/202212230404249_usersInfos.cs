namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersInfos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "DateOfBirth", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "DateOfBirth", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
