using InmuebleVenta.Entities;
using InmuebleVenta.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
    public class ContratoVentaRepository : Repository<ContratoVenta>, IContratoVentaRepository
    {
              public ContratoVentaRepository(InmuebleVentaDbContext context):base(context)
		{
		}




      /*  private readonly InmuebleVentaDbContext _Context;
        private ContratoVentaRepository()
        {

        }
        public ContratoVentaRepository(InmuebleVentaDbContext context)
        {
            // TODO: Complete member initialization
            _Context = context;
        }
       */
    }
}
