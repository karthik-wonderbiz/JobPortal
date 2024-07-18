using JobPortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices.Employee
{
    public interface IPublicationServices
    {
        public Task<GetPublicationDto> GetPublicationByIdAsync(long id);

        public Task<IEnumerable<GetPublicationDto>> GetAllPublicationsAsync();
        public Task<GetPublicationDto> CreatePublicationAsync(CreatePublicationDto publicationDto);
        public Task<GetPublicationDto> UpdatePublicationAsync(long id, UpdatePublicationDto publicationDto);
        public Task<bool> DeletePublicationAsync(long id);
        public Task<IEnumerable<GetPublicationDto>> GetPublicationByUserId(long UserId);
    }
}
