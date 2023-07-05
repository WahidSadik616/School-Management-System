namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateClassSectionTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassSections", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.ClassSections", "SectionID", "dbo.Sections");
            DropIndex("dbo.ClassSections", new[] { "ClassID" });
            DropIndex("dbo.ClassSections", new[] { "SectionID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.ClassSections", "SectionID");
            CreateIndex("dbo.ClassSections", "ClassID");
            AddForeignKey("dbo.ClassSections", "SectionID", "dbo.Sections", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ClassSections", "ClassID", "dbo.Classes", "ID", cascadeDelete: true);
        }
    }
}
