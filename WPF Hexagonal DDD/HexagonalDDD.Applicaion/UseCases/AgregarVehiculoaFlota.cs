using System;
using System.Threading.Tasks;
using HexagonalDDD.Domain.Aggregates.Item;
using HexagonalDDD.Domain.Repositories;
using WPFHexagonalDDD.Domain.Aggregates.Item;
using WPFHexagonalDDD.Domain.Repositories;


namespace WPFHexagonalDDD.Applicaion.UseCases
{
    public class AgregarVehiculoaFlota
    {
        private readonly IVehiculoRepository _vehiculorepository;
        public AgregarVehiculoaFlota(IVehiculoRepository vehiculorepository)
        {
            _vehiculorepository = vehiculorepository;
        }
        /// <summary>
        /// Valida si el vehiculo tiene menos de 5 años y guarda en la flota 
        /// si tiene mas de 5 años no se agrega a la flota
        /// </summary>
        /// <param name="vehiculoanio"></param>
        /// <param name="vehiculomarca"></param>
        /// <param name="vehiculomatricula"></param>
        /// <param name="anioFlota"></param>
        /// <returns></returns>
        public async Task ExecuteAsync(int vehiculoanio, string vehiculomarca, string vehiculomatricula, int anioFlota)
        {

            //Guardar vehiculo en flota
            var aggregate = new VehiculoAggregate(vehiculoanio,vehiculomarca, vehiculomatricula, anioFlota);
            await _vehiculorepository.SaveAsync(aggregate);
        }
    }
}
