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
    public class EstadoRepository : GenericRepository<Estado>, IEstadoInterface
    {
        private readonly TiendaContext _context;
        public EstadoRepository(TiendaContext context) :base (context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Estado>> GetAllAsync()
        {
            return await _context.Estados
                .Include(p=> p.Regiones)
                .ToListAsync();
        }
        public override async Task<Estado> GetByIdAsync(int id)
        {
            return await _context.Estados
                .Include(p=> p.Regiones)
                .FirstOrDefaultAsync(p => p.Id==id);
        }
    }
}