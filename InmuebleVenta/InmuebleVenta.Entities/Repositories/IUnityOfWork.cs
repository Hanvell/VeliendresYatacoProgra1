using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Entities.Repositories
{

    //Debe heredar de IDisposable para que el Garbage Collector
    //pueda liberar memoria que ya no utilice.
    public interface IUnityOfWork : IDisposable
    {
        //Cada una de las propiedades deben ser solo lectura
        IBoletaRepository Boletas { get; }
        IClienteRepository Clientes { get; }
        IComprobanteRepository Comprobantes { get; }
        IContratoRepository Contratos { get; }
        IContratoAlquilerRepository ContratoAlquileres { get; }
        IContratoReservaRepository ContratoReservas { get; }
        IContratoVentaRepository ContratoVentas { get; }
        IDepartamentoRepository Departamentos { get; }
        IDistritoRepository Distritos { get; }
        IEmpleadoRepository Empleados { get; }
        IFacturaRepository Facturas { get; }
        IInmuebleRepository Inmuebles { get; }
        IPropietarioRepository Propietarios { get; }
        IProvinciaRepository Provincias { get; }
        ITipoInmuebleRepository TipoInmuebles { get; }
        IUbigeoRepository Ubigeos { get; }
        IVisitaRepository Visitas { get; }

        //Metodo que guardara lo cambios en la base de datos.
        int SaveChanges();
        
        void StateModified(object entity);
    }
}