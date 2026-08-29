using System;
using System.Threading.Tasks;
using WPFHexagonalDDD.Domain.Aggregates.Item;

namespace WPFHexagonalDDD.Domain.Repositories
{
    public interface IAlquilerRepository
    {
        //Repoistorio para trabajar con el alquiler

        //Guarda el alquiler del clienyte
        /// <summary>
        /// Guarda el alquiler del vehiculo
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task SaveAsync(AlquilerAggregate aggregate);

        
        //Valida si el cliente tiene alquiler
        /// <summary>
        /// Valida si el cliente tiene un alquiler
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        Task<bool> ClienteConAlquilerAsync(int clienteId);
    }
}
