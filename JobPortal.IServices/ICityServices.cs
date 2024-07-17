using JobPortal.Data;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface ICityServices
    {
        public Task<GetCityDto> GetCityByIdAsync(long id);

        public Task<IEnumerable<GetCityDto>> GetAllCitiesAsync();
        public Task<GetCityDto> CreateCityAsync(CreateCityDto cityDto);
        public Task<GetCityDto> UpdateCityAsync(long id, UpdateCityDto cityDto);
        public Task<bool> DeleteCityAsync(long id);
    }
}
