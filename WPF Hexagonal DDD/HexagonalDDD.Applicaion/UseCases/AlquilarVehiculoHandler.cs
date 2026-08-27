using System;
using System.Threading.Tasks;
using HexagonalDDD.Domain.Aggregates.Item;
using HexagonalDDD.Domain.Repositories;
using WPFHexagonalDDD.Domain.Aggregates.Item;
using WPFHexagonalDDD.Domain.Repositories;

namespace WPFHexagonalDDD.Applicaion.UseCases
{
    public class AlquilarVehiculoHandler
    {
        private readonly IAlquilerRepository _alquilerRepository;
        public AlquilarVehiculoHandler(IAlquilerRepository alquilerRepository)
        {
            _alquilerRepository = alquilerRepository;
        }

        /// <summary>
        /// Registra alquiler de un vehiculo si el cliente
        /// no tiene otro alquiler
        /// </summary>
        /// <param name="clienteID"></param>
        /// <param name="vehiculoId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task ExecuteAsync(int clienteID, int vehiculoId)
        {
            // Valido que el cliente no tenga un alquiler
            if (await _alquilerRepository.ClienteConAlquilerAsync(clienteID))
                throw new Exception("Cliente ya tiene un vehiculo en alquiler");

            //Guarod la informacion si el cliente no tiene un alquiler
            var aggregate = new AlquilerAggregate(vehiculoId, clienteID);
            await _alquilerRepository.SaveAsync(aggregate);
        }
    }
}
