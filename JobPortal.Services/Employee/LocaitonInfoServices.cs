using JobPortal.DTO;
using JobPortal.DTO.Employee;
using JobPortal.IRepository;
using JobPortal.IRepository.Employee;
using JobPortal.IServices.Employee;
using JobPortal.Model;
using JobPortal.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.LocationInfoDto;

namespace JobPortal.Services.Employee
{
    public class LocationInfoServices : ILocationInfoServices
    {
        private readonly ILocationInfoRepository _locationInfoRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ITrainLineRepository _trainLineRepository;

        public LocationInfoServices(
            ILocationInfoRepository locationInfoRepository, 
            IUserRepository userRepository, 
            ICityRepository cityRepository, 
            IStateRepository stateRepository, 
            ICountryRepository countryRepository, 
            ITrainLineRepository trainLineRepository
            )
        {
            _locationInfoRepository = locationInfoRepository;
            _cityRepository = cityRepository;
            _stateRepository = stateRepository;
            _countryRepository = countryRepository;
            _trainLineRepository = trainLineRepository;
            _userRepository = userRepository;
        }

        public async Task<GetLocationInfoDto> CreateLocationInfoAsync(CreateLocationInfoDto createLocationInfoDto)
        {
            try
            {
                var locationInfo = await _locationInfoRepository.CreateAsync(new LocationInfo()
                {
                    UserId = createLocationInfoDto.UserId,
                    CityId = createLocationInfoDto.CityId,
                    StateId = createLocationInfoDto.StateId,
                    CountryId = createLocationInfoDto.CountryId,
                    TrainLineId = createLocationInfoDto.TrainLineId,
                    AddressLine1 = createLocationInfoDto.AddressLine1,
                    AddressLine2 = createLocationInfoDto.AddressLine2,
                    ZipCode = createLocationInfoDto.ZipCode,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var user = await _userRepository.GetAsync(locationInfo.UserId);
                var city = await _cityRepository.GetAsync(locationInfo.CityId);
                var state = await _stateRepository.GetAsync(locationInfo.StateId);
                var country = await _countryRepository.GetAsync(locationInfo.CountryId);
                var trainLine = await _trainLineRepository.GetAsync(locationInfo.TrainLineId);

                if (city != null && user != null)
                {

                    var createdLocationInfo = new GetLocationInfoDto(
                        locationInfo.Id,
                        user.Email,
                        city.CityName,
                        state.StateName,
                        country.CountryName,
                        trainLine.TrainLineName,
                        locationInfo.AddressLine1,
                        locationInfo.AddressLine2,
                        locationInfo.ZipCode
                    );

                    return createdLocationInfo;
                }
                else
                {
                    throw new Exception("Invalid User");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetLocationInfoDto> GetLocationInfoAsync(long id)
        {
            try
            {
                var locationInfo = await _locationInfoRepository.GetAsync(id);

                if (locationInfo == null)
                {
                    throw new Exception($"Location Info not found for id : {id}");
                }

                var locationInfoDto = new GetLocationInfoDto(
                    locationInfo.Id,
                    locationInfo.User.Email,
                    locationInfo.City.CityName,
                    locationInfo.State.StateName,
                    locationInfo.Country.CountryName,
                    locationInfo.TrainLine.TrainLineName,
                    locationInfo.AddressLine1,
                    locationInfo.AddressLine2,
                    locationInfo.ZipCode
                );

                return locationInfoDto;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetLocationInfoDto>> GetLocationInfoByUserId(long userId)
        {
            try
            {
                var locationInfos = await _locationInfoRepository.GetByUserId(userId);

                var locationInfoDtos = locationInfos.Select(locationInfo => new GetLocationInfoDto(
                    locationInfo.Id,
                    locationInfo.User.Email,
                    locationInfo.City.CityName,
                    locationInfo.State.StateName,
                    locationInfo.Country.CountryName,
                    locationInfo.TrainLine.TrainLineName,
                    locationInfo.AddressLine1,
                    locationInfo.AddressLine2,
                    locationInfo.ZipCode
                ));

                return locationInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetLocationInfoDto>> GetLocationInfosAsync()
        {
            try
            {
                var locationInfos = await _locationInfoRepository.GetAllAsync();

                var locationInfoDtos = locationInfos.Select(locationInfo => new GetLocationInfoDto(
                    locationInfo.Id,
                    locationInfo.User.Email,
                    locationInfo.City.CityName,
                    locationInfo.State.StateName,
                    locationInfo.Country.CountryName,
                    locationInfo.TrainLine.TrainLineName,
                    locationInfo.AddressLine1,
                    locationInfo.AddressLine2,
                    locationInfo.ZipCode
                ));

                return locationInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetLocationInfoDto> UpdateLocationInfoAsync(long id, UpdateLocationInfoDto updateLocationInfoDto)
        {
            try
            {
                var oldLocationInfo = await _locationInfoRepository.GetAsync(id);
                if (oldLocationInfo == null)
                {
                    throw new Exception($"Location not found for id : {id}");
                }

                oldLocationInfo.UserId = updateLocationInfoDto.UserId;
                oldLocationInfo.CityId = updateLocationInfoDto.CityId;
                oldLocationInfo.StateId = updateLocationInfoDto.StateId;
                oldLocationInfo.CountryId = updateLocationInfoDto.CountryId;
                oldLocationInfo.TrainLineId = updateLocationInfoDto.TrainLineId;
                oldLocationInfo.AddressLine1 = updateLocationInfoDto.AddressLine1;
                oldLocationInfo.AddressLine2 = updateLocationInfoDto.AddressLine2;
                oldLocationInfo.ZipCode = updateLocationInfoDto.ZipCode;
                oldLocationInfo.UpdatedAt = DateTime.Now;

                await _locationInfoRepository.UpdateAsync(oldLocationInfo);

                var user = await _userRepository.GetAsync(oldLocationInfo.UserId);
                var city = await _cityRepository.GetAsync(oldLocationInfo.CityId);
                var state = await _stateRepository.GetAsync(oldLocationInfo.StateId);
                var country = await _countryRepository.GetAsync(oldLocationInfo.CountryId);
                var trainLine = await _trainLineRepository.GetAsync(oldLocationInfo.TrainLineId);

                if (city != null && user != null)
                {

                    var updatedLocationInfo = new GetLocationInfoDto(
                        oldLocationInfo.Id,
                        user.Email,
                        city.CityName,
                        state.StateName,
                        country.CountryName,
                        trainLine.TrainLineName,
                        oldLocationInfo.AddressLine1,
                        oldLocationInfo.AddressLine2,
                        oldLocationInfo.ZipCode
                    );

                    return updatedLocationInfo;
                }
                else
                {
                    throw new Exception("Invalid User");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteLocationInfoAsync(long id)
        {
            try
            {
                var locationInfo = await _locationInfoRepository.GetAsync(id);
                if (locationInfo == null)
                {
                    throw new Exception($"Location Info not found for id : {id}");
                }

                var deleted = await _locationInfoRepository.DeleteAsync(locationInfo);
                return deleted;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
