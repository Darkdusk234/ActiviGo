using ActiviGoApi.Services.DTOs.ActivityDTOs;
using ActiviGoApi.Services.DTOs.CategpryDtos;

namespace ActiviGoApi.Services.DTOs.AdminDTOs
{
    public class AdminStatisticsDTO
    {
        public int BookingsLastMonth { get; set; }
        public CategoryReadDto MostBookedCategory { get; set; } = new CategoryReadDto();
        public LocationRequestDTO MostBookedLocation { get; set; } = new LocationRequestDTO();
        public GetActivityResponse MostBookedActivity { get; set; } = new GetActivityResponse();
        public int CategoriesCount { get; set; }
        public int LocationsCount { get; set; }
        public int ActivitiesCount { get; set; }
        public int ActivityOccurrencesCount { get; set; }
    }
}
