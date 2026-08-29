using NHibernate;
using System.Threading.Tasks;
using WPFHexagonalDDD.Domain.Aggregates.Item;
using WPFHexagonalDDD.Domain.Repositories;

namespace WPFHexagonalDDD.Infraestructure.Persistence.Oracle
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly ISessionFactory _sessionFactory;
        public VehiculoRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public async Task SaveAsync(VehiculoAggregate aggregate)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {

                await session.SaveAsync(aggregate);
                await transaction.CommitAsync();
            }
        }


    }
}
