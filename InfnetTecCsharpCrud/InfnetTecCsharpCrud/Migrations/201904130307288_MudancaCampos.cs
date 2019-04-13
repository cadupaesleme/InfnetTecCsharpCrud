namespace InfnetTecCsharpCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudancaCampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido", "PessoaFisica_CodigoPessoa", c => c.Int());
            AddColumn("dbo.Pedido", "PessoaJuridica_CodigoPessoa", c => c.Int());
            AddColumn("dbo.Produto", "PessoaJuridica_CodigoPessoa", c => c.Int());
            CreateIndex("dbo.Pedido", "PessoaFisica_CodigoPessoa");
            CreateIndex("dbo.Pedido", "PessoaJuridica_CodigoPessoa");
            CreateIndex("dbo.Produto", "PessoaJuridica_CodigoPessoa");
            AddForeignKey("dbo.Pedido", "PessoaFisica_CodigoPessoa", "dbo.Pessoa", "CodigoPessoa");
            AddForeignKey("dbo.Pedido", "PessoaJuridica_CodigoPessoa", "dbo.Pessoa", "CodigoPessoa");
            AddForeignKey("dbo.Produto", "PessoaJuridica_CodigoPessoa", "dbo.Pessoa", "CodigoPessoa");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "PessoaJuridica_CodigoPessoa", "dbo.Pessoa");
            DropForeignKey("dbo.Pedido", "PessoaJuridica_CodigoPessoa", "dbo.Pessoa");
            DropForeignKey("dbo.Pedido", "PessoaFisica_CodigoPessoa", "dbo.Pessoa");
            DropIndex("dbo.Produto", new[] { "PessoaJuridica_CodigoPessoa" });
            DropIndex("dbo.Pedido", new[] { "PessoaJuridica_CodigoPessoa" });
            DropIndex("dbo.Pedido", new[] { "PessoaFisica_CodigoPessoa" });
            DropColumn("dbo.Produto", "PessoaJuridica_CodigoPessoa");
            DropColumn("dbo.Pedido", "PessoaJuridica_CodigoPessoa");
            DropColumn("dbo.Pedido", "PessoaFisica_CodigoPessoa");
        }
    }
}
