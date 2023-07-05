namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeyMadrasa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "MadrasaId", c => c.Int(nullable: true));
            CreateIndex("dbo.UserInfoes", "MadrasaId");
            AddForeignKey("dbo.UserInfoes", "MadrasaId", "dbo.Madrasas", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfoes", "MadrasaId", "dbo.Madrasas");
            DropIndex("dbo.UserInfoes", new[] { "MadrasaId" });
            DropColumn("dbo.UserInfoes", "MadrasaId");
        }
    }
}
