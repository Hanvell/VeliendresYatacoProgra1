﻿using InmuebleVenta.Entities;
using InmuebleVenta.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
    public class DistritoRepository : Repository<Distrito>, IDistritoRepository
    {
            public DistritoRepository(InmuebleVentaDbContext context):base(context)
		{
		}

        
        /*  private readonly InmuebleVentaDbContext _Context;
        private DistritoRepository()
        {
                
        }
        public DistritoRepository(InmuebleVentaDbContext context)
        {
            
            _Context = context;
        }
       */
    }
}
