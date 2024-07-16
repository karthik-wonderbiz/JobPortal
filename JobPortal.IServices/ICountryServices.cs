using JobPortal.Data;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface ICountryServices
    {
        public Task<GetCountryDto> GetCountryByIdAsync(long id);

        public Task<IEnumerable<GetCountryDto>> GetAllCountriesAsync();
        public Task<GetCountryDto> CreateCountryAsync(CreateCountryDto countryDto);
        public Task<GetCountryDto> UpdateCountryAsync(long id, UpdateCountryDto countryDto);
        public Task<bool> DeleteCountryAsync(long id);
    }
}
