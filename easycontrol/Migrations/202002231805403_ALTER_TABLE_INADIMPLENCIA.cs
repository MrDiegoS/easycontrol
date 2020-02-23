namespace easycontrol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ALTER_TABLE_INADIMPLENCIA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.INADIMPLENCIA", "ATRASODIAS", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.INADIMPLENCIA", "ATRASODIAS");
        }
    }
}
