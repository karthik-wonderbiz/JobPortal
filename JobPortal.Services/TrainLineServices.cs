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
    public class TrainLineServices : ITrainLineServices
    {
        private readonly ITrainLineRepository _trainLineRepository;

        public TrainLineServices(ITrainLineRepository trainLineRepository)
        {
            _trainLineRepository = trainLineRepository;
        }

        public async Task<GetTrainLineDto> CreateTrainLineAsync(CreateTrainLineDto trainLineDto)
        {
            try
            {
                var trainLine = await _trainLineRepository.CreateAsync(new TrainLine()
                {
                    TrainLineName = trainLineDto.TrainLineName,
                    TrainLineCode = trainLineDto.TrainLineName.ToUpper().Substring(0, 3),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var createdTrainLine = new GetTrainLineDto(trainLine.Id, trainLine.TrainLineName, trainLine.TrainLineCode, trainLine.IsActive);
                return createdTrainLine;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This Train Line already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteTrainLineAsync(long id)
        {
            try
            {
                var trainLine = await _trainLineRepository.GetAsync(id);
                if (trainLine == null)
                {
                    throw new Exception($"Train Line not found for id : {id}");
                }

                var deleted = await _trainLineRepository.DeleteAsync(trainLine);
                return deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetTrainLineDto>> GetAllTrainLinesAsync()
        {
            try
            {
                var trainLines = await _trainLineRepository.GetAllAsync();

                var trainLineDto = trainLines.Select(trainLine => new GetTrainLineDto(
                    trainLine.Id,
                    trainLine.TrainLineName,
                    trainLine.TrainLineCode,
                    trainLine.IsActive
                ));

                return trainLineDto.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetTrainLineDto> GetTrainLineByIdAsync(long id)
        {
            try
            {
                var trainLine = await _trainLineRepository.GetAsync(id);
                if (trainLine == null)
                {
                    throw new Exception($"Train Line not found for id : {id}");
                }

                var trainLineData = new GetTrainLineDto(trainLine.Id, trainLine.TrainLineName, trainLine.TrainLineCode, trainLine.IsActive);
                return trainLineData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetTrainLineDto> UpdateTrainLineAsync(long id, UpdateTrainLineDto trainLineDto)
        {
            try
            {
                var oldTrainLine = await _trainLineRepository.GetAsync(id);
                if (oldTrainLine == null)
                {
                    throw new Exception($"Train Line not found for id : {id}");
                }

                oldTrainLine.TrainLineName = trainLineDto.TrainLineName;
                oldTrainLine.TrainLineCode = trainLineDto.TrainLineName.ToUpper().Substring(0, 3);
                oldTrainLine.IsActive = trainLineDto.IsActive;
                oldTrainLine.UpdatedAt = DateTime.Now;

                await _trainLineRepository.UpdateAsync(oldTrainLine);

                var updatedTrainLine = new GetTrainLineDto(oldTrainLine.Id, oldTrainLine.TrainLineName, oldTrainLine.TrainLineCode, oldTrainLine.IsActive);
                return updatedTrainLine;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This Train Line already exists.");
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
