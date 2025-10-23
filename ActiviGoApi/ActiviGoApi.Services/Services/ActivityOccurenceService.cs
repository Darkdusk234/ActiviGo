using ActiviGoApi.Core.Models;
using ActiviGoApi.Infrastructur.Repositories;
using ActiviGoApi.Services.DTOs;
using ActiviGoApi.Services.DTOs.ActivityDTOs;
using ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs;
using ActiviGoApi.Services.DTOs.AdminDTOs;
using ActiviGoApi.Services.DTOs.CategpryDtos;
using ActiviGoApi.Services.DTOs.WeatherDTOs;
using ActiviGoApi.Services.Interfaces;
using AutoMapper;
using RestSharp;
using RestSharp.Serializers.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Services
{
    public class ActivityOccurenceService : IActivityOccurenceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ActivityOccurenceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActivityOccurenceResponseDTO>> GetAllAsync(CancellationToken ct = default)
        {
            //var occurrences = await _unitOfWork.ActivityOccurrences.GetAllAsync(ct);
            var occurrences = await _unitOfWork.ActivityOccurrences.GetFilteredAsync(includeProperties: "Activity,SubLocation");
            return _mapper.Map<IEnumerable<ActivityOccurenceResponseDTO>>(occurrences);
        }

        public async Task<IEnumerable<ActivityOccurenceResponseDTO>> GetGeneralSearchAsync(GeneralSearchDTO dto, CancellationToken ct = default)
        {
            //var occurrences = await _unitOfWork.ActivityOccurrences.GetAllAsync(ct);
            var occurrences = await _unitOfWork.ActivityOccurrences.GetFilteredAsync(includeProperties: "Activity,SubLocation,SubLocation.Location,Activity.Category");
            var filteredOccurrences = occurrences.Where(fo =>
               fo.StartTime > DateTime.Now && fo.EndTime > DateTime.Now &&
                ((fo.Activity != null && fo.Activity.Name != null && fo.Activity.Name.Contains(dto.Query, StringComparison.OrdinalIgnoreCase))
                || (fo.SubLocation != null && fo.SubLocation.Name != null && fo.SubLocation.Name.Contains(dto.Query, StringComparison.OrdinalIgnoreCase))
                || (fo.SubLocation.Location != null && fo.SubLocation.Location.Name != null && fo.SubLocation.Location.Name.Contains(dto.Query, StringComparison.OrdinalIgnoreCase))
                || (fo.Activity.Category != null && fo.Activity.Category.Name != null && fo.Activity.Category.Name.Contains(dto.Query, StringComparison.OrdinalIgnoreCase)))
               
             );

            if (filteredOccurrences == null || !filteredOccurrences.Any())
            {
                throw new KeyNotFoundException($"No occurrences found matching query: {dto.Query}");
            }
            
            return _mapper.Map<IEnumerable<ActivityOccurenceResponseDTO>>(filteredOccurrences);
        }

        public async Task<ActivityOccurenceResponseDTO?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var occurrence = await _unitOfWork.ActivityOccurrences.GetFilteredByIdAsync(id, includeProperties: "Activity,SubLocation,SubLocation.Location,Activity.Category");

            if (occurrence == null)
            {
                throw new KeyNotFoundException($"ActivityOccurence with id {id} not found!");
            }

            var toReturn = _mapper.Map<ActivityOccurenceResponseDTO>(occurrence);

            // Fetch weather data only if the activity is outdoors
            if (occurrence.SubLocation.Indoors == false)
            {
                try
                {
                    toReturn.Weather = await AddWeatherToResponse(occurrence.StartTime, occurrence.SubLocation.Location.Latitude, occurrence.SubLocation.Location.Longitude, ct);
                }
                catch
                {
                    
                }

            }
            
            return toReturn;
        }

        public async Task<ActivityOccurenceResponseDTO> AddAsync(CreateActivityOccurrenceDTO createDTO, CancellationToken ct = default)
        {
            var activity = await _unitOfWork.Activities.GetByIdAsync(createDTO.ActivityId, ct);
            if (activity == null)
            {
                throw new KeyNotFoundException($"Activity with id {createDTO.ActivityId} not found");
            }

            var subLocation = await _unitOfWork.SubLocations.GetByIdAsync(createDTO.SubLocationId, ct);
            if (subLocation == null)
            {
                throw new KeyNotFoundException($"SubLocation with id {createDTO.SubLocationId} not found");
            }

            var newOccurrence = _mapper.Map<ActivityOccurence>(createDTO);
            newOccurrence.AvailableSpots = newOccurrence.Capacity;
            newOccurrence.IsCancelled = false;

            await _unitOfWork.ActivityOccurrences.AddAsync(newOccurrence, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return _mapper.Map<ActivityOccurenceResponseDTO>(newOccurrence);
        }

        public async Task<ActivityOccurenceResponseDTO?> UpdateAsync(int id, UpdateActivityOccurrenceDTO updateDTO, CancellationToken ct = default)
        {
            var existingOccurrence = await _unitOfWork.ActivityOccurrences.GetByIdAsync(id, ct);

            if (existingOccurrence == null)
            {
                throw new KeyNotFoundException($"ActivityOccurmence with id {id} not dound");  
            }

            var activity = await _unitOfWork.Activities.GetByIdAsync(updateDTO.ActivityId, ct);
            if (activity == null)
            {
                throw new KeyNotFoundException($"Activity with id {updateDTO.ActivityId} not found");
            }

            var subLocation = await _unitOfWork.SubLocations.GetByIdAsync(updateDTO.SubLocationId, ct);
            if (subLocation == null)
            {
                throw new KeyNotFoundException($"SubLocation with id {updateDTO.SubLocationId} not found");
            }

            _mapper.Map(updateDTO, existingOccurrence);
            existingOccurrence.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.ActivityOccurrences.UpdateAsync(existingOccurrence, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return _mapper.Map<ActivityOccurenceResponseDTO>(existingOccurrence);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            var occurrence = await _unitOfWork.ActivityOccurrences.GetByIdAsync(id, ct);

            if (occurrence == null)
            {
                throw new KeyNotFoundException($"Activity-occurrence with id {id} not found");
            }

            await _unitOfWork.ActivityOccurrences.DeleteAsync(id, ct);
            await _unitOfWork.SaveChangesAsync(ct);


        }

        public async Task CancelOccurranceAsync(int id, CancellationToken ct)
        {
            var occurrence = await _unitOfWork.ActivityOccurrences.GetByIdAsync(id, ct);
            if (occurrence == null)
            {
                throw new KeyNotFoundException($"Activity Occurrence with id {id} not found");
            }

            if (occurrence.IsCancelled)
            {
                throw new InvalidOperationException($"Activity Occurrence with id {id} is already cancelled.");
            }
            occurrence.IsCancelled = true;
            occurrence.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.ActivityOccurrences.UpdateAsync(occurrence, ct);

            var bookings = await _unitOfWork.Bookings.GetFilteredAsync("",b => b.ActivityOccurenceId == id && !b.IsCancelled && b.IsActive, ct);

            foreach(var booking in bookings)
            {
                booking.IsActive = false;
                booking.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.Bookings.UpdateAsync(booking, ct);
            }

            await _unitOfWork.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<ActivityOccurenceResponseDTO>> GetFilteredActivityOccurences(ActivityOccurenceSearchFilterDTO dto, CancellationToken ct = default)
        {
            var occurrences = await _unitOfWork.ActivityOccurrences.GetFilteredAsync(includeProperties: "Activity,Activity.Category,SubLocation,SubLocation.Location",FilterFunction(dto), ct);


            return _mapper.Map<IEnumerable<ActivityOccurenceResponseDTO>>(occurrences);
        }

        public Expression<Func<ActivityOccurence, bool>> FilterFunction(ActivityOccurenceSearchFilterDTO dto)
        {
            return x => (dto.ActivityId == null || x.ActivityId == dto.ActivityId) &&
                        (dto.CategoryId == null || x.Activity.CategoryId == dto.CategoryId) &&
                         (dto.SubLocationId == null || x.SubLocationId == dto.SubLocationId) &&
                         (dto.ActivityId == null || x.ActivityId == dto.ActivityId) &&
                         (dto.LocationId == null || x.SubLocation.LocationId == dto.LocationId) &&
                         (dto.StartTime == null || x.StartTime >= dto.StartTime) &&
                         (dto.EndTime == null || x.EndTime <= dto.EndTime) &&
                         (x.StartTime > DateTime.Now) &&
                         (x.EndTime > DateTime.Now) &&
                         (dto.AvailableToBook == null || x.AvailableSpots >= 0) &&
                         (dto.NameFilter == null || x.Activity.Name.Contains(dto.NameFilter));
        }
        public async Task<WeatherResponseDTO> AddWeatherToResponse(DateTime dateAndTime, string latitude, string longitude, CancellationToken ct)
        {
            // Setting options for fetching
            var options = new RestClientOptions("https://opendata-download-metfcst.smhi.se/api/category/snow1g/version/1/geotype/point/")
            {
                ThrowOnAnyError = true,
                Timeout = TimeSpan.FromMilliseconds(30000)

            };
            // Example $"lon/{dto.Longitude}/lat/{dto.Latitude}/data.json?timeseries={timeseries}?parameters={parameters}";

            // The added url part to get correct data
            var url = $"lon/{longitude}/lat/{latitude}/data.json?parameters=air_temperature,probability_of_precipitation,symbol_code,wind_speed";

            // Creating RestCLient
            var client = new RestClient(options,
                        configureSerialization: s => s.UseSystemTextJson(new System.Text.Json.JsonSerializerOptions()));

            // forming the request
            var request = new RestRequest(url);




                // executing the request
                var response = await client.ExecuteGetAsync(request, ct);

                if (!response.IsSuccessful)
                {
                throw new HttpRequestException("Error fetching from SMHI");
                }
                // putting weatherdata into a jsonobject 
                var responseData = JsonSerializer.Deserialize<JsonObject>(response.Content);

                // creating array of all SMHI data
                var arr = responseData?["timeSeries"].AsArray();

            // Creating a dateTime-string :

            string dt = dateAndTime.ToString("s") + "Z";

            string date = dateAndTime.ToString("yyyy-MM-dd");

            Console.WriteLine("SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS" + dt + "SSSSSSSSSSSSSSSSSSSSSSSS");
            Console.WriteLine("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF" + dt + "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");

            // loops trough all json nodes in json array
            foreach (var n in arr)
                {
                    var data = n?["data"];


                    var dtstring = n?["intervalParametersStartTime"].GetValue<string>();



                    if (n?["intervalParametersStartTime"].ToString() == dt)
                    {

                        // if there is a direct match of date and time, return it:

                        var weatherDto =
                             new WeatherResponseDTO
                             {
                                 DateAndTime = n?["intervalParametersStartTime"].ToString(),
                                 AirTemperature = data?["air_temperature"].ToString(),
                                 WindSpeed = data?["wind_speed"].ToString(),
                                 ProbabilityOfPrecipitation = data?["probability_of_precipitation"].ToString(),
                                 SymbolCode = data?["symbol_code"].ToString().Remove(1)
                             };

                    return weatherDto;
                    }

                    // If requested time is not present in weather data, return weather at 12:00 of requested date

                    if (dtstring.Contains(date + "T" + "12:00:00Z"))
                    {
                        var weatherDto =
                             new WeatherResponseDTO
                             {
                                 DateAndTime = n?["intervalParametersStartTime"].ToString(),
                                 AirTemperature = data?["air_temperature"].ToString(),
                                 WindSpeed = data?["wind_speed"].ToString(),
                                 ProbabilityOfPrecipitation = data?["probability_of_precipitation"].ToString(),
                                 SymbolCode = data?["symbol_code"].ToString().Remove(1)
                             };

                        return weatherDto;
                    }



                }

            throw new Exception("Error processing weather request for activity occurence");

        public async Task<AdminStatisticsDTO> GetAdminStatistics(CancellationToken ct = default)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(ct);
            var activities = await _unitOfWork.Activities.GetAllAsync(ct);
            var occurrences = await _unitOfWork.ActivityOccurrences.GetAllAsync(ct);
            var bookings = await _unitOfWork.Bookings.GetAllAsync(ct);
            var locations = await _unitOfWork.Locations.GetAllAsync(ct);

            var bookingsLastMonth = bookings.Where(b => b.CreatedAt >= DateTime.UtcNow.AddDays(-31));

            var popularCategory = categories
                .Select(c => new
                {
                    Category = c,
                    BookingCount = bookingsLastMonth.Count(b => b.ActivityOccurence != null && b.ActivityOccurence.Activity != null && b.ActivityOccurence.Activity.CategoryId == c.Id)
                })
                .OrderByDescending(c => c.BookingCount)
                .FirstOrDefault()?.Category;

            var popularActivity = activities
                .Select(a => new
                {
                    Activity = a,
                    BookingCount = bookingsLastMonth.Count(b => b.ActivityOccurence != null && b.ActivityOccurence.ActivityId == a.Id)
                })
                .OrderByDescending(a => a.BookingCount)
                .FirstOrDefault()?.Activity;

            var popularLocation = locations
                .Select(l => new
                {
                    Location = l,
                    BookingCount = bookingsLastMonth.Count(b => b.ActivityOccurence != null && b.ActivityOccurence.SubLocation != null && b.ActivityOccurence.SubLocation.LocationId == l.Id)
                })
                .OrderByDescending(l => l.BookingCount)
                .FirstOrDefault()?.Location;

            var statistics = new AdminStatisticsDTO
            {
                CategoriesCount = categories.Count(),
                LocationsCount = locations.Count(),
                ActivitiesCount = activities.Count(),
                ActivityOccurrencesCount = occurrences.Count(),
                BookingsLastMonth = bookingsLastMonth.Count(),
                MostBookedCategory = popularCategory != null ? _mapper.Map<CategoryReadDto>(popularCategory) : null,
                MostBookedActivity = popularActivity != null ? _mapper.Map<GetActivityResponse>(popularActivity) : null,
                MostBookedLocation = popularLocation != null ? _mapper.Map<LocationRequestDTO>(popularLocation) : null
            };

            return statistics;
        }
    }
}
