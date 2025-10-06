using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs;
using AutoMapper;

namespace ActiviGoApi.Services.Mapping
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<Booking, BookingReadDTO>();
            CreateMap<BookingCreateDTO, Booking>();
            CreateMap<BookingUpdateDTO, Booking>();

        }
    }
}
