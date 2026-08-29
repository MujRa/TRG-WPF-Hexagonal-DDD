using WPFHexagonalDDD.Domain.Aggregates.Item;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WPFHexagonalDDD.Unit.Test
{
    [TestClass]
    public class VehiculoAggregateTests
    {
        [TestMethod]
        public void Constructor_ConMasde5anios_LanzaExeption()
        {
            int anioInvalido = DateTime.Now.Year - 10;
            Assert.ThrowsException<Exception>(() =>
                new VehiculoAggregate(anioInvalido, "Toyora", "XYZ987"));
        }

        [TestMethod]
        public void Constructor_ConMenosde5Anios_CreaVehiculoCorrecto()
        {
            int anioValido = DateTime.Now.Year - 3;
            var vehiculo = new VehiculoAggregate(anioValido, "BMW", "ABC123");
            Assert.AreEqual("BMW", vehiculo.VehiculoMarca);
        }

    }
}
