namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClassSectionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassSections",
                c => new
                    {
                        ClassID = c.Int(nullable: false),
                        SectionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClassID, t.SectionID })
                .ForeignKey("dbo.Classes", t => t.ClassID, cascadeDelete: false)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: false)
                .Index(t => t.ClassID)
                .Index(t => t.SectionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassSections", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.ClassSections", "ClassID", "dbo.Classes");
            DropIndex("dbo.ClassSections", new[] { "SectionID" });
            DropIndex("dbo.ClassSections", new[] { "ClassID" });
            DropTable("dbo.ClassSections");
        }
    }
}
