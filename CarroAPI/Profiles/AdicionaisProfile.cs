using AutoMapper;
using CarroAPI.Data.Dtos.Adicionais;
using CarroAPI.Models;

namespace CarroAPI.Profiles
{
    public class AdicionaisProfile : Profile
    {
        public AdicionaisProfile()
        {
            CreateMap<CreateAdicionaisDto, AdicionaisCarro>();
            CreateMap<AdicionaisCarro, ReadAdicionaisDto>();
        }
    }
}
