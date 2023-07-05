namespace Prantor.MMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContactDirectorMadrasa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Madrasas", "ContactNo", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Madrasas", "DirectorName", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Madrasas", "DirectorName");
            DropColumn("dbo.Madrasas", "ContactNo");
        }
    }
}
