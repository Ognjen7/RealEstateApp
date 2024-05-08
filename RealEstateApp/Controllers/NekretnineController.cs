using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Interfaces;
using RealEstateApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NekretnineController : ControllerBase
    {
        private readonly INekretninaRepository _nekretninaRepository;
        private readonly IMapper _mapper;

        public NekretnineController(INekretninaRepository nekretninaRepository, IMapper mapper)
        {
            _nekretninaRepository = nekretninaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetNekretnine()
        {
            return Ok(_nekretninaRepository.GetAll().ProjectTo<NekretninaDTO>(_mapper.ConfigurationProvider).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetNekretnina(int id)
        {
            var nekretnina = _nekretninaRepository.GetById(id);

            if (nekretnina == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<NekretninaDTO>(nekretnina));
        }

        [HttpPost]
        public IActionResult PostNekretnina(Nekretnina nekretnina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _nekretninaRepository.Add(nekretnina);
            return CreatedAtAction("GetNekretnina", new { id = nekretnina.Id }, _mapper.Map<NekretninaDTO>(nekretnina));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNekretnina(int id)
        {
            var nekretnina = _nekretninaRepository.GetById(id);
            if (nekretnina == null)
            {
                return NotFound();
            }

            _nekretninaRepository.Delete(nekretnina);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutNekretnina(int id, Nekretnina nekretnina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nekretnina.Id)
            {
                return BadRequest();
            }

            try
            {
                _nekretninaRepository.Update(nekretnina);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(nekretnina);
        }

        [HttpGet("napravljeno")]
        public IActionResult GetByType([FromQuery] int napravljeno)
        {
            var nekretnine = _nekretninaRepository.GetByYearMade(napravljeno);

            if (nekretnine == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<NekretninaDTO>>(nekretnine));
        }

        [HttpPost]
        [Route("/api/pretragaPoKvadraturi")]
        public IActionResult Search(SearchDTO dto)
        {
            if (dto.Mini < 0 || dto.Maksi < 0 || dto.Mini > dto.Maksi)
            {
                return BadRequest();
            }
            return Ok(_nekretninaRepository.GetAllByArea(dto.Mini, dto.Maksi).ProjectTo<NekretninaDTO>(_mapper.ConfigurationProvider).ToList());
        }
    }
}
