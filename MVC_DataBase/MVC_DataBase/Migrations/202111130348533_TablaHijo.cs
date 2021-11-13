namespace MVC_DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaHijo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.pedidos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        cliente_Id = c.Int(nullable: false),
                        pedido_Id = c.Int(nullable: false),
                        productos_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.clientes", t => t.cliente_Id, cascadeDelete: true)
                .ForeignKey("dbo.pedidos", t => t.pedido_Id)
                .ForeignKey("dbo.productos", t => t.productos_id)
                .Index(t => t.cliente_Id)
                .Index(t => t.pedido_Id)
                .Index(t => t.productos_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.pedidos", "productos_id", "dbo.productos");
            DropForeignKey("dbo.pedidos", "pedido_Id", "dbo.pedidos");
            DropForeignKey("dbo.pedidos", "cliente_Id", "dbo.clientes");
            DropIndex("dbo.pedidos", new[] { "productos_id" });
            DropIndex("dbo.pedidos", new[] { "pedido_Id" });
            DropIndex("dbo.pedidos", new[] { "cliente_Id" });
            DropTable("dbo.pedidos");
        }
    }
}
