using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFHexagonalDDD.Domain.Aggregates.Item
{
    public class VehiculoAggregate
    {
        public int VehiculoAnio { get; set; }
        public string VehiculoMarca { get; set; }
        public string VehiculoMatricula { get; set; }

        //Uso NHibernet
        public VehiculoAggregate() { }
        /// <summary>
        /// Permite agregar el vehiculo a la flota si tiene menos de 5 años
        /// </summary>
        /// <param name="vehiculoanio"></param>
        /// <param name="vehiculomarca"></param>
        /// <param name="vehiculoMatricula"></param>
        /// <exception cref="Exception"></exception>
        public VehiculoAggregate(int vehiculoanio, string vehiculomarca, string vehiculoMatricula)
        {
            //Validar si el vehiculo tiene mas de 5 años
            if ((DateTime.Now.Year - vehiculoanio) > 5)
                throw new Exception("El vehiculo tiene más de 5 años, no puede pertenecer a la flota");

            VehiculoAnio = vehiculoanio;
            VehiculoMarca = vehiculomarca;
            VehiculoMatricula = vehiculoMatricula;
        }
    }
}
