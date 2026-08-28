using NHibernate;
using NHibernate.Cfg;

namespace WPFHexagonalDDD.Infraestructure.Persistence.Oracle
{
    public static class NHibernateSessionFactory
    {
        private static ISessionFactory _sessionFactory;

       /// <summary>
       /// Configuración Docker para leer las tablas
       /// </summary>
       /// <param name="connectionString"></param>
       /// <returns></returns>
       public static ISessionFactory GetSessionFactory(string connectionString)
        {
            if (_sessionFactory == null)
            {
                var configuration = new Configuration();
                configuration.DataBaseIntegration(db =>
                {
                    db.ConnectionString = connectionString;
                    db.Dialect<NHibernate.Dialect.Oracle10gDialect>();
                    db.Driver<NHibernate.Driver.OracleManagedDataClientDriver>();
                });

                configuration.AddAssembly(typeof(WPFHexagonalDDD.Domain.Aggregates.Item.VehiculoAggregate).Assembly);
                configuration.AddAssembly(typeof(WPFHexagonalDDD.Domain.Aggregates.Item.AlquilerAggregate).Assembly);
                // AddAssembly escanea TODO el ensamblado buscando .hbm.xml marcados como Embedded Resource —
                // por eso importaba tanto ese Build Action que configuramos la vez pasada

                _sessionFactory = configuration.BuildSessionFactory();
            }
            return _sessionFactory;
        }
    }
}
