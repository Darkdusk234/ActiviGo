using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs;
using ActiviGoApi.Services.DTOs.WeatherDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Interfaces
{
    public interface IActivityOccurenceService
    {
        Task<IEnumerable<ActivityOccurenceResponseDTO>> GetAllAsync(CancellationToken ct = default);
        Task<ActivityOccurenceResponseDTO?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<ActivityOccurenceResponseDTO> AddAsync(CreateActivityOccurrenceDTO createDto, CancellationToken ct = default);
        Task<ActivityOccurenceResponseDTO?> UpdateAsync(int id, UpdateActivityOccurrenceDTO updateDto, CancellationToken ct = default);
        Task DeleteAsync(int id, CancellationToken ct = default);
        Task CancelOccurranceAsync(int id, CancellationToken ct);
        Task<IEnumerable<ActivityOccurenceResponseDTO>> GetFilteredActivityOccurences(ActivityOccurenceSearchFilterDTO dto, CancellationToken ct = default);
        Task<IEnumerable<ActivityOccurenceResponseDTO>> GetGeneralSearchAsync(GeneralSearchDTO query, CancellationToken ct = default);

        Task<WeatherResponseDTO> AddWeatherToResponse(DateTime dateAndTime, string latitude, string longitude, CancellationToken ct);


    }
}
