using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    public class PaisController : BaseApiController
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<PaisesDto>>> Get()
        {
            var paises = await _unitOfWork.Paises.GetAllAsync();
            return _mapper.Map<List<PaisesDto>>(paises);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PaisDto>> Get(int id)
        {
            var pais = await _unitOfWork.Paises.GetByIdAsync(id);
            if(pais == null)
            {
                return NotFound();
            }
            return _mapper.Map<PaisDto>(pais);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<Pais>> Post(PaisesDto PaisDto){
            var pais = _mapper.Map<Pais>(PaisDto);

            _unitOfWork.Paises.Add(pais);
            await _unitOfWork.SaveAsync();

            if(pais == null)
            {
                return BadRequest();
            }
            PaisDto.Id = pais.Id;
            return CreatedAtAction(nameof(Post),new {id =PaisDto.Id},PaisDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public async Task<ActionResult<PaisesDto>> Put(int id, [FromBody]PaisesDto paisdto){

            if(paisdto == null)
            {
                return NotFound();
            }
            var pais = _mapper.Map<Pais>(paisdto);
            _unitOfWork.Paises.Update(pais);
            await _unitOfWork.SaveAsync();
            return paisdto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<PaisDto>> Delete(int id)
        {
            var paises = await _unitOfWork.Paises.GetByIdAsync(id);
            if (paises == null)
            {
                return NotFound();
            }
            _unitOfWork.Paises.Remove(paises);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
