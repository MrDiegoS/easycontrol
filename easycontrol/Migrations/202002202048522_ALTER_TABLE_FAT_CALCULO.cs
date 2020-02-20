namespace easycontrol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ALTER_TABLE_FAT_CALCULO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FATOR_CALCULO", "JUROS_TIPO", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FATOR_CALCULO", "JUROS_TIPO");
        }
    }
}
