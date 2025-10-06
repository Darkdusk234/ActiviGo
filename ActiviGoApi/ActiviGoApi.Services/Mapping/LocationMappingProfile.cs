using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs;
using AutoMapper;

namespace ActiviGoApi.Services.Mapping
{
    public class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<LocationRequestDTO, Location>();

        }
    }
}
