namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSectionName : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ClassSections");
            AddColumn("dbo.ClassSections", "SectionName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ClassSections", new[] { "ClassID", "SectionID", "SectionName" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ClassSections");
            DropColumn("dbo.ClassSections", "SectionName");
            AddPrimaryKey("dbo.ClassSections", new[] { "ClassID", "SectionID" });
        }
    }
}
