using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFHexagonalDDD.Domain.Aggregates.Item
{
    public class AlquilerAggregate
    {
        public string Alquilerid { get; private set; }
        public int Vehiculoid { get; private set; }
        public int Clienteid { get; private set; }
        public bool Devuelto { get; private set; }

        //Uso NHibernet
        /// <summary>
        /// Solo para uso con NHibernate
        /// </summary>
        protected AlquilerAggregate() { }

        //creo objeto a utilizar al alquilar el vehiculo por el cliente
       /// <summary>
       /// Objeto para alquilar el vehiculo al cliente
       /// </summary>
       /// <param name="vehiculoid"></param>
       /// <param name="clienteid"></param>
       public AlquilerAggregate(int vehiculoid, int clienteid)
        {
            Vehiculoid = vehiculoid;
            Clienteid = clienteid;
            Devuelto = false;
        }

        //Actualiza el estado del vehiculo si es devuelto
        public void Devolver()
        {
            Devuelto = true;
        }
    }
}
