using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_DataBase.Models
{
    public class pedidos
    {
        [Key]
        public int id { get; set; }

        public decimal cantidad { get; set; }

        [ForeignKey("cliente")] //se utilizar ya que para la llave forarea no se utiliza la convesión de nombres
        public int cliente_Id { get; set; } //llave foranea
        public virtual clientes cliente { get; set; } // propiedad de navegación de referencia


        [ForeignKey("producto")] //se utilizar ya que para la llave forarea no se utiliza la convesión de nombres
        public int producto_Id { get; set; } //llave foranea
        public virtual productos producto { get; set; } // propiedad de navegación de referencia


        public static List<pedidos> Listar()
        {
            var ListaPedidos = new List<pedidos>();

            ListaPedidos.Add(new pedidos()
            {
                cantidad = 30,
                cliente_Id = 1,
                producto_Id = 2
            });

            return ListaPedidos;
        }
    }
}