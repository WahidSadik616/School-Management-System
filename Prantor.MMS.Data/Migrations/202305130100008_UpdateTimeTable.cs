namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTimeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeTables", "ClassName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.TimeTables", "SectionName", c => c.String(maxLength: 10));
            AddColumn("dbo.TimeTables", "SubjectName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.TimeTables", "WeekName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TimeTables", "WeekName");
            DropColumn("dbo.TimeTables", "SubjectName");
            DropColumn("dbo.TimeTables", "SectionName");
            DropColumn("dbo.TimeTables", "ClassName");
        }
    }
}
