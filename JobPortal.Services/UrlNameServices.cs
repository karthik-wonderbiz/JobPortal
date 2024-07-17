using JobPortal.DTO;
using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static JobPortal.DTO.UrlNameDto;

namespace JobPortal.Services
{
    public class UrlNameServices : IUrlNameServices
    {
        private readonly IUrlNameRepository _urlNameRepository;

        public UrlNameServices(IUrlNameRepository urlNameRepository)
        {
            _urlNameRepository = urlNameRepository;
        }

        public async Task<GetUrlNameDto> CreateUrlNameAsync(CreateUrlNameDto createUrlNameDto)
        {
            try
            {
                var urlName = await _urlNameRepository.CreateAsync(new UrlName()
                {
                    URLName = createUrlNameDto.UrlName,
                    URLCode = createUrlNameDto.UrlName.ToUpper().Substring(0, 3),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var createdUrlName = new GetUrlNameDto(urlName.Id, urlName.URLName, urlName.URLCode, urlName.IsActive);
                return createdUrlName;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This URL name already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteUrlNameAsync(long id)
        {
            try
            {
                var urlName = await _urlNameRepository.GetAsync(id);
                if (urlName == null)
                {
                    throw new Exception($"URL name not found for id : {id}");
                }

                var deleted = await _urlNameRepository.DeleteAsync(urlName);
                return deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetUrlNameDto>> GetUrlNameAsync()
        {
            try
            {
                var urlNames = await _urlNameRepository.GetAllAsync();

                var urlNameDtos = urlNames.Select(urlName => new GetUrlNameDto(urlName.Id, urlName.URLName, urlName.URLCode, urlName.IsActive));
                return urlNameDtos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetUrlNameDto> GetUrlNameById(long id)
        {
            try
            {
                var urlName = await _urlNameRepository.GetAsync(id);
                if (urlName == null)
                {
                    throw new Exception($"URL name not found for id : {id}");
                }

                var urlNameDto = new GetUrlNameDto(urlName.Id, urlName.URLName, urlName.URLCode, urlName.IsActive);
                return urlNameDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetUrlNameDto> UpdateUrlNameAsync(long id, UpdateUrlNameDto updateUrlNameDto)
        {
            try
            {
                var urlName = await _urlNameRepository.GetAsync(id);
                if (urlName == null)
                {
                    throw new Exception($"URL name not found for id : {id}");
                }

                urlName.URLName = updateUrlNameDto.UrlName;
                urlName.URLCode = updateUrlNameDto.UrlName.ToUpper().Substring(0, 3);
                urlName.IsActive = updateUrlNameDto.IsActive;
                urlName.UpdatedAt = DateTime.Now;

                await _urlNameRepository.UpdateAsync(urlName);

                var updatedUrlName = new GetUrlNameDto(urlName.Id, urlName.URLName, urlName.URLCode, urlName.IsActive);
                return updatedUrlName;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This URL name already exists.");
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
