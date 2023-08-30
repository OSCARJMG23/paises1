using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductoPersona : BaseEntity
    {
        public int IdProductoFk {get; set;}
        public Producto? Producto {get; set;}
        public int IdPersonaFk { get; set; }
        public Persona? Persona {get; set;}
    }
}