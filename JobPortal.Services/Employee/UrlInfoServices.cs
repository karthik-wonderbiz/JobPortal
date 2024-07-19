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
using static JobPortal.DTO.Employee.UrlInfoDto;

namespace JobPortal.Services.Employee
{
    public class UrlInfoServices : IUrlInfoServices
    {
        private readonly IUrlInfoRepository _urlInfoRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUrlNameRepository _urlRepository;

        public UrlInfoServices(IUrlInfoRepository urlInfoRepository, IUserRepository userRepository, IUrlNameRepository urlRepository)
        {
            _urlInfoRepository = urlInfoRepository;
            _urlRepository = urlRepository;
            _userRepository = userRepository;
        }

        public async Task<GetUrlInfoDto> CreateUrlInfoAsync(CreateUrlInfoDto createUrlInfoDto)
        {
            try
            {
                var urlInfo = await _urlInfoRepository.CreateAsync(new UrlInfo()
                {
                    UserId = createUrlInfoDto.UserId,
                    UrlNameId = createUrlInfoDto.UrlNameId,
                    UrlValue = createUrlInfoDto.UrlValue,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var user = await _userRepository.GetAsync(urlInfo.UserId);
                var url = await _urlRepository.GetAsync(urlInfo.UrlNameId);

                if (url != null && user != null)
                {

                    var createdUrlInfo = new GetUrlInfoDto(
                        urlInfo.Id,
                        user.Email,
                        url.URLName,
                        urlInfo.UrlValue
                    );

                    return createdUrlInfo;
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

        public async Task<GetUrlInfoDto> GetUrlInfoAsync(long id)
        {
            try
            {
                var urlInfo = await _urlInfoRepository.GetAsync(id);

                if (urlInfo == null)
                {
                    throw new Exception($"Url Info not found for id : {id}");
                }

                var urlInfoDto = new GetUrlInfoDto(
                    urlInfo.Id,
                    urlInfo.User.Email,
                    urlInfo.UrlName.URLName,
                    urlInfo.UrlValue
                );

                return urlInfoDto;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetUrlInfoDto>> GetUrlInfoByUserId(long userId)
        {
            try
            {
                var urlInfos = await _urlInfoRepository.GetByUserId(userId);

                var urlInfoDtos = urlInfos.Select(urlInfo => new GetUrlInfoDto(
                    urlInfo.Id,
                    urlInfo.User.Email,
                    urlInfo.UrlName.URLName,
                    urlInfo.UrlValue
                ));

                return urlInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetUrlInfoDto>> GetUrlInfosAsync()
        {
            try
            {
                var urlInfos = await _urlInfoRepository.GetAllAsync();

                var urlInfoDtos = urlInfos.Select(urlInfo => new GetUrlInfoDto(
                    urlInfo.Id,
                    urlInfo.User.Email,
                    urlInfo.UrlName.URLName,
                    urlInfo.UrlValue
                ));

                return urlInfoDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetUrlInfoDto> UpdateUrlInfoAsync(long id, UpdateUrlInfoDto updateUrlInfoDto)
        {
            try
            {
                var oldUrlInfo = await _urlInfoRepository.GetAsync(id);
                if (oldUrlInfo == null)
                {
                    throw new Exception($"Url not found for id : {id}");
                }

                oldUrlInfo.UserId = updateUrlInfoDto.UserId;
                oldUrlInfo.UrlNameId = updateUrlInfoDto.UrlNameId;
                oldUrlInfo.UrlValue = updateUrlInfoDto.UrlValue;
                oldUrlInfo.UpdatedAt = DateTime.Now;

                await _urlInfoRepository.UpdateAsync(oldUrlInfo);

                var user = await _userRepository.GetAsync(oldUrlInfo.UserId);
                var url = await _urlRepository.GetAsync(oldUrlInfo.UrlNameId);

                if (url != null && user != null)
                {

                    var updatedUrlInfo = new GetUrlInfoDto(
                        oldUrlInfo.Id,
                        user.Email,
                        url.URLName,
                        oldUrlInfo.UrlValue
                    );

                    return updatedUrlInfo;
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

        public async Task<bool> DeleteUrlInfoAsync(long id)
        {
            try
            {
                var urlInfo = await _urlInfoRepository.GetAsync(id);
                if (urlInfo == null)
                {
                    throw new Exception($"Url Info not found for id : {id}");
                }

                var deleted = await _urlInfoRepository.DeleteAsync(urlInfo);
                return deleted;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
