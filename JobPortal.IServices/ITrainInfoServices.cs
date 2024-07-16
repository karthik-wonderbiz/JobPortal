using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface ITrainInfoServices
    {
        public Task<TrainInfo> GetTrainInfoByIdAsync(long id);

        public Task<IEnumerable<TrainInfo>> GetAllTrainInfosAsync();
        public Task<TrainInfo> CreateTrainInfoAsync(TrainInfo trainInfo);
        public Task<TrainInfo> UpdateTrainInfoAsync(long id, TrainInfo trainInfo);
        public Task<bool> DeleteTrainInfoAsync(long id);
    }
}
