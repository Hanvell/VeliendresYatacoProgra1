using InmuebleVenta.Entities;
using InmuebleVenta.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
  public   class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
          public DepartamentoRepository(InmuebleVentaDbContext context):base(context)
		{
		}

      
      
      /*    private readonly InmuebleVentaDbContext _Context;
        private DepartamentoRepository()
        {
                
        }

        public DepartamentoRepository(InmuebleVentaDbContext context)
        {
           
            _Context = context;
        }
     */
    }
}
