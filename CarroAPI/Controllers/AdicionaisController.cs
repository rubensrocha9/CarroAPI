using AutoMapper;
using CarroAPI.Data;
using CarroAPI.Data.Dtos.Adicionais;
using CarroAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdicionaisController : ControllerBase
    {
        private CarroAPIContext _context;
        private IMapper _mapper;

        public AdicionaisController(CarroAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarAdicionais([FromBody] CreateAdicionaisDto adicionaisDto)
        {
            AdicionaisCarro adicionais = _mapper.Map<AdicionaisCarro>(adicionaisDto);

            _context.Opcionais.Add(adicionais);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarPorId), new { Id = adicionais.Id }, adicionais);
        }

        [HttpGet]
        public IQueryable<AdicionaisCarro> RecuperarCarro()
        {
            return _context.Opcionais;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarPorId(int id)
        {
            AdicionaisCarro? adicionais = _context.Opcionais.FirstOrDefault(c => c.Id == id);
            if (adicionais != null)
            {
                ReadAdicionaisDto adicionaisDto = _mapper.Map<ReadAdicionaisDto>(adicionais);
                return Ok(adicionaisDto);
            }
            return NotFound();
        }
    }
}
