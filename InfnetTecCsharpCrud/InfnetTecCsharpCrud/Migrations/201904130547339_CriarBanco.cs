namespace InfnetTecCsharpCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        CodigoItem = c.Int(nullable: false, identity: true),
                        Qtd = c.Int(nullable: false),
                        ValorUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CodigoPedido = c.Int(nullable: false),
                        CodigoProduto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoItem)
                .ForeignKey("dbo.Pedido", t => t.CodigoPedido, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.CodigoProduto, cascadeDelete: true)
                .Index(t => t.CodigoPedido)
                .Index(t => t.CodigoProduto);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        CodigoPedido = c.Int(nullable: false, identity: true),
                        DataPedido = c.DateTime(nullable: false),
                        CodigoComprador = c.Int(nullable: false),
                        CodigoVendedor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoPedido)
                .ForeignKey("dbo.Pessoa", t => t.CodigoComprador, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.CodigoVendedor)
                .Index(t => t.CodigoComprador)
                .Index(t => t.CodigoVendedor);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        CodigoPessoa = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Endereco = c.String(),
                        CPF = c.String(),
                        DataNascimento = c.DateTime(),
                        Sexo = c.String(),
                        CNPJ = c.String(),
                        Ativa = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CodigoPessoa);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        CodigoProduto = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CodigoFornecedor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoProduto)
                .ForeignKey("dbo.Pessoa", t => t.CodigoFornecedor)
                .Index(t => t.CodigoFornecedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "CodigoProduto", "dbo.Produto");
            DropForeignKey("dbo.Item", "CodigoPedido", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "CodigoVendedor", "dbo.Pessoa");
            DropForeignKey("dbo.Produto", "CodigoFornecedor", "dbo.Pessoa");
            DropForeignKey("dbo.Pedido", "CodigoComprador", "dbo.Pessoa");
            DropIndex("dbo.Produto", new[] { "CodigoFornecedor" });
            DropIndex("dbo.Pedido", new[] { "CodigoVendedor" });
            DropIndex("dbo.Pedido", new[] { "CodigoComprador" });
            DropIndex("dbo.Item", new[] { "CodigoProduto" });
            DropIndex("dbo.Item", new[] { "CodigoPedido" });
            DropTable("dbo.Produto");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Pedido");
            DropTable("dbo.Item");
        }
    }
}
