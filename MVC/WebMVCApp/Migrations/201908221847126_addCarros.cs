namespace WebMVCApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCarros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Placa = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        UsuarioCriacao = c.Int(nullable: false),
                        UsuarioEdicao = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataEdicao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carroes");
        }
    }
}
