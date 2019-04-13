namespace InfnetTecCsharpCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovasValidacoes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoa", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoa", "Nome", c => c.String());
        }
    }
}
