namespace easycontrol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ALTER_TABLE_USUARIO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USUARIO", "USER", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.USUARIO", "USER");
        }
    }
}
