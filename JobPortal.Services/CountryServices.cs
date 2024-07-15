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
            country.CreateAt = DateTime.Now;
            country.UpdateAt = DateTime.Now;
            return await _countryRepository.CreateAsync(country);
        }

        public async Task<bool> DeleteCountryAsync(int id)
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

        public Task<Country> GetCountryByIdAsync(int id)
        {
            return _countryRepository.GetAsync(id);
        }

        public async Task<Country> UpdateCountryAsync(int id, Country country)
        {
            var oldCountry = await _countryRepository.GetAsync(id);

            if(oldCountry != null)
            {
                oldCountry.CountryName = country.CountryName;

                await _countryRepository.UpdateAsync(oldCountry);
                return oldCountry;
            }
            else
            {
                return null;
            }

            
        }
    }
}
