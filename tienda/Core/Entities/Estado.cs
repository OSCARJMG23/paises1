using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Estado : BaseEntity
    {
        public string ? NombreEstado {get;set;}
        public int IdPaisFk {get; set;}
        public Pais? Pais {get; set;}
        public ICollection<Region>? Regiones {get; set;}
    }
}