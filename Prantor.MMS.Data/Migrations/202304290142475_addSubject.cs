namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubject : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Madrasas", t => t.MadrasaId, cascadeDelete: true)
                .Index(t => t.MadrasaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "MadrasaId", "dbo.Madrasas");
            DropIndex("dbo.Subjects", new[] { "MadrasaId" });
            DropTable("dbo.Subjects");
        }
    }
}
