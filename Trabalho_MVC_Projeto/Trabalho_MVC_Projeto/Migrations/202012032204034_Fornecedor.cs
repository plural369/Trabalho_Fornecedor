namespace Trabalho_MVC_Projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fornecedor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FornecedorModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cnpj = c.String(nullable: false),
                        Telefone = c.Int(nullable: false),
                        Produto = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProdutoModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Valor = c.Double(nullable: false),
                        Tipo_de_Produto = c.String(nullable: false),
                        Peso = c.Double(nullable: false),
                        Fornecedor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FornecedorModel", t => t.Fornecedor_ID)
                .Index(t => t.Fornecedor_ID);
            
            CreateTable(
                "dbo.UsuarioModel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Usuario = c.String(nullable: false),
                        Senha = c.String(nullable: false, maxLength: 255),
                        ConfirmaSenha = c.String(),
                        Nivel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoModel", "Fornecedor_ID", "dbo.FornecedorModel");
            DropIndex("dbo.ProdutoModel", new[] { "Fornecedor_ID" });
            DropTable("dbo.UsuarioModel");
            DropTable("dbo.ProdutoModel");
            DropTable("dbo.FornecedorModel");
        }
    }
}
