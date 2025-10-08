using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs.SubLocationDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Mapping
{
    public class SubLocationMappingProfile : Profile
    {
        public SubLocationMappingProfile()
        {
            CreateMap<SubLocation, GetSubLocationResponse>();
            CreateMap<CreateSubLocationRequest, SubLocation>();
            CreateMap<UpdateSubLocationRequest, SubLocation>();
        }
    }
}
