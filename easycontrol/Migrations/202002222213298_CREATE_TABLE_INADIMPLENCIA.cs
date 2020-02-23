namespace easycontrol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CREATE_TABLE_INADIMPLENCIA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.INADIMPLENCIA",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        USERID = c.Int(nullable: false),
                        FATORID = c.Int(nullable: false),
                        VALOR_ORIGINAL = c.Single(nullable: false),
                        VALOR_JUROS = c.Single(nullable: false),
                        VALOR_COMISSAO = c.Single(nullable: false),
                        VALOR_CALCULADO = c.Single(nullable: false),
                        VALOR_PARCELA = c.Single(nullable: false),
                        QTD_PARCELAS = c.Int(nullable: false),
                        DT_VENCIMENTO = c.DateTime(nullable: false),
                        DT_CALCULO = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.INADIMPLENCIA");
        }
    }
}
