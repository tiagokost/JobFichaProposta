namespace Job.Fac.Dao.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracao00001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(unicode: false),
                        Telefone = c.String(unicode: false),
                        Nome = c.String(unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 0),
                        DataAlteracao = c.DateTime(nullable: false, precision: 0),
                        Excluido = c.Boolean(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        NomeInterno = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contato");
        }
    }
}
