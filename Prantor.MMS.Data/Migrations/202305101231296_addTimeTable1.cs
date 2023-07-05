namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTimeTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartTime = c.String(nullable: false, maxLength: 50),
                        EndTime = c.String(nullable: false, maxLength: 50),
                        RoomNum = c.String(nullable: false, maxLength: 50),
                        MadrasaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Madrasas", t => t.MadrasaId, cascadeDelete: true)
                .Index(t => t.MadrasaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeTables", "MadrasaId", "dbo.Madrasas");
            DropIndex("dbo.TimeTables", new[] { "MadrasaId" });
            DropTable("dbo.TimeTables");
        }
    }
}
