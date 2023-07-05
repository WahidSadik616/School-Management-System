namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClassName : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ClassSections");
            AddColumn("dbo.ClassSections", "ClassName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ClassSections", new[] { "ClassID", "SectionID", "SectionName", "ClassName" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ClassSections");
            DropColumn("dbo.ClassSections", "ClassName");
            AddPrimaryKey("dbo.ClassSections", new[] { "ClassID", "SectionID", "SectionName" });
        }
    }
}
