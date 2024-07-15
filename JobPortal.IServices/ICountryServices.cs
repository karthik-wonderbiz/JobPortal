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
        public Task<Country> GetCountryByIdAsync(int id);

        public Task<IEnumerable<Country>> GetAllCountriesAsync();
        public Task<Country> CreateCountryAsync(Country country);
        public Task<Country> UpdateCountryAsync(int id, Country country);
        public Task<bool> DeleteCountryAsync(int id);
    }
}
