namespace InfnetTecCsharpCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pedido_CamposObrigatorios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produto", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "Nome", c => c.String());
        }
    }
}
