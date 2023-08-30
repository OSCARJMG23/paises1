using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(){
            CreateMap<Pais,PaisesDto>().ReverseMap();
            CreateMap<Pais,PaisDto>().ReverseMap();
            CreateMap<Estado,EstadoDto>().ReverseMap();
            CreateMap<Estado,EstadosDto>().ReverseMap();
            CreateMap<Region,RegionDto>().ReverseMap();



    
        }
    }
}