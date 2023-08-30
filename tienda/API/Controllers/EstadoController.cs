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

public class EstadoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;
    public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<EstadoDto>>> Get()
        {
            var estados = await _unitOfWork.Estados.GetAllAsync();
            return _mapper.Map<List<EstadoDto>>(estados);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<EstadosDto>> Get(int id)
        {
            var estado = await _unitOfWork.Estados.GetByIdAsync(id);
            if(estado == null)
            {
                return NotFound();
            }
            return _mapper.Map<EstadosDto>(estado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<Estado>> Post(EstadoDto EstadoDto){
            var estado = _mapper.Map<Estado>(EstadoDto);

            _unitOfWork.Estados.Add(estado);
            await _unitOfWork.SaveAsync();

            if(estado == null)
            {
                return BadRequest();
            }
            EstadoDto.Id = estado.Id;
            return CreatedAtAction(nameof(Post),new {id =EstadoDto.Id},EstadoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody]EstadoDto estadoDto){

            if(estadoDto == null)
            {
                return NotFound();
            }
            var estado = _mapper.Map<Estado>(estadoDto);
            _unitOfWork.Estados.Update(estado);
            await _unitOfWork.SaveAsync();
            return estadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<EstadoDto>> Delete(int id)
        {
            var estados = await _unitOfWork.Estados.GetByIdAsync(id);
            if (estados == null)
            {
                return NotFound();
            }
            _unitOfWork.Estados.Remove(estados);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

}
