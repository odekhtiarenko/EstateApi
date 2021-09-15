using AutoMapper;
using EstateApi.Data;
using EstateApi.Dto;
using System.Linq;

namespace EstateApi.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RealEstateAgent, RealEstateAgentStats>()
                .ForMember(dest => dest.PropertiesCount, opt => opt.MapFrom(agent => agent.Properties.Count()));
        }
    }
}
