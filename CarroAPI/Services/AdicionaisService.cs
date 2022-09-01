using AutoMapper;
using CarroAPI.Data;
using CarroAPI.Data.Dtos.Adicionais;
using CarroAPI.Data.Dtos.Carros;
using CarroAPI.Models;

namespace CarroAPI.Services
{
    public class AdicionaisService
    {
        private CarroAPIContext _context;
        private IMapper _mapper;

        public AdicionaisService(CarroAPIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadAdicionaisDto AdicionarOpcionais(CreateAdicionaisDto adicionaisDto)
        {
            AdicionaisCarro adicionais = _mapper.Map<AdicionaisCarro>(adicionaisDto);
            _context.Opcionais.Add(adicionais);
            _context.SaveChanges();

            return _mapper.Map<ReadAdicionaisDto>(adicionais);
        }

        public ReadAdicionaisDto RecuperaOpcionaisPorId(int id)
        {
            AdicionaisCarro adicionais = _context.Opcionais.FirstOrDefault(c => c.Id == id);
            if (adicionais != null)
            {
                ReadAdicionaisDto adicionaisDto = _mapper.Map<ReadAdicionaisDto>(adicionais);
                return adicionaisDto;
            }
            return null;
        }
    }
}
