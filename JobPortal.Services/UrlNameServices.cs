using JobPortal.IRepository;
using JobPortal.IServices;
using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.LanguageDto;
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
                var urlname = await _urlNameRepository.CreateAsync(new UrlName() { URLName = createUrlNameDto.UrlName, URLCode = createUrlNameDto.UrlName.ToUpper().Substring(0, 3), CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
                var res = new GetUrlNameDto(urlname.Id, urlname.URLName, urlname.URLCode, urlname.IsActive);
                return res;
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
                var oldUrlName = await _urlNameRepository.GetAsync(id);
                if (oldUrlName == null)
                {
                    throw new Exception($"No Language is found for id : {id}");
                }
                var res = await _urlNameRepository.DeleteAsync(oldUrlName);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetUrlNameDto>> GetUrlNameAsync()
        {
            var urlname = await _urlNameRepository.GetAllAsync();
            var urlnameDto = urlname.Select(urlname => new GetUrlNameDto(urlname.Id, urlname.URLName, urlname.URLCode, urlname.IsActive));
            return urlnameDto;
        }

        public async Task<GetUrlNameDto> GetUrlNameById(long id)
        {
            try
            {
                var urlName = await _urlNameRepository.GetAsync(id);
                if (urlName == null)
                {
                    throw new Exception($"No Language is found for id : {id}");
                }
                var res = new GetUrlNameDto(urlName.Id, urlName.URLName, urlName.URLCode, urlName.IsActive);
                return res;
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
                    throw new Exception($"Object not found for id : {id}");
                }

                urlName.URLName = updateUrlNameDto.UrlName;
                urlName.URLCode = updateUrlNameDto.UrlCode.ToUpper().Substring(0, 3);
                urlName.IsActive = updateUrlNameDto.IsActive;

                await _urlNameRepository.UpdateAsync(urlName);

                var res = new GetUrlNameDto(urlName.Id, urlName.URLName, urlName.URLCode, urlName.IsActive);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
