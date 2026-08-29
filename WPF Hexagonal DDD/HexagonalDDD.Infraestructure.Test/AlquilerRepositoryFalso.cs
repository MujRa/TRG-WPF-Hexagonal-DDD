
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using WPFHexagonalDDD.Applicaion.UseCases;
using WPFHexagonalDDD.Domain.Aggregates.Item;
using WPFHexagonalDDD.Domain.Repositories;

namespace WPFHexagonalDDD.Infraestructure.Test
{
    public class AlquilerRepositoryFalso : IAlquilerRepository
    {
        private readonly bool _clienteYaTieneAlquiler;
        public bool SeLlamoSaveAsync { get; private set; } = false;

        public AlquilerRepositoryFalso(bool clienteYaTieneAlquiler)
        {
            _clienteYaTieneAlquiler = clienteYaTieneAlquiler;
        }

        public Task<bool> ClienteConAlquilerAsync(int clienteId)
            => Task.FromResult(_clienteYaTieneAlquiler);

        public Task SaveAsync(AlquilerAggregate aggregate)
        {
            SeLlamoSaveAsync = true;
            return Task.CompletedTask;
        }

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
