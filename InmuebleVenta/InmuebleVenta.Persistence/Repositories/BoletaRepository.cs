﻿using InmuebleVenta.Entities;
using InmuebleVenta.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmuebleVenta.Persistence.Repositories
{
    public class BoletaRepository : Repository<Boleta>, IBoletaRepository
    {
        public BoletaRepository(InmuebleVentaDbContext context):base(context)
		{
		}




      //  private readonly InmuebleVentaDbContext _Context;

    /*    
        public BoletaRepository(InmuebleVentaDbContext context)
        {
            _Context = context;
        }
        private BoletaRepository()
        {
                
        }

        */
    }
}