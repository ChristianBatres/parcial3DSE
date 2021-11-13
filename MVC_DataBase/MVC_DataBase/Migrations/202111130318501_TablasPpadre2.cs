namespace MVC_DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablasPpadre2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.productos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        mombreProducto = c.String(nullable: false, maxLength: 100),
                        precio = c.String(nullable: false, maxLength: 200),
                        descripcion = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.productos");
        }
    }
}
