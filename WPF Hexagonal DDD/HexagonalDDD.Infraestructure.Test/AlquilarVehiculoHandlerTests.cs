using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WPFHexagonalDDD.Applicaion.UseCases;

namespace WPFHexagonalDDD.Infraestructure.Test
{
    [TestClass]
    public class AlquilarVehiculoHandlerTests
    {


        [TestMethod]
        public async Task Cliente_SinAlquilerActivo_GuardaAlquiler()
        {
            var alquilerRepoFalso = new AlquilerRepositoryFalso(clienteYaTieneAlquiler: false);
            var handler = new AlquilarVehiculoHandler(alquilerRepoFalso);

            await handler.ExecuteAsync(clienteID: 1, vehiculoId: 5);

            Assert.IsTrue(alquilerRepoFalso.SeLlamoSaveAsync);
        }
    }
}
