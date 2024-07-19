using JobPortal.Data;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface ITrainLineServices
    {
        public Task<GetTrainLineDto> GetTrainLineByIdAsync(long id);

        public Task<IEnumerable<GetTrainLineDto>> GetAllTrainLinesAsync();
        public Task<GetTrainLineDto> CreateTrainLineAsync(CreateTrainLineDto trainLineDto);
        public Task<GetTrainLineDto> UpdateTrainLineAsync(long id, UpdateTrainLineDto trainLineDto);
        public Task<bool> DeleteTrainLineAsync(long id);
    }
}
