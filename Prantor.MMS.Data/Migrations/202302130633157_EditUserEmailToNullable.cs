namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditUserEmailToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "Email", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "Email", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
