using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Producto : BaseEntity
    {
        public string ? CodInterno { get; set; }
        public string ? NombreProducto { get; set; }
        public int StockMin {get; set;}
        public int StockMax {get; set;}
        public int Stock { get; set; }
        public double ValorVta { get; set; }
        public ICollection<ProductoPersona>? ProductosPersonas {get;set;}
        public ICollection<Persona>Personas {get;set;} = new HashSet<Persona>();
    }
}