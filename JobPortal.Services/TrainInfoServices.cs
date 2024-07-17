using JobPortal.Data;
using JobPortal.DTO;
using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class TrainInfoServices : ITrainInfoServices
    {
        private readonly ITrainInfoRepository _trainInfoRepository;

        public TrainInfoServices(ITrainInfoRepository trainInfoRepository)
        {
            _trainInfoRepository = trainInfoRepository;
        }

        public async Task<GetTrainInfoDto> CreateTrainInfoAsync(CreateTrainInfoDto trainInfoDto)
        {
            try
            {
                var trainInfo = await _trainInfoRepository.CreateAsync(new TrainInfo()
                {
                    TrainInfoName = trainInfoDto.TrainInfoName,
                    TrainInfoCode = trainInfoDto.TrainInfoName.ToUpper().Substring(0, 3),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var createdTrainInfo = new GetTrainInfoDto(trainInfo.Id, trainInfo.TrainInfoName, trainInfo.TrainInfoCode, trainInfo.IsActive);
                return createdTrainInfo;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This input already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteTrainInfoAsync(long id)
        {
            try
            {
                var trainInfo = await _trainInfoRepository.GetAsync(id);
                if (trainInfo == null)
                {
                    throw new Exception($"Train Info not found for id : {id}");
                }

                var deleted = await _trainInfoRepository.DeleteAsync(trainInfo);
                return deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetTrainInfoDto>> GetAllTrainInfosAsync()
        {
            try
            {
                var trainInfos = await _trainInfoRepository.GetAllAsync();

                var trainInfoDto = trainInfos.Select(trainInfo => new GetTrainInfoDto(
                    trainInfo.Id,
                    trainInfo.TrainInfoName,
                    trainInfo.TrainInfoCode,
                    trainInfo.IsActive
                ));

                return trainInfoDto.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetTrainInfoDto> GetTrainInfoByIdAsync(long id)
        {
            try
            {
                var trainInfo = await _trainInfoRepository.GetAsync(id);
                if (trainInfo == null)
                {
                    throw new Exception($"Train Info not found for id : {id}");
                }

                var trainInfoData = new GetTrainInfoDto(trainInfo.Id, trainInfo.TrainInfoName, trainInfo.TrainInfoCode, trainInfo.IsActive);
                return trainInfoData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetTrainInfoDto> UpdateTrainInfoAsync(long id, UpdateTrainInfoDto trainInfoDto)
        {
            try
            {
                var oldTrainInfo = await _trainInfoRepository.GetAsync(id);
                if (oldTrainInfo == null)
                {
                    throw new Exception($"Train Info not found for id : {id}");
                }

                oldTrainInfo.TrainInfoName = trainInfoDto.TrainInfoName;
                oldTrainInfo.TrainInfoCode = trainInfoDto.TrainInfoName.ToUpper().Substring(0, 3);
                oldTrainInfo.IsActive = trainInfoDto.IsActive;
                oldTrainInfo.UpdatedAt = DateTime.Now;

                await _trainInfoRepository.UpdateAsync(oldTrainInfo);

                var updatedTrainInfo = new GetTrainInfoDto(oldTrainInfo.Id, oldTrainInfo.TrainInfoName, oldTrainInfo.TrainInfoCode, oldTrainInfo.IsActive);
                return updatedTrainInfo;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This input already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
