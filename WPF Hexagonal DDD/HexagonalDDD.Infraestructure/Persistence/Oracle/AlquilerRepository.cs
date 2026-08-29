using NHibernate;
using NHibernate.Linq;
using System.Threading.Tasks;
using WPFHexagonalDDD.Domain.Aggregates.Item;
using WPFHexagonalDDD.Domain.Repositories;

namespace WPFHexagonalDDD.Infraestructure.Persistence.Oracle
{
    public class AlquilerRepository : IAlquilerRepository
    {
        private readonly ISessionFactory _sessionFactory;
        public AlquilerRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

      /// <summary>
      /// Configuración Docker para guardar alquiler
      /// </summary>
      /// <param name="aggregate"></param>
      /// <returns></returns>
      public async Task SaveAsync(AlquilerAggregate aggregate)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                await session.SaveAsync(aggregate);
                await transaction.CommitAsync();
            }
        }
       /// <summary>
       /// Configuración Docker para validar alquiler de cliente
       /// </summary>
       /// <param name="clienteId"></param>
       /// <returns></returns>
       public async Task<bool> ClienteConAlquilerAsync(int clienteId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                return await session.Query<AlquilerAggregate>()
                    .AnyAsync(a => a.Clienteid == clienteId && !a.Devuelto);
            }
        }

    }
}
