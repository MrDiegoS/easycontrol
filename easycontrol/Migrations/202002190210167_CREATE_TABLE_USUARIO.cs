namespace easycontrol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CREATE_TABLE_USUARIO : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.USUARIO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NOME = c.String(),
                        SENHA = c.String(),
                        EMAIL = c.String(),
                        ADMIN = c.Boolean(nullable: false),
                        DTCADASTRO = c.DateTime(nullable: false),
                        DTALTERACAO = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.USUARIO");
        }
    }
}
