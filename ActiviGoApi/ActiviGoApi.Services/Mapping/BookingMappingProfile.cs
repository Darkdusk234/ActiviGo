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
            //Automatically set time of booking when mapping.
            CreateMap<BookingCreateDTO, Booking>()
                .ForMember(dest => dest.BookingTime, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<BookingUpdateDTO, Booking>();

        }
    }
}
