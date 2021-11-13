using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DataBase.Models
{
    public class clientes
    {
        [Key]
        public int id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage ="Ingrese los datos")]
        public string mombreCompleto { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Ingrese la direccion de entrega")]
        public string Direccion { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Ingrese su numero de telefono")]
        public string Telefono { get; set; }
        public virtual ICollection<pedidos> pedidos { get; set; }

        public static List<clientes> Listar()
        {
            var ListaUsuario = new List<clientes>();

            ListaUsuario.Add(new clientes()
            {
                mombreCompleto = "luis",
                Direccion = "San Salvador",
                Telefono = "22040404"
            });

            return ListaUsuario;
        }

    }
}