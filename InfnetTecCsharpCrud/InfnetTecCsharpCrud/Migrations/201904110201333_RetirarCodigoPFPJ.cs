namespace InfnetTecCsharpCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetirarCodigoPFPJ : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pessoa", "CodigoPF");
            DropColumn("dbo.Pessoa", "CodigoPJ");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pessoa", "CodigoPJ", c => c.Int());
            AddColumn("dbo.Pessoa", "CodigoPF", c => c.Int());
        }
    }
}
