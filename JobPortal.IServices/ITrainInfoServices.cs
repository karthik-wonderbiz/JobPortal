using JobPortal.Data;
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
        public Task<GetTrainInfoDto> GetTrainInfoByIdAsync(long id);

        public Task<IEnumerable<GetTrainInfoDto>> GetAllTrainInfosAsync();
        public Task<GetTrainInfoDto> CreateTrainInfoAsync(CreateTrainInfoDto traininfoDto);
        public Task<GetTrainInfoDto> UpdateTrainInfoAsync(long id, UpdateTrainInfoDto traininfoDto);
        public Task<bool> DeleteTrainInfoAsync(long id);
    }
}
