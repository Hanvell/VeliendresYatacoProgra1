using InmuebleVenta.Entities;
using InmuebleVenta.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
         public  ClienteRepository(InmuebleVentaDbContext context):base(context)
		{
		}





    /*    private readonly InmuebleVentaDbContext _Context;

        private ClienteRepository()
        {

        }
        public ClienteRepository(InmuebleVentaDbContext context)
        {
            
           _Context = context;
        }
     */
    }
}
