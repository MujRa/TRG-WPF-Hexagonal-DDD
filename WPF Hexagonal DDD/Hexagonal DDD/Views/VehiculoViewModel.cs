using WPFHexagonalDDD.Applicaion.UseCases;
using WPFHexagonalDDD.Applicaion;
using System.Configuration;
using System.ComponentModel;
using System.Windows.Input;
using WPFHexagonalDDD.Infraestructure.Persistence.Oracle;
using NHibernate.Engine;
using System;
using System.Configuration;
using NHibernate.Cfg;


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
        /// <summary>
        /// Agregar vehiculo a flota
        /// </summary>
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

        /// <summary>
        /// Alquilar vehiculo
        /// </summary>
        private int _clienteId;
        private int _anioFlota;

        public int ClienteId
        {
            get => _clienteId;
            set { _clienteId = value; OnPropertyChanged(nameof(ClienteId)); }
        }

        private int _vehiculoId;

        public int VehiculoId
        {
            get => _vehiculoId;
            set { _vehiculoId = value; OnPropertyChanged(nameof(VehiculoId)); }
        }

        private bool _devuelto;
        public bool Devuelto
        {
            get => _devuelto;
            set { _devuelto = value; OnPropertyChanged(nameof(Devuelto)); }
        }


        public ICommand AgregarVehiculoCommand { get; }
        public ICommand AgregarAlquilerCommand { get; }

        /// <summary>
        /// Conector para alguilar vehiculo
        /// o agregar vehiculo a flota
        /// </summary>
        public VehiculoViewModel()
        {
            var sessionFactory = NHibernateSessionFactory.GetSessionFactory(
                ConfigurationManager.ConnectionStrings["TSG_HEXAGONAL"].ConnectionString);

            _agregarHandler = new AgregarVehiculoaFlota(new VehiculoRepository(sessionFactory));
            _alquilarHandler = new AlquilarVehiculoHandler(new AlquilerRepository(sessionFactory));
            _anioFlota = int.Parse(ConfigurationManager.AppSettings["anioFlota"].ToString());
            //Agrega vehiculo a flota <5años
            AgregarVehiculoCommand = new RelayCommand(
               execute: async () =>
               {
                   try
                   {
                       await _agregarHandler.ExecuteAsync(int.Parse(Anio), Marca, Matricula,_anioFlota);
                       Mensaje = "Vehículo agregado correctamente";
                   }
                   catch (Exception ex)
                   {
                       Mensaje = ex.Message;
                   }
               },
               canExecute: () => !string.IsNullOrWhiteSpace(Anio) && !string.IsNullOrWhiteSpace(Marca) && !string.IsNullOrWhiteSpace(Matricula)
               );

            //Alquila vehiculo a cliente sin otro alquiler activo
            AgregarAlquilerCommand = new RelayCommand(
                execute: async() =>
                {
                    try
                    {
                        await _alquilarHandler.ExecuteAsync(ClienteId, VehiculoId);
                        Mensaje = "Vehiculo alquilado correctamente";
                    }
                    catch (Exception ex)
                    {
                        Mensaje = ex.Message;
                    }
                });
        }


    }
}
