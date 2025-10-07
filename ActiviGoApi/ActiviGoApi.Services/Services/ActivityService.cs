using ActiviGoApi.Core.Models;
using ActiviGoApi.Infrastructur.Repositories;
using ActiviGoApi.Services.DTOs.ActivityDTOs;
using ActiviGoApi.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Services.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public ActivityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateActivityAsync(CreateActivityRequest dto, CancellationToken ct = default)
        {
            Activity toCreate = _mapper.Map<Activity>(dto);

            await _unitOfWork.Activities.AddAsync(toCreate, ct);

            return await _unitOfWork.SaveChangesAsync(ct);
        }

        public async Task<bool> DeleteActivityAsync(int id, CancellationToken ct = default)
        {
            var toDelete = await _unitOfWork.Activities.DeleteAsync(id, ct);
            if (!toDelete)
            {
                throw new KeyNotFoundException($"Activity with id {id} not found");
            }

            return await _unitOfWork.SaveChangesAsync(ct);
        }

        public async Task<GetActivityResponse> GetActivityByIdAsync(int id, CancellationToken ct = default)
        {
            return _mapper.Map<GetActivityResponse>( await _unitOfWork.Activities.GetByIdAsync(id, ct));
        }

        public async Task<IEnumerable<GetActivityResponse>> GetAllActivitiesAsync(CancellationToken ct = default)
        {
            var activities = await _unitOfWork.Activities.GetAllAsync(ct);
            
            if(activities == null || !activities.Any())
            {
                throw new KeyNotFoundException("No activities found");
            }
            // Creating List and Foreaching trough activities manually because AutoMapper does not support mapping collections directly
            var dtos = new List<GetActivityResponse>();
            foreach (var activity in activities)
            {
                dtos.Add(_mapper.Map<GetActivityResponse>(activity));
            }

            return dtos;
        }

        public async Task<bool> UpdateActivityAsync(int id, UpdateActivityRequest dto, CancellationToken ct = default)
        {
            var toUpdate = _unitOfWork.Activities.GetByIdAsync(id, ct);

            if (toUpdate == null)
            {
                throw new KeyNotFoundException($"Activity with id {id} not found");
            }
            else
            {
                var updated = _mapper.Map<Activity>(dto);
                updated.Id = id; // Ensure the ID remains the same
                await _unitOfWork.Activities.UpdateAsync(updated, ct);
                await _unitOfWork.SaveChangesAsync(ct);
            }
            return true;
        }
    }
}
