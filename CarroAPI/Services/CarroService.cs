using AutoMapper;
using CarroAPI.Data;
using CarroAPI.Data.Dtos.Carros;
using CarroAPI.Models;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace CarroAPI.Services
{
    public class CarroService
    {
        private CarroAPIContext _context;
        private IMapper _mapper;

        public CarroService(CarroAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCarrosDto AdicionaCarro(CreateCarrosDto carroDto)
        {
            Carro carro = _mapper.Map<Carro>(carroDto);
            _context.Carro.Add(carro);
            _context.SaveChanges();

            return _mapper.Map<ReadCarrosDto>(carro);
        }

        public List<ReadCarrosDto> RecuperaCarro(string? marcaDoVeiculo)
        {
            List<Carro> carros;

            if (marcaDoVeiculo == null)
            {
                carros = _context.Carro
                    .Include(c => c.Adicionais).ToList();
            }
            else
            {
                carros = _context.Carro.Include(c => c.Adicionais).Where
                     (carros => carros.MarcaDoAutomovel == marcaDoVeiculo).ToList();
            }

            if (carros != null)
            {
                List<ReadCarrosDto> readCarros = _mapper.Map<List<ReadCarrosDto>>(carros);
                return readCarros;
            }

            return null;
        }

        public ReadCarrosDto RecuperaCarroPorId(int id)
        {
            Carro carro = _context.Carro.Include(c => c.Adicionais).FirstOrDefault(c => c.Id == id);
            if (carro != null)
            {
                ReadCarrosDto carrosDto = _mapper.Map<ReadCarrosDto>(carro);
                return carrosDto;
            }
            return null;
        }

        public Result Deletar(int id)
        {
            Carro carro = _context.Carro.FirstOrDefault(c => c.Id == id);

            if (carro == null)
            {
                return Result.Fail("Carro não encontrado");
            }
            _context.Remove(carro);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result AtualizarCarro(int id, UpdateCarrosDto carroDto)
        {
            Carro carro = _context.Carro.FirstOrDefault(c => c.Id == id);
            carro.Adicionais.Clear();

            if (carro == null)
            {
                return Result.Fail("Carro não encontrado");
            }
            _mapper.Map(carroDto, carro);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
