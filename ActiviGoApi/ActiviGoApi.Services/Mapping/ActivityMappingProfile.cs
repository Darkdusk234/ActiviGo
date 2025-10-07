using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs.ActivityDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Mapping
{
    internal class ActivityMappingProfile : Profile
    {
        public ActivityMappingProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<Activity, GetActivityResponse>();
            CreateMap<CreateActivityRequest, Activity>();
            CreateMap<UpdateActivityRequest, Activity>();
        }
    }
}
