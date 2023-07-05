namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubjectTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "MadrasaId", "dbo.Madrasas");
            DropIndex("dbo.Subjects", new[] { "MadrasaId" });
            CreateTable(
                "dbo.ClassSectionSubjects",
                c => new
                    {
                        ClassID = c.Int(nullable: false),
                        SectionID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        SectionName = c.String(nullable: false, maxLength: 128),
                        ClassName = c.String(nullable: false, maxLength: 128),
                        SubjectName = c.String(nullable: false, maxLength: 128),
                        MadrasaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClassID, t.SectionID, t.SubjectID, t.SectionName, t.ClassName, t.SubjectName })
                .ForeignKey("dbo.Madrasas", t => t.MadrasaId, cascadeDelete: true)
                .Index(t => t.MadrasaId);
            
            DropTable("dbo.Subjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        SubjectCode = c.String(maxLength: 50),
                        SubjectType = c.Int(nullable: false),
                        MadrasaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.ClassSectionSubjects", "MadrasaId", "dbo.Madrasas");
            DropIndex("dbo.ClassSectionSubjects", new[] { "MadrasaId" });
            DropTable("dbo.ClassSectionSubjects");
            CreateIndex("dbo.Subjects", "MadrasaId");
            AddForeignKey("dbo.Subjects", "MadrasaId", "dbo.Madrasas", "ID", cascadeDelete: true);
        }
    }
}
