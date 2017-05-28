using InmuebleVenta.Entities;
using InmuebleVenta.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
  public  class EmpleadoRepository : Repository<Empleado>, IEmpleadoRepository
    {
            public EmpleadoRepository(InmuebleVentaDbContext context):base(context)
		{
		}

     /*   private readonly InmuebleVentaDbContext _Context;
        private EmpleadoRepository()
        {

        }
        public EmpleadoRepository(InmuebleVentaDbContext context)
        {
            
            _Context = context;
        }
      */
    }
}
