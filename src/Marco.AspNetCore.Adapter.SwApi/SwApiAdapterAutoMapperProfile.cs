using AutoMapper;
using Marco.AspNetCore.Adapter.SwApi.Clients;
using Marco.AspNetCore.Domain.Models;

namespace Marco.AspNetCore.Adapter.SwApi
{
    public class SwApiAdapterAutoMapperProfile : Profile
    {
        public SwApiAdapterAutoMapperProfile()
        {
            CreateMap<PeopleGetResult, People>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.name))
                .ForMember(d => d.Height, opt => opt.MapFrom(s => s.height))
                .ForMember(d => d.Mass, opt => opt.MapFrom(s => s.mass))
                .ForMember(d => d.HairColor, opt => opt.MapFrom(s => s.hair_color));
        }
    }
}