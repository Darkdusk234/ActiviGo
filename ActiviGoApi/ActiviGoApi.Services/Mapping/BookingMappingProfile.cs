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

            CreateMap<BookingCreateDTO, Booking>()
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            //Automatically set time of booking when mapping.
            CreateMap<BookingUpdateDTO, Booking>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        }
    }
}
