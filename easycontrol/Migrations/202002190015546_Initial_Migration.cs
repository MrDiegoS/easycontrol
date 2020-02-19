namespace easycontrol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FATOR_CALCULO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QTD_PARCELAS = c.Int(nullable: false),
                        JUROS_PER = c.Single(nullable: false),
                        COMISSAO_PER = c.Single(nullable: false),
                        DTCADASTRO = c.DateTime(nullable: false),
                        DTALTERACAO = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FATOR_CALCULO");
        }
    }
}
