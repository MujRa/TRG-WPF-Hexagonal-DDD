using System.Threading.Tasks;
using HexagonalDDD.Domain.Aggregates.Item;
using WPFHexagonalDDD.Domain.Aggregates.Item;

namespace WPFHexagonalDDD.Domain.Repositories
{
    public interface IVehiculoRepository
    {
        //Repositorio para trabajar con el vehiculo
        /// <summary>
        /// Guarda el vehiculo en la flota
        /// </summary>
        /// <param name="aggregate"></param>
        /// <returns></returns>
        Task SaveAsyn(VehiculoAggregate aggregate);

        /// <summary>
        /// Valida que el vehiculo tenga mas de 5 años
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        Task<bool> VehiculoMayor5Async(int clienteId);

    }
}
