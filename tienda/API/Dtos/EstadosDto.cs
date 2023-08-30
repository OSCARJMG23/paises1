using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EstadosDto
    {
        public int Id {get; set;}
        public string ? NombreEstado {get;set;}
        public List<RegionDto>? Regiones {get; set;}
    }
}