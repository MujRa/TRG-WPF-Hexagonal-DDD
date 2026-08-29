using System;
using WPFHexagonalDDD.Infraestructure.Persistence.Oracle;
using WPFHexagonalDDD.Applicaion.UseCases;
using WPFHexagonalDDD.Domain.Repositories;
using System.Threading.Tasks;


namespace WPF_Hexagonal_DDD
{
    class Program
    {



        static async Task Main(string[] args)
        {
            var sessionFactory = NHibernateSessionFactory.GetSessionFactory("Data Source=localhost:1521/XEPDB1;User Id=rentcar;Password=rentcar123;");

            var vehiculoRepository = new VehiculoRepository(sessionFactory);
            var handler = new AgregarVehiculoaFlota(vehiculoRepository);

            try
            {
                await handler.ExecuteAsync(2024, "Ford", "1234ABC");
                Console.WriteLine("Vehículo guardado correctamente en Oracle");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

        }
        /*
         No utilizar. Para la capa de presentacion Utiliza segun tu preferencia WPF o Windows Forms.
         Este punto de inicio solo es funcional en un proyecto de consola
         */
    /*    static void Main(string[] args)
        {
            IHost host = Bootstrapper.BuildHost();
            host.Start();

            Console.WriteLine("Aplicación iniciada. Presiona cualquier tecla para salir...");
            Console.ReadKey();

            host.StopAsync();
            host.Dispose();
        }*/
    }
}
