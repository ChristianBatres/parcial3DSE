using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DataBase.Models
{
    public class productos
    {
        [Key]
        public int id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Ingrese los datos")]
        public string mombreProducto { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Ingrese la direccion de entrega")]
        public string precio { get; set; }
        [StringLength(20)]

        [Required(ErrorMessage = "Ingrese su numero de telefono")]
        public string descripcion { get; set; }

        public virtual ICollection<pedidos> pedidos { get; set; }
        public static List<productos> Listar()
        {
            var ListaProductos = new List<productos>();

            ListaProductos.Add(new productos()
            {
                mombreProducto = "Monitor",
                precio = "210",
                descripcion = "144Hz, 23 pulgadas"
            });

            return ListaProductos;
        }
    }
}