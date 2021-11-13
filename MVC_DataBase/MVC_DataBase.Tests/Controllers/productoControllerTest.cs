using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MVC_DataBase.Controllers;
using MVC_DataBase.Models;

namespace MVC_DataBase.Tests.Controllers
{
    [TestClass]
    public class productoControllerTest
    {
        

            [TestMethod]
            public void AgregarProductoNoRepetido()
            {
                // Arrange
                productosController controller = new productosController();
                var productos= new productos()
                {
                    mombreProducto = "USB",
                    precio = "8",
                    descripcion = "64 GB",

                };
                // Act
                var result = controller.Agregar(productos);
                // Assert
                Assert.AreEqual(0, result);
            }

            [TestMethod]
            public void NoAgregarProductoeRepetido()
            {
                // Arrange
                productosController controller = new productosController();
                var productos = new productos()
                {
                    mombreProducto = "Memoria RAM",
                    precio = "32",
                    descripcion = "DDR4, 8GB",
                };
                // Act
                var result = controller.Agregar(productos);
                // Assert
                Assert.AreEqual(1, result);
            }
            [TestMethod]
            public void NoAgregarProductoConNombreVacio()
            {
                // Arrange
                productosController controller = new productosController();
                var producto = new productos()
                {
                    mombreProducto = ""
                };
                // Act
                var result = controller.Agregar(producto);
                // Assert
                Assert.AreEqual(6, result);
            }


            [TestMethod]
            public void NoAgregarProductoConDescripcionVacio()
            {
                // Arrange
                productosController controller = new productosController();
                var productos = new productos()
                {
                    descripcion = ""
                };
                // Act
                var result = controller.Agregar(productos);
                // Assert
                Assert.AreEqual(6, result);
            }

            [TestMethod]
            public void NoAgregarProductosConPrecioVacio()
            {
                // Arrange
                productosController controller = new productosController();
                var productos = new productos()
                {
                    precio = ""
                };
                // Act
                var result = controller.Agregar(productos);
                // Assert
                Assert.AreEqual(6, result);
            }
        
    }
}
