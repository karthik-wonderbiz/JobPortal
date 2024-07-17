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
    public class CityServices : ICityServices
    {
        private readonly ICityRepository _repository;
        public CityServices(ICityRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCityDto> CreateCityAsync(CreateCityDto cityDto)
        {

            try
            {
                var city = await _repository.CreateAsync(new City()
                {
                    CityName = cityDto.CityName,
                    CityCode = cityDto.CityName.ToUpper().Substring(0, 3),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
                var createCityObject = new GetCityDto(city.Id, city.CityName, city.CityCode, city.IsActive);
                return createCityObject;
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
                var oldCity = await _repository.GetAsync(id);
                if (oldCity == null)
                {
                    throw new Exception($"Object not found for id : {id}");
                }
                var deleteCityObject = await _repository.DeleteAsync(oldCity);
                return deleteCityObject;
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
                var cities = await _repository.GetAllAsync();

                var getAllCityObject = cities.Select(city => new GetCityDto(city.Id, city.CityName, city.CityCode, city.IsActive));

                return getAllCityObject;
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
                var city = await _repository.GetAsync(id);
                if (city == null)
                {
                    throw new Exception($"Object not found for id : {id}");

                }
                var getCityObject = new GetCityDto(city.Id, city.CityName, city.CityCode, city.IsActive);
                return getCityObject;
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
                var oldCity = await _repository.GetAsync(id);

                if (oldCity == null)
                {
                    throw new Exception($"Object not found for id : {id}");

                }
                oldCity.CityName = cityDto.CityName;
                oldCity.CityCode = cityDto.CityName.ToUpper().Substring(0, 3);
                oldCity.IsActive = cityDto.IsActive;

                await _repository.UpdateAsync(oldCity);

                var updateCityObject = new GetCityDto(oldCity.Id, oldCity.CityName, oldCity.CityCode, oldCity.IsActive);
                return updateCityObject;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
