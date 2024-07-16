using JobPortal.Data;
using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
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
            var traininfo = await _trainInfoRepository.CreateAsync(new TrainInfo() { TrainInfoName = trainInfoDto.TrainInfoName, TrainInfoCode = trainInfoDto.TrainInfoName.ToUpper().Substring(0, 3), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            return new GetTrainInfoDto(traininfo.Id, traininfo.TrainInfoName, traininfo.TrainInfoCode, traininfo.IsActive);
        }

        public async Task<bool> DeleteTrainInfoAsync(long id)
        {
            var IsTrainInfo = await _trainInfoRepository.GetAsync(id);

            if (IsTrainInfo != null)
            {
                return await _trainInfoRepository.DeleteAsync(IsTrainInfo);
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<GetTrainInfoDto>> GetAllTrainInfosAsync()
        {
            var trainInfos = await _trainInfoRepository.GetAllAsync();

            var trainInfoDto = trainInfos.Select(trainInfo => new GetTrainInfoDto(trainInfo.Id, trainInfo.TrainInfoName, trainInfo.TrainInfoCode, trainInfo.IsActive));

            return trainInfoDto;
        }

        public async Task<GetTrainInfoDto> GetTrainInfoByIdAsync(long id)
        {
            var trainInfo = await _trainInfoRepository.GetAsync(id);

            return new GetTrainInfoDto(trainInfo.Id, trainInfo.TrainInfoName, trainInfo.TrainInfoCode, trainInfo.IsActive);
        }

        public async Task<GetTrainInfoDto> UpdateTrainInfoAsync(long id, UpdateTrainInfoDto trainInfoDto)
        {
            var oldTrainInfo = await _trainInfoRepository.GetAsync(id);

            if (oldTrainInfo == null)
            {
                throw new Exception($"Object not found for id : {id}");
            }
            oldTrainInfo.TrainInfoName = trainInfoDto.TrainInfoName;
            oldTrainInfo.TrainInfoCode = trainInfoDto.TrainInfoCode;
            oldTrainInfo.IsActive = trainInfoDto.IsActive;

            await _trainInfoRepository.UpdateAsync(oldTrainInfo);
            return new GetTrainInfoDto(oldTrainInfo.Id, oldTrainInfo.TrainInfoName, oldTrainInfo.TrainInfoCode, oldTrainInfo.IsActive);
        }
    }
}
