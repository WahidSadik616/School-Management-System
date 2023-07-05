namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignkeyMadrasaId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "MadrasaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sections", "MadrasaId");
            AddForeignKey("dbo.Sections", "MadrasaId", "dbo.Madrasas", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sections", "MadrasaId", "dbo.Madrasas");
            DropIndex("dbo.Sections", new[] { "MadrasaId" });
            DropColumn("dbo.Sections", "MadrasaId");
        }
    }
}
