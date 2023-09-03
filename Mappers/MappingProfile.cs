using AutoMapper;
using Mappers.AuthoDtos;

namespace Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SourceAuthoModel, DestinationAuthoDTO>();
        }
    }
}
