namespace Trabalho_MVC_Projeto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pipa : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProdutoModel", name: "Fornecedor_ID", newName: "FornecedorID");
            RenameIndex(table: "dbo.ProdutoModel", name: "IX_Fornecedor_ID", newName: "IX_FornecedorID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProdutoModel", name: "IX_FornecedorID", newName: "IX_Fornecedor_ID");
            RenameColumn(table: "dbo.ProdutoModel", name: "FornecedorID", newName: "Fornecedor_ID");
        }
    }
}
