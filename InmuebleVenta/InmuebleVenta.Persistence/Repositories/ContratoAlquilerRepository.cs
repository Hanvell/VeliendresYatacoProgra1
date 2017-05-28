using InmuebleVenta.Entities;
using InmuebleVenta.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
    public class ContratoAlquilerRepository : Repository<ContratoAlquiler>, IContratoAlquilerRepository
    {

        public ContratoAlquilerRepository(InmuebleVentaDbContext context):base(context)
		{
		}




       /* private readonly InmuebleVentaDbContext _Context;
        private ContratoAlquilerRepository()
        {

        }

        public ContratoAlquilerRepository(InmuebleVentaDbContext context)
        {
            
            _Context = context;
        }
        */
    }
}
