using JobPortal.Data;
using JobPortal.DTO;
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
    public class CityServices : ICityServices
    {
        private readonly ICityRepository _cityRepository;

        public CityServices(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<GetCityDto> CreateCityAsync(CreateCityDto cityDto)
        {
            try
            {
                var city = await _cityRepository.CreateAsync(new City()
                {
                    CityName = cityDto.CityName,
                    CityCode = cityDto.CityName.ToUpper().Substring(0, 3),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var createdCity = new GetCityDto(city.Id, city.CityName, city.CityCode, city.IsActive);
                return createdCity;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This city already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCityAsync(long id)
        {
            try
            {
                var city = await _cityRepository.GetAsync(id);
                if (city == null)
                {
                    throw new Exception($"City not found for id : {id}");
                }

                var deleted = await _cityRepository.DeleteAsync(city);
                return deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetCityDto>> GetAllCitiesAsync()
        {
            try
            {
                var cities = await _cityRepository.GetAllAsync();

                var cityDtos = cities.Select(city => new GetCityDto(
                    city.Id,
                    city.CityName,
                    city.CityCode,
                    city.IsActive
                ));

                return cityDtos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCityDto> GetCityByIdAsync(long id)
        {
            try
            {
                var city = await _cityRepository.GetAsync(id);
                if (city == null)
                {
                    throw new Exception($"City not found for id : {id}");
                }

                var cityDto = new GetCityDto(city.Id, city.CityName, city.CityCode, city.IsActive);
                return cityDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetCityDto> UpdateCityAsync(long id, UpdateCityDto cityDto)
        {
            try
            {
                var oldCity = await _cityRepository.GetAsync(id);
                if (oldCity == null)
                {
                    throw new Exception($"City not found for id : {id}");
                }

                oldCity.CityName = cityDto.CityName;
                oldCity.CityCode = cityDto.CityName.ToUpper().Substring(0, 3);
                oldCity.IsActive = cityDto.IsActive;
                oldCity.UpdatedAt = DateTime.Now;

                await _cityRepository.UpdateAsync(oldCity);

                var updatedCity = new GetCityDto(oldCity.Id, oldCity.CityName, oldCity.CityCode, oldCity.IsActive);
                return updatedCity;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This city already exists.");
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
