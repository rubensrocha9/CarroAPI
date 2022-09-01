using AutoMapper;
using CarroAPI.Data.Dtos.Carros;
using CarroAPI.Models;

namespace CarroAPI.Profiles
{
    public class CarroProfile : Profile
    {
        public CarroProfile()
        {
            CreateMap<CreateCarrosDto, Carro>();
            CreateMap<Carro, ReadCarrosDto>()
                    .ForMember(c => c.Adicionais, op => op
                    .MapFrom(c => c.Adicionais.Select
                    (c => new { c.Id, c.OpcionaisCarros, c.CarroId })));
            CreateMap<UpdateCarrosDto, Carro>();
        }
    }
}
