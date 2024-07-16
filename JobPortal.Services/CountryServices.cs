using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly ICountryRepository _countryRepository;

        public CountryServices(ICountryRepository countryRepository) 
        { 
            _countryRepository = countryRepository;
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            country.CreatedAt = DateTime.Now;
            country.UpdatedAt = DateTime.Now;
            country.CountryCode = country.CountryName.Substring(0,3);
            return await _countryRepository.CreateAsync(country);
        }

        public async Task<bool> DeleteCountryAsync(long id)
        {
            var country = await _countryRepository.GetAsync(id);

            if (country != null) 
            {
                return await _countryRepository.DeleteAsync(country);
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            var isCountry = await _countryRepository.GetAllAsync();
            if(isCountry != null)
            {
                return await _countryRepository.GetAllAsync();
            }
            return null;
        }

        public Task<Country> GetCountryByIdAsync(long id)
        {
            return _countryRepository.GetAsync(id);
        }

        public async Task<Country> UpdateCountryAsync(long id, Country country)
        {
            var oldCountry = await _countryRepository.GetAsync(id);

            if(oldCountry == null)
            {
                throw new Exception($"Object not found for id : {id}");
            }

            oldCountry.CountryName = country.CountryName;
            oldCountry.CountryCode = country.CountryCode;
            oldCountry.UpdatedAt = DateTime.Now;
            oldCountry.IsActive = country.IsActive;

            var res = await _countryRepository.UpdateAsync(oldCountry);
            return res;
        }
    }
}
