using JobPortal.Data;
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

        public async Task<GetCountryDto> CreateCountryAsync(CreateCountryDto countryDto)
        {
            var country = await _countryRepository.CreateAsync(new Country() { CountryName = countryDto.CountryName,CountryCode = countryDto.CountryName.ToUpper().Substring(0,3), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            return new GetCountryDto(country.Id, country.CountryName, country.CountryCode, country.IsActive);
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

        public async Task<IEnumerable<GetCountryDto>> GetAllCountriesAsync()
        {
            var countries = await _countryRepository.GetAllAsync();

            var countryDto = countries.Select(country => new GetCountryDto(country.Id, country.CountryName, country.CountryCode, country.IsActive));

            return countryDto;

        }

        public async Task<GetCountryDto> GetCountryByIdAsync(long id)
        {
            var country = await _countryRepository.GetAsync(id);

            return new GetCountryDto(country.Id, country.CountryName, country.CountryCode, country.IsActive);
        }

        public async Task<GetCountryDto> UpdateCountryAsync(long id, UpdateCountryDto countryDto)
        {
            var oldCountry = await _countryRepository.GetAsync(id);

            if(oldCountry == null)
            {
                throw new Exception($"Object not found for id : {id}");
            }

            oldCountry.CountryName = countryDto.CountryName;
            oldCountry.CountryCode = countryDto.CountryName.ToUpper().Substring(0, 3);
            oldCountry.IsActive = countryDto.IsActive;

            await _countryRepository.UpdateAsync(oldCountry);

            return new GetCountryDto(oldCountry.Id, oldCountry.CountryName, oldCountry.CountryCode, oldCountry.IsActive);
        }
    }
}
