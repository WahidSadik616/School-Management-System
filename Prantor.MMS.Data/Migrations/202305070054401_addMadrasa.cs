namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMadrasa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassSections", "MadrasaId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClassSections", "MadrasaId");
            AddForeignKey("dbo.ClassSections", "MadrasaId", "dbo.Madrasas", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassSections", "MadrasaId", "dbo.Madrasas");
            DropIndex("dbo.ClassSections", new[] { "MadrasaId" });
            DropColumn("dbo.ClassSections", "MadrasaId");
        }
    }
}
