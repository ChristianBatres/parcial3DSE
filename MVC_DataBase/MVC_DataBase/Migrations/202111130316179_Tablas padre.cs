namespace MVC_DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablaspadre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.clientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        mombreCompleto = c.String(nullable: false, maxLength: 100),
                        Direccion = c.String(nullable: false, maxLength: 200),
                        Telefono = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.clientes");
        }
    }
}
