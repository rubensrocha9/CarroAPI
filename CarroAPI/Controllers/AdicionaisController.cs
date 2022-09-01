using AutoMapper;
using CarroAPI.Data;
using CarroAPI.Data.Dtos.Adicionais;
using CarroAPI.Models;
using CarroAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdicionaisController : ControllerBase
    {
        private AdicionaisService _adicionaisService;

        public AdicionaisController(AdicionaisService adicionaisService)
        {
            _adicionaisService = adicionaisService;
        }

        [HttpPost]
        public IActionResult AdicionarAdicionais([FromBody] CreateAdicionaisDto adicionaisDto)
        {
            ReadAdicionaisDto readDto = _adicionaisService.AdicionarOpcionais(adicionaisDto);
            
            return CreatedAtAction(nameof(RecuperarPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarPorId(int id)
        {
            ReadAdicionaisDto readDto = _adicionaisService.RecuperaOpcionaisPorId(id);
            
            if (readDto != null)
            {
                return Ok(readDto);
            }
            return NotFound();
        }
    }
}
