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
        Task SaveAsync(VehiculoAggregate aggregate);

    }
}
