using JobPortal.Data;
using JobPortal.DTO.Company;
using JobPortal.IRepository.Company;
using JobPortal.IServices.Company;
using JobPortal.Model;
using JobPortal.Model.Company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Company
{
    public class ContactPersonServices : IContactPersonServices
    {
        private readonly IContactPersonRepository _contactPersonRepository;
        private readonly ICompanyInfoRepository _companyInfoRepository;

        public ContactPersonServices(IContactPersonRepository contactPersonRepository, ICompanyInfoRepository companyInfoRepository)
        {
            _contactPersonRepository = contactPersonRepository;
            _companyInfoRepository = companyInfoRepository;
        }

        public async Task<GetContactPersonDto> CreateContactPersonAsync(CreateContactPersonDto contactPersonDto)
        {
            try
            {
                var contactPerson = await _contactPersonRepository.CreateAsync(new ContactPerson()
                {
                    CompanyId = contactPersonDto.CompanyId,
                    ContactPersonName = contactPersonDto.ContactPersonName,
                    ContactPersonEmail = contactPersonDto.ContactPersonEmail,
                    ContactPersonPhone = contactPersonDto.ContactPersonPhone,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var res = new GetContactPersonDto(contactPerson.Id, contactPerson.ContactPersonName, contactPerson.ContactPersonPhone, contactPerson.ContactPersonEmail);
                return res;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This Contact Person already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteContactPersonAsync(long id)
        {
            try
            {
                var oldContactPerson = await _contactPersonRepository.GetAsync(id);
                if (oldContactPerson == null)
                {
                    throw new Exception($"No Contact Person found for id : {id}");
                }

                var res = await _contactPersonRepository.DeleteAsync(oldContactPerson);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetContactPersonDto>> GetAllContactPersonAsync()
        {
            try
            {
                var contactPersons = await _contactPersonRepository.GetAllAsync();

                var contactPersonDto = contactPersons.Select(contactPerson => new GetContactPersonDto(
                    contactPerson.Id,
                    contactPerson.ContactPersonName,
                    contactPerson.ContactPersonPhone,
                    contactPerson.ContactPersonEmail
                ));

                return contactPersonDto.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetContactPersonDto> GetContactPersonByIdAsync(long id)
        {
            try
            {
                var contactPerson = await _contactPersonRepository.GetAsync(id);
                if (contactPerson == null)
                {
                    throw new Exception($"No Contact Person found for id : {id}");
                }

                var res = new GetContactPersonDto(contactPerson.Id, contactPerson.ContactPersonName, contactPerson.ContactPersonPhone, contactPerson.ContactPersonEmail);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetContactPersonDto> UpdateContactPersonAsync(long id, UpdateContactPersonDto contactPersonDto)
        {
            try
            {
                var oldContactPerson = await _contactPersonRepository.GetAsync(id);
                if (oldContactPerson == null)
                {
                    throw new Exception($"No Contact Person found for id : {id}");
                }

                oldContactPerson.ContactPersonName = contactPersonDto.ContactPersonName;
                oldContactPerson.ContactPersonPhone = contactPersonDto.ContactPersonPhone;
                oldContactPerson.ContactPersonEmail = contactPersonDto.ContactPersonEmail;
                oldContactPerson.UpdatedAt = DateTime.Now;

                await _contactPersonRepository.UpdateAsync(oldContactPerson);

                var res = new GetContactPersonDto(oldContactPerson.Id, oldContactPerson.ContactPersonName, oldContactPerson.ContactPersonPhone, oldContactPerson.ContactPersonEmail);
                return res;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This Contact Person already exists.");
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
