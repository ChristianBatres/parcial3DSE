using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MVC_DataBase.Controllers;
using MVC_DataBase.Models;


namespace MVC_DataBase.Tests.Controllers
{
    [TestClass]
    public class clientesControllerTest
    {
        [TestMethod]
        public void AgregarClienteNoRepetido()
        {
            // Arrange
            clientesController controller = new clientesController();
            var cliente = new clientes()
            {
                mombreCompleto = "Alberto Batres",
                Direccion = "San Salvador",
                Telefono = "22352532",
               
            };
            // Act
            var result = controller.Agregar(cliente);
            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void NoAgregarClienteRepetido()
        {
            // Arrange
            clientesController controller = new clientesController();
            var usuario = new clientes()
            {
                mombreCompleto = "Luis",
                Direccion = "San Salvador",
                Telefono = "22040404",
            };
            // Act
            var result = controller.Agregar(usuario);
            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void NoAgregarClienteConNombreVacio()
        {
            // Arrange
            clientesController controller = new clientesController();
            var usuario = new clientes()
            {
                mombreCompleto = ""
            };
            // Act
            var result = controller.Agregar(usuario);
            // Assert
            Assert.AreEqual(6, result);
        }


        [TestMethod]
        public void NoAgregarClienteConDireccionVacio()
        {
            // Arrange
            clientesController controller = new clientesController();
            var usuario = new clientes()
            {
                Direccion = ""
            };
            // Act
            var result = controller.Agregar(usuario);
            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void NoAgregarClienteConTelefonoVacio()
        {
            // Arrange
            clientesController controller = new clientesController();
            var usuario = new clientes()
            {
                Telefono = ""
            };
            // Act
            var result = controller.Agregar(usuario);
            // Assert
            Assert.AreEqual(6, result);
        }
    }
}
