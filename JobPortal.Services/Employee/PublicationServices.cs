using JobPortal.Data;
using JobPortal.IRepository.Employee;
using JobPortal.IServices.Employee;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Employee
{
    public class PublicationServices : IPublicationServices
    {
        private readonly IPublicationRepository _publicationRepository;

        public PublicationServices(IPublicationRepository publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }
        public async Task<GetPublicationDto> CreatePublicationAsync(CreatePublicationDto publicationDto)
        {
            try
            {
                var publication = await _publicationRepository.CreateAsync(new Publication()
                {
                    PublicationTitle = publicationDto.PublicationTitle,
                    PublisherName = publicationDto.PublisherName,
                    PublishDate = publicationDto.PublishDate,
                    PublicationURL = publicationDto.PublicationURL,
                    Description = publicationDto.Description,
                    UserId = publicationDto.UserId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
                var publicationData = new GetPublicationDto(publication.Id, publication.PublicationTitle, publication.PublisherName, publication.PublishDate, publication.PublicationURL, publication.UserId, publication.Description, publication.IsActive);
                return publicationData;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> DeletePublicationAsync(long id)
        {
            try
            {
                var publication = await _publicationRepository.GetAsync(id);

                if (publication == null)
                {
                    throw new Exception($"Publication not found for id : {id}");
                }
                var deletedPublicationData = await _publicationRepository.DeleteAsync(publication);
                return deletedPublicationData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetPublicationDto>> GetAllPublicationsAsync()
        {
            try
            {
                var publications = await _publicationRepository.GetAllAsync();
                var publicationDto = publications.Select(publication => new GetPublicationDto(publication.Id, publication.PublicationTitle, publication.PublisherName, publication.PublishDate, publication.PublicationURL, publication.UserId, publication.Description, publication.IsActive));
                return publicationDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetPublicationDto> GetPublicationByIdAsync(long id)
        {
            try
            {
                var publication = await _publicationRepository.GetAsync(id);

                if (publication == null)
                {
                    throw new Exception($"Publication not found for id : {id}");
                }

                var publicationData = new GetPublicationDto(publication.Id, publication.PublicationTitle, publication.PublisherName, publication.PublishDate, publication.PublicationURL, publication.UserId, publication.Description, publication.IsActive);
                return publicationData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetPublicationDto> UpdatePublicationAsync(long id, UpdatePublicationDto publicationDto)
        {
            try
            {
                var oldPublication = await _publicationRepository.GetAsync(id);

                if (oldPublication == null)
                {
                    throw new Exception($"Publication not found for id : {id}");
                }

                oldPublication.PublicationTitle = oldPublication.PublicationTitle;
                oldPublication.PublisherName = oldPublication.PublisherName;
                oldPublication.PublishDate = oldPublication.PublishDate;
                oldPublication.PublicationURL = oldPublication.PublicationURL;
                oldPublication.Description = oldPublication.Description;
                oldPublication.UserId = oldPublication.UserId;

                oldPublication.IsActive = oldPublication.IsActive;

                await _publicationRepository.UpdateAsync(oldPublication);

                var updatedPublicationData = new GetPublicationDto(oldPublication.Id, oldPublication.PublicationTitle, oldPublication.PublisherName, oldPublication.PublishDate, oldPublication.PublicationURL, oldPublication.UserId, oldPublication.Description, oldPublication.IsActive);
                return updatedPublicationData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<GetPublicationDto>> GetPublicationByUserId(long UserId)
        {
            throw new NotImplementedException();
        }
    }
}
