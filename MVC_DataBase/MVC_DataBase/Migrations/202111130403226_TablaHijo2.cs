namespace MVC_DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaHijo2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.pedidos", "pedido_Id", "dbo.pedidos");
            DropForeignKey("dbo.pedidos", "productos_id", "dbo.productos");
            DropIndex("dbo.pedidos", new[] { "pedido_Id" });
            DropIndex("dbo.pedidos", new[] { "productos_id" });
            RenameColumn(table: "dbo.pedidos", name: "productos_id", newName: "producto_Id");
            AlterColumn("dbo.pedidos", "producto_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.pedidos", "producto_Id");
            AddForeignKey("dbo.pedidos", "producto_Id", "dbo.productos", "id", cascadeDelete: true);
            DropColumn("dbo.pedidos", "pedido_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.pedidos", "pedido_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.pedidos", "producto_Id", "dbo.productos");
            DropIndex("dbo.pedidos", new[] { "producto_Id" });
            AlterColumn("dbo.pedidos", "producto_Id", c => c.Int());
            RenameColumn(table: "dbo.pedidos", name: "producto_Id", newName: "productos_id");
            CreateIndex("dbo.pedidos", "productos_id");
            CreateIndex("dbo.pedidos", "pedido_Id");
            AddForeignKey("dbo.pedidos", "productos_id", "dbo.productos", "id");
            AddForeignKey("dbo.pedidos", "pedido_Id", "dbo.pedidos", "id");
        }
    }
}
