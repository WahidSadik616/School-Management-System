namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClassTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        MadrasaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Madrasas", t => t.MadrasaId, cascadeDelete: true)
                .Index(t => t.MadrasaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "MadrasaId", "dbo.Madrasas");
            DropIndex("dbo.Classes", new[] { "MadrasaId" });
            DropTable("dbo.Classes");
        }
    }
}
