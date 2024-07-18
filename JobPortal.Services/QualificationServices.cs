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
    public class QualificationServices : IQualificationServices
    {
        private readonly IQualificationRepository _qualificationRepository;

        public QualificationServices(IQualificationRepository qualificationRepository)
        {
            _qualificationRepository = qualificationRepository;
        }

        public async Task<GetQualificationDto> CreateQualificationAsync(CreateQualificationDto qualificationDto)
        {
            try
            {
                var qualification = await _qualificationRepository.CreateAsync(new Qualification()
                {
                    QualificationName = qualificationDto.QualificationName,
                    QualificationCode = qualificationDto.QualificationName.ToUpper().Substring(0, 1),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });

                var res = new GetQualificationDto(
                    qualification.Id,
                    qualification.QualificationName,
                    qualification.QualificationCode,
                    qualification.IsActive
                );

                return res;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This Qualification already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetQualificationDto> GetQualificationAsync(long id)
        {
            try
            {
                var qualification = await _qualificationRepository.GetAsync(id);

                if (qualification == null)
                {
                    throw new Exception($"No Qualification Found with id : {id}");
                }

                var qualificationDto = new GetQualificationDto(
                    qualification.Id,
                    qualification.QualificationName,
                    qualification.QualificationCode,
                    qualification.IsActive
                );

                return qualificationDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetQualificationDto>> GetQualificationsAsync()
        {
            try
            {
                var qualifications = await _qualificationRepository.GetAllAsync();

                var qualificationsDto = qualifications.Select(qualification => new GetQualificationDto(
                    qualification.Id,
                    qualification.QualificationName,
                    qualification.QualificationCode,
                    qualification.IsActive
                ));

                return qualificationsDto.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetQualificationDto> UpdateQualificationAsync(long id, UpdateQualificationDto qualificationDto)
        {
            try
            {
                var oldQualification = await _qualificationRepository.GetAsync(id);

                if (oldQualification == null)
                {
                    throw new Exception($"No Qualification Found for id : {id}");
                }

                oldQualification.QualificationName = qualificationDto.QualificationName;
                oldQualification.QualificationCode = qualificationDto.QualificationName.ToUpper().Substring(0, 1);
                oldQualification.UpdatedAt = DateTime.Now;

                var qualification = await _qualificationRepository.UpdateAsync(oldQualification);

                var newQualificationDto = new GetQualificationDto(
                    qualification.Id,
                    qualification.QualificationName,
                    qualification.QualificationCode,
                    qualification.IsActive
                );

                return newQualificationDto;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("Cannot insert duplicate key row") == true ||
                    ex.InnerException?.Message.Contains("UNIQUE constraint failed") == true)
                {
                    throw new Exception("This Qualification already exists.");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteQualificationAsync(long id)
        {
            try
            {
                var qualification = await _qualificationRepository.GetAsync(id);

                if (qualification == null)
                {
                    throw new Exception($"No Qualification Found for id: {id}");
                }

                bool row = await _qualificationRepository.DeleteAsync(qualification);

                return row;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
