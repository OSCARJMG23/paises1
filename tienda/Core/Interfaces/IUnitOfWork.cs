using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IPaisInterface Paises {get; }
        IEstadoInterface Estados {get; }
        IRegionInterface Regiones {get; }

        Task<int> SaveAsync();
    }
}