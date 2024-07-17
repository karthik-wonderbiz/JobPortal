using JobPortal.Data;
using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                var country = await _countryRepository.CreateAsync(new Country()
                {
                    CountryName = countryDto.CountryName,
                    CountryCode = countryDto.CountryName.ToUpper().Substring(0, 3),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
                var countryData = new GetCountryDto(country.Id, country.CountryName, country.CountryCode, country.IsActive);
                return countryData;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This country already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCountryAsync(long id)
        {
            try
            {
                var country = await _countryRepository.GetAsync(id);

                if (country == null)
                {
                    throw new Exception($"Country not found for id : {id}");
                }
                var deletedCountryData = await _countryRepository.DeleteAsync(country);
                return deletedCountryData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetCountryDto>> GetAllCountriesAsync()
        {
            try
            {
                var countries = await _countryRepository.GetAllAsync();
                var countryDto = countries.Select(country => new GetCountryDto(country.Id, country.CountryName, country.CountryCode, country.IsActive));
                return countryDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCountryDto> GetCountryByIdAsync(long id)
        {
            try
            {
                var country = await _countryRepository.GetAsync(id);

                if (country == null)
                {
                    throw new Exception($"Country not found for id : {id}");
                }

                var countryData = new GetCountryDto(country.Id, country.CountryName, country.CountryCode, country.IsActive);
                return countryData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCountryDto> UpdateCountryAsync(long id, UpdateCountryDto countryDto)
        {
            try
            {
                var oldCountry = await _countryRepository.GetAsync(id);

                if (oldCountry == null)
                {
                    throw new Exception($"Country not found for id : {id}");
                }

                oldCountry.CountryName = countryDto.CountryName;
                oldCountry.CountryCode = countryDto.CountryName.ToUpper().Substring(0, 3);
                oldCountry.IsActive = countryDto.IsActive;

                await _countryRepository.UpdateAsync(oldCountry);

                var updatedCountryInfo = new GetCountryDto(oldCountry.Id, oldCountry.CountryName, oldCountry.CountryCode, oldCountry.IsActive);
                return updatedCountryInfo;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This country already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
