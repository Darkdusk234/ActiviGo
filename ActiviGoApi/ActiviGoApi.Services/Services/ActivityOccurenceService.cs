using ActiviGoApi.Core.Models;
using ActiviGoApi.Infrastructur.Repositories;
using ActiviGoApi.Services.DTOs.ActivityDTOs;
using ActiviGoApi.Services.DTOs.ActivityOccurenceDTOs;
using ActiviGoApi.Services.DTOs.CategpryDtos;
using ActiviGoApi.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var occurrences = await _unitOfWork.ActivityOccurrences.GetAllAsync(ct);
            return _mapper.Map<IEnumerable<ActivityOccurenceResponseDTO>>(occurrences);
        }

        public async Task<ActivityOccurenceResponseDTO?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            var occurrence = await _unitOfWork.ActivityOccurrences.GetByIdAsync(id, ct);

            if (occurrence == null)
            {
                return null;
            }

            return _mapper.Map<ActivityOccurenceResponseDTO>(occurrence);
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
                return null;
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
    }
}
