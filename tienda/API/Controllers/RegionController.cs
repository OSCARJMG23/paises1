using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RegionController : BaseApiController
{
    public readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;

    public RegionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<RegionDto>>> Get()
        {
            var regiones = await _unitOfWork.Regiones.GetAllAsync();
            return _mapper.Map<List<RegionDto>>(regiones);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<RegionDto>> Get(int id)
        {
            var region = await _unitOfWork.Regiones.GetByIdAsync(id);
            if(region == null)
            {
                return NotFound();
            }
            return _mapper.Map<RegionDto>(region);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<Region>> Post(RegionDto RegionDto){
            var region = _mapper.Map<Region>(RegionDto);

            _unitOfWork.Regiones.Add(region);
            await _unitOfWork.SaveAsync();

            if(region == null)
            {
                return BadRequest();
            }
            RegionDto.Id = region.Id;
            return CreatedAtAction(nameof(Post),new {id =RegionDto.Id},RegionDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<RegionDto>> Put(int id, [FromBody]RegionDto regionDto){

            if(regionDto == null)
            {
                return NotFound();
            }
            var region = _mapper.Map<Region>(regionDto);
            _unitOfWork.Regiones.Update(region);
            await _unitOfWork.SaveAsync();
            return regionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<RegionDto>> Delete(int id)
        {
            var regiones = await _unitOfWork.Regiones.GetByIdAsync(id);
            if (regiones == null)
            {
                return NotFound();
            }
            _unitOfWork.Regiones.Remove(regiones);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

}
