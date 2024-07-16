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

        public async Task<TrainInfo> CreateTrainInfoAsync(TrainInfo trainInfo)
        {
            trainInfo.CreatedAt = DateTime.Now;
            trainInfo.UpdatedAt = DateTime.Now;
            trainInfo.TrainInfoCode = trainInfo.TrainInfoCode != string.Empty ? trainInfo.TrainInfoCode : trainInfo.TrainInfoName.Substring(0, 3);
            return await _trainInfoRepository.CreateAsync(trainInfo);
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

        public async Task<IEnumerable<TrainInfo>> GetAllTrainInfosAsync()
        {
            var IsTrainT = await _trainInfoRepository.GetAllAsync();
            if (IsTrainT != null)
            {
                return await _trainInfoRepository.GetAllAsync();
            }
            return null;
        }

        public async Task<TrainInfo> GetTrainInfoByIdAsync(long id)
        {
            return await _trainInfoRepository.GetAsync(id);
        }

        public async Task<TrainInfo> UpdateTrainInfoAsync(long id, TrainInfo trainInfo)
        {
            var oldTrainInfo = await _trainInfoRepository.GetAsync(id);

            if (oldTrainInfo == null)
            {
                throw new Exception($"Object not found for id : {id}");
            }
            oldTrainInfo.TrainInfoName = trainInfo.TrainInfoName;
            oldTrainInfo.TrainInfoCode = trainInfo.TrainInfoCode != string.Empty ? trainInfo.TrainInfoCode : trainInfo.TrainInfoName.Substring(0, 3);
            oldTrainInfo.UpdatedAt = DateTime.Now;
            oldTrainInfo.IsActive = trainInfo.IsActive;

            var res = await _trainInfoRepository.UpdateAsync(oldTrainInfo);
            return res;
        }
    }
}
