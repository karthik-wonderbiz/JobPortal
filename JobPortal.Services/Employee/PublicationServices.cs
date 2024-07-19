
using JobPortal.Data;
using JobPortal.IRepository;
using JobPortal.IRepository.Employee;
using JobPortal.IServices.Employee;
using JobPortal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.SkillInfoDto;

namespace JobPortal.Services.Employee
{
    public class PublicationServices : IPublicationServices
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUserRepository _userRepository;

        public PublicationServices(IPublicationRepository publicationRepository, IUserRepository userRepository)
        {
            _publicationRepository = publicationRepository;
            _userRepository = userRepository;
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
                var user = await _userRepository.GetAsync(publication.UserId);

                if (user != null)
                {
                    var publicationData = new GetPublicationDto(publication.Id, publication.PublicationTitle, publication.PublisherName, publication.PublishDate, publication.PublicationURL, user.Email, publication.Description, publication.IsActive);
                    return publicationData;
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
                var publicationDto = publications.Select(publication => new GetPublicationDto(publication.Id, publication.PublicationTitle, publication.PublisherName, publication.PublishDate, publication.PublicationURL, publication.User.Email, publication.Description, publication.IsActive));
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

                var publicationData = new GetPublicationDto(
                    publication.Id, 
                    publication.PublicationTitle, 
                    publication.PublisherName, 
                    publication.PublishDate, 
                    publication.PublicationURL, 
                    publication.User.Email, 
                    publication.Description, 
                    publication.IsActive
                    );
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

                oldPublication.PublicationTitle = publicationDto.PublicationTitle;
                oldPublication.PublisherName = publicationDto.PublisherName;
                oldPublication.PublishDate = publicationDto.PublishDate;
                oldPublication.PublicationURL = publicationDto.PublicationURL;
                oldPublication.Description = publicationDto.Description;
                oldPublication.UserId = publicationDto.UserId;
                oldPublication.IsActive = publicationDto.IsActive;

                await _publicationRepository.UpdateAsync(oldPublication);

                var user = await _userRepository.GetAsync(oldPublication.UserId);
                if (user != null)
                {
                    var updatedPublicationData = new GetPublicationDto(oldPublication.Id,
                    oldPublication.PublicationTitle,
                    oldPublication.PublisherName,
                    oldPublication.PublishDate,
                    oldPublication.PublicationURL,
                    user.Email,
                    oldPublication.Description,
                    oldPublication.IsActive);
                    return updatedPublicationData;
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

        public async Task<IEnumerable<GetPublicationDto>> GetPublicationByUserId(long UserId)
        {
            try
            {
                var publications = await _publicationRepository.GetByUserId(UserId);

                var publicationDtos = publications.Select(publication => new GetPublicationDto(
                    publication.Id, 
                    publication.PublicationTitle, 
                    publication.PublisherName, 
                    publication.PublishDate, 
                    publication.PublicationURL, 
                    publication.User.Email, 
                    publication.Description,
                    publication.IsActive
                ));

                return publicationDtos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
