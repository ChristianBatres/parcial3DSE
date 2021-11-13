using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MVC_DataBase.Controllers;
using MVC_DataBase.Models;

namespace MVC_DataBase.Tests.Controllers
{
    [TestClass]
    public class pedidoControllerTest
    {
        [TestMethod]
        public void AgregarPedidoNoRepetido()
        {
            // Arrange
            pedidosController controller = new pedidosController();
            var pedidos = new pedidos()
            {
                cliente_Id = 2,
                producto_Id = 2,
                cantidad = 3,

            };
            // Act
            var result = controller.Agregar(pedidos);
            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void NoAgregarPedidoConCantidaVacio()
        {
            // Arrange
            pedidosController controller = new pedidosController();
            var pedidos = new pedidos()
            {
                cantidad = ' '
            };
            // Act
            var result = controller.Agregar(pedidos);
            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void NoAgregarPedidoConCliemtedaVacio()
        {
            // Arrange
            pedidosController controller = new pedidosController();
            var pedidos = new pedidos()
            {
                cliente_Id = ' '
            };
            // Act
            var result = controller.Agregar(pedidos);
            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void NoAgregarPedidoConProductodaVacio()
        {
            // Arrange
            pedidosController controller = new pedidosController();
            var pedidos = new pedidos()
            {
                producto_Id = ' '
            };
            // Act
            var result = controller.Agregar(pedidos);
            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void NoAgregarPedidoConCantidadNegatica()
        {
            // Arrange
            pedidosController controller = new pedidosController();
            var pedidos = new pedidos()
            {
                cantidad = -300
            };
            // Act
            var result = controller.Agregar(pedidos);
            // Assert
            Assert.AreEqual(6, result);
        }

    }
}
