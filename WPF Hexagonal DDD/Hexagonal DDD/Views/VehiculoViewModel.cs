using WPFHexagonalDDD.Applicaion.UseCases;
using WPFHexagonalDDD.Applicaion;
using System.ComponentModel;
using System.Windows.Input;
using WPFHexagonalDDD.Infraestructure.Persistence.Oracle;
using NHibernate.Engine;
using System;


namespace WPF_Hexagonal_DDD.Views
{
    public class VehiculoViewModel : INotifyPropertyChanged
    {
        private readonly AgregarVehiculoaFlota _agregarHandler;
        private readonly AlquilarVehiculoHandler _alquilarHandler;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        private string _mensaje;
        public string Mensaje
        {
            get => _mensaje;
            set { _mensaje = value; OnPropertyChanged(nameof(Mensaje)); }
        }

        private string _anio;
        public string Anio
        {
            get => _anio;
            set { _anio = value; OnPropertyChanged(nameof(Anio)); }
        }

        private string _marca;
        public string Marca
        {
            get => _marca;
            set { _marca = value; OnPropertyChanged(nameof(Marca)); }
        }

        private string _matricula;
        public string Matricula
        {
            get => _matricula;
            set { _matricula = value; OnPropertyChanged(nameof(Matricula)); }
        }

        public ICommand AgregarVehiculoCommand { get; }

        public VehiculoViewModel()
        {
            var sessionFactory = NHibernateSessionFactory.GetSessionFactory(
                "Data Source=localhost:1521/XEPDB1;User Id=rentcar;Password=rentcar123;");

            _agregarHandler = new AgregarVehiculoaFlota(new VehiculoRepository(sessionFactory));
            _alquilarHandler = new AlquilarVehiculoHandler(new AlquilerRepository(sessionFactory));

            AgregarVehiculoCommand = new RelayCommand(
               execute: async() =>
               {
                   try
                   {
                       await _agregarHandler.ExecuteAsync(int.Parse(Anio), Marca, Matricula);
                       Mensaje = "Vehículo agregado correctamente";
                   }
                   catch (Exception ex)
                   {
                       Mensaje = ex.Message;
                   }
               },
               canExecute: () => !string.IsNullOrWhiteSpace(Anio) && !string.IsNullOrWhiteSpace(Marca) && !string.IsNullOrWhiteSpace(Matricula)
               );
        }

    }
}
