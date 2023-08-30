using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TiendaContext context;

        private PaisRepository? _paises;
        private EstadoRepository? _estados;
        private RegionRepository? _regiones;

        public UnitOfWork(TiendaContext _context)
        {
            context = _context;
        }
        public IPaisInterface Paises
        {
            get{
                if(_paises == null){
                    _paises = new PaisRepository(context);
                }
                return _paises;
            }
        }
        public IEstadoInterface Estados
        {
            get{
                if(_estados == null){
                    _estados = new EstadoRepository(context);
                }
                return _estados;
            }
        }
        public IRegionInterface Regiones
        {
            get{
                if(_regiones == null){
                    _regiones = new RegionRepository(context);
                }
                return _regiones;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
        
    }
}