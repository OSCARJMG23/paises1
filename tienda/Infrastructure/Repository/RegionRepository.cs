using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RegionRepository : GenericRepository<Region>, IRegionInterface
    {
        private readonly TiendaContext _context;
        public RegionRepository(TiendaContext context) : base(context)
        {
            _context = context;
        }
            public override async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regiones
                .Include(p=>p.Estado)
                .ToListAsync();
        }
        public override async Task<Region> GetByIdAsync(int id)
        {
            return await _context.Regiones
            .Include(p=>p.Estado)
            .FirstOrDefaultAsync(p=>p.Id ==id);
        }
    }
}