﻿using InmuebleVenta.Entities;
using InmuebleVenta.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
    public class ComprobanteRepository : Repository<Comprobante>, IComprobanteRepository
    {
              public ComprobanteRepository(InmuebleVentaDbContext context):base(context)
		{
		}





      /*  private readonly InmuebleVentaDbContext _Context;
        private ComprobanteRepository()
        {
                
        }
        public ComprobanteRepository(InmuebleVentaDbContext context)
        {
            
            _Context = context;
        }
       */ 
    }
}
