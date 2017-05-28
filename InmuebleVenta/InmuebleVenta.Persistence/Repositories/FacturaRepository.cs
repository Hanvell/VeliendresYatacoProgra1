using InmuebleVenta.Entities;
using InmuebleVenta.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
    public class FacturaRepository : Repository<Factura>, IFacturaRepository
    {
          public FacturaRepository(InmuebleVentaDbContext context):base(context)
		{
		}

        
        /*    private readonly InmuebleVentaDbContext _Context;
        private FacturaRepository()
        {
                
        }
        public FacturaRepository(InmuebleVentaDbContext context)
        {
            
            _Context = context;
        }
     */
    }
}
