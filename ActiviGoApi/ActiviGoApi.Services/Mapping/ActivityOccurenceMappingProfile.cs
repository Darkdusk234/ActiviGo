using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Mapping
{
    public class ActivityOccurenceMappingProfile : Profile
    {
        public ActivityOccurenceMappingProfile()
        {
            CreateMap<ActivityOccurence, ActivityOccurenceResponseDTO>();

            CreateMap<CreateActivityOccurrenceDTO, ActivityOccurence>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.AvailableSpots, opt => opt.MapFrom(src => src.Capacity))
                    .ForMember(dest => dest.IsCancelled, opt => opt.MapFrom(src => false))
                    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                    .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateActivityOccurrenceDTO, ActivityOccurence>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

        }

    }
}
