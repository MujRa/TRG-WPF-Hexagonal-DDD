using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFHexagonalDDD.Domain.Aggregates.Item
{
    public class VehiculoAggregate
    {
        public int VehiculoId { get; private set; }
        public int VehiculoAnio { get; private set; }
        public string VehiculoMarca { get; private set; }
        public string VehiculoMatricula { get; private set; }

        //Uso NHibernet
        /// <summary>
        /// Solo para uso de NHibernet
        /// </summary>
        protected VehiculoAggregate() { }


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
