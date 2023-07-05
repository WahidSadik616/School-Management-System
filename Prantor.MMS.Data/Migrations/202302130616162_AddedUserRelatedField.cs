namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserRelatedField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "Email", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "Email");
        }
    }
}
