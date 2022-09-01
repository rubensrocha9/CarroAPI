using AutoMapper;
using CarroAPI.Data.Dtos.Carros;
using CarroAPI.Models;
using CarroAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroController : ControllerBase
    {
        private CarroService _carroService;

        public CarroController(CarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpPost]
        public IActionResult AdicionarCarro([FromBody] CreateCarrosDto carroDto)
        {
            ReadCarrosDto readDto = _carroService.AdicionaCarro(carroDto);
            
            return CreatedAtAction(nameof(RecuperarPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperarCarro([FromQuery] string? marcaDoVeiculo = null)
        {
            List<ReadCarrosDto> readDto = _carroService.RecuperaCarro(marcaDoVeiculo);
            if (readDto != null)
            {
                return Ok(readDto);
            }
            
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarPorId(int id)
        {
            ReadCarrosDto readDto = _carroService.RecuperaCarroPorId(id);
                       
            if (readDto != null)
            {
                return Ok(readDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCarro(int id, [FromBody] UpdateCarrosDto carroDto)
        {
            Result result = _carroService.AtualizarCarro(id, carroDto);
            if (result.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverCarroPotId(int id)
        {
            Result result = _carroService.Deletar(id);

            if (result.IsFailed)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
