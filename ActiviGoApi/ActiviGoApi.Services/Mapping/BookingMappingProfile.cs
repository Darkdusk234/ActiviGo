using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs.BookingDTOs;
using AutoMapper;

namespace ActiviGoApi.Services.Mapping
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<Booking, BookingReadDTO>()
                .ForMember(dest => dest.ActivityName, opt => opt.MapFrom(src =>
                    src.ActivityOccurence != null && src.ActivityOccurence.Activity != null 
                        ? src.ActivityOccurence.Activity.Name: null));

            CreateMap<BookingCreateDTO, Booking>()
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            //Automatically set time of booking when mapping.
            CreateMap<BookingUpdateDTO, Booking>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        }
    }
}
