using AutoMapper;
using CarroAPI.Data;
using CarroAPI.Data.Dtos.Carros;
using CarroAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarroAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarroController : ControllerBase
    {
        private CarroAPIContext _context;
        private IMapper _mapper;

        public CarroController(CarroAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarCarro([FromBody] CreateCarrosDto carroDto)
        {
            Carro carro = _mapper.Map<Carro>(carroDto);

            _context.Carro.Add(carro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarPorId), new { Id = carro.Id }, carro);
        }

        [HttpGet]
        public IActionResult RecuperarCarro([FromQuery] string marcaDoVeiculo = null)
        {
            List<Carro> carros;

            if (marcaDoVeiculo == null)
            {
                carros = _context.Carro
                    .Include(c => c.Adicionais).ToList();
            }
            else
            {
               carros  = _context.Carro.Include(c => c.Adicionais).Where
                    (carros => carros.MarcaDoAutomovel == marcaDoVeiculo).ToList();
            }

            if (carros != null)
            {
                List<ReadCarrosDto> readCarros = _mapper.Map<List<ReadCarrosDto>>(carros);
                return Ok(readCarros);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarPorId(int id)
        {
            Carro carro = _context.Carro.Include(c => c.Adicionais).FirstOrDefault(c => c.Id == id);
            if (carro != null)
            {
                ReadCarrosDto carrosDto = _mapper.Map<ReadCarrosDto>(carro);
                return Ok(carrosDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCarro(int id, [FromBody] UpdateCarrosDto carroDto)
        {
            Carro carro = _context.Carro.FirstOrDefault(c => c.Id == id);
            carro.Adicionais.Clear();

            if (carro == null)
            {
                return NotFound();
            }
            _mapper.Map(carroDto, carro);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverCarroPotId(int id)
        {
            Carro? carro = _context.Carro.FirstOrDefault(c => c.Id == id);

            if (carro == null)
            {
                return NotFound();
            }
            _context.Remove(carro);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
