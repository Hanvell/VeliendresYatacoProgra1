using InmuebleVenta.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmuebleVenta.Entities;

namespace InmuebleVenta.Persistence.Repositories
{
    public class UnityOfWork :IUnityOfWork
    {
        private readonly InmuebleVentaDbContext _Context;
       private static UnityOfWork _Instance;
       private static readonly object _Look = new object();

        public IBoletaRepository Boletas { get; private set; }
        public IClienteRepository Clientes { get; private set; }
        public IComprobanteRepository Comprobantes { get; private set; }
        public IContratoRepository Contratos { get; private set; }
        public IContratoAlquilerRepository ContratoAlquileres { get; private set; }
        public IContratoReservaRepository ContratoReservas { get; private set; }
        public IContratoVentaRepository ContratoVentas { get; private set; }
        public IDepartamentoRepository Departamentos { get; private set; }
        public IDistritoRepository Distritos { get; private set; }
        public IEmpleadoRepository Empleados { get; private set; }
        public IFacturaRepository Facturas { get; private set; }
        public IInmuebleRepository Inmuebles { get; private set; }
        public IPropietarioRepository Propietarios { get; private set; }
        public IProvinciaRepository Provincias { get; private set; }
        public ITipoInmuebleRepository TipoInmuebles { get; private set; }
       public  IUbigeoRepository Ubigeos { get; private set; }
       public  IVisitaRepository Visitas { get; private set; }

        //Se define el constructor por defecto como privado para
        //que se fuerce a utilizar la propiead Instance
       private UnityOfWork()
       {

            //Se crea un unico concexto de base de datos
            //para apuntar todos los repositorios a la misma base de datos

            _Context = new InmuebleVentaDbContext ();

            Boletas = new BoletaRepository(_Context);
            Clientes = new ClienteRepository(_Context);
            Comprobantes = new ComprobanteRepository(_Context);
            ContratoAlquileres = new ContratoAlquilerRepository(_Context);
            Contratos = new ContratoRepository(_Context);
            ContratoReservas = new ContratoReservaRepository(_Context);
            ContratoVentas = new ContratoVentaRepository(_Context);
            Departamentos = new DepartamentoRepository(_Context);
            Distritos = new DistritoRepository(_Context);
            Empleados = new EmpleadoRepository(_Context);
            Facturas = new FacturaRepository(_Context);
            Inmuebles = new InmuebleRepository(_Context);
            Propietarios = new PropietarioRepository(_Context);
            Provincias = new ProvinciaRepository(_Context);
            TipoInmuebles = new TipoInmuebleRepository(_Context);
            Ubigeos = new UbigeoRepository(_Context);
            Visitas = new VisitaRepository(_Context);


        }


       /* public UnityOfWork(InmuebleVentaDbContext context)
        {
            //Se crea un unico concexto de base de datos
            //para apuntar todos los repositorios a la misma base de datos
            _Context = context;
            Boletas= new BoletaRepository(_Context);
            Clientes = new ClienteRepository(_Context);
            Comprobantes = new ComprobanteRepository(_Context);
            ContratoAlquileres= new ContratoAlquilerRepository(_Context);
            Contratos = new ContratoRepository(_Context);
            ContratoReservas = new ContratoReservaRepository(_Context);
            ContratoVentas = new ContratoVentaRepository(_Context);
            Departamentos = new DepartamentoRepository(_Context);
            Distritos = new DistritoRepository(_Context);
            Empleados = new EmpleadoRepository(_Context);
            Facturas = new FacturaRepository(_Context);
            Inmuebles = new InmuebleRepository(_Context);
            Propietarios= new PropietarioRepository(_Context);
            Provincias = new ProvinciaRepository(_Context);
            TipoInmuebles = new TipoInmuebleRepository(_Context);
            Ubigeos = new UbigeoRepository(_Context);
            Visitas = new VisitaRepository(_Context);
            

        }
        */
        //Implementacion del patron singleton para instanciar  la clase UnityOfWork
        //Con este patron se asugura que en cualquier parte del codigo que se quiera
        //intanciar la base de datos , se devuelva una unica referencia

        public static UnityOfWork Instance
        {
            get
            {

                //Variable de control para manejar el acceso concurrente 
                //al instanciamiento de la clase UnityOfWork.
                lock (_Look)
                {
                    if (_Instance == null)

                        _Instance = new UnityOfWork();
                }
                return _Instance;
            }
        }
        

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        public void StateModified(object Entity)
        {
           // throw new NotImplementedException();
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
