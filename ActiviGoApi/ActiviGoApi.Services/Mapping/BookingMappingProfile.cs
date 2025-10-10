using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs.BookingDTOs;
using AutoMapper;

namespace ActiviGoApi.Services.Mapping
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<Booking, BookingReadDTO>();
            
            CreateMap<BookingCreateDTO, Booking>();

            //Automatically set time of booking when mapping.
            CreateMap<BookingUpdateDTO, Booking>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

        }
    }
}
