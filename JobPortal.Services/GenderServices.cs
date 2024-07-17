using JobPortal.Data;
using JobPortal.DTO;
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
    public class GenderServices : IGenderServices
    {
        private readonly IGenderRepository _genderRepository;

        public GenderServices(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<GetGenderDto> CreateGenderAsync(CreateGenderDto genderDto)
        {
            try
            {
                //gender.GenderCode = gender.GenderCode != string.Empty ? gender.GenderCode : gender.GenderName.ToUpper().Substring(0, 1);

                //gender.CreatedAt = DateTime.Now;
                //gender.UpdatedAt = DateTime.Now;

                //return await _genderRepository.CreateAsync(gender);

                var gender = await _genderRepository.CreateAsync(new Gender() { 
                    GenderName = genderDto.GenderName, 
                    GenderCode = genderDto.GenderName.ToUpper().Substring(0, 1), 
                    CreatedAt = DateTime.Now, 
                    UpdatedAt = DateTime.Now 
                });

                var res = new GetGenderDto(
                    gender.Id, 
                    gender.GenderName, 
                    gender.GenderCode, 
                    gender.IsActive
                    );

                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<GetGenderDto> GetGenderAsync(long id)
        {
            try
            {
                var gender = await _genderRepository.GetAsync(id);

                if(gender == null)
                {
                    throw new Exception($"No Gender Found with id  {id}");
                }

                var genderDto = new GetGenderDto(
                    gender.Id, 
                    gender.GenderName, 
                    gender.GenderCode, 
                    gender.IsActive
                    );

                return genderDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetGenderDto>> GetGendersAsync()
        {
            try
            {
                var genders = await _genderRepository.GetAllAsync();

                var gendersDto = genders.Select(gender => new GetGenderDto(
                    gender.Id, 
                    gender.GenderName, 
                    gender.GenderName,
                    gender.IsActive
                    ));

                return gendersDto.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetGenderDto> UpdateGenderAsync(long id, UpdateGenderDto genderDto)
        {
            try
            {
                var oldGender = await _genderRepository.GetAsync(id);

                if (oldGender == null)
                {
                    throw new Exception($"No Gender Founder for id {id}");
                }

                oldGender.GenderName = genderDto.GenderName;
                oldGender.GenderCode = genderDto.GenderCode != string.Empty ? genderDto.GenderCode : genderDto.GenderName.ToUpper().Substring(0, 1);

                oldGender.UpdatedAt = DateTime.Now;

                var gender = await _genderRepository.UpdateAsync(oldGender);

                var newGenderDto = new GetGenderDto(
                    gender.Id,
                    gender.GenderName,
                    gender.GenderCode,
                    gender.IsActive
                    );

                return newGenderDto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteGenderAsync(long id)
        {
            try
            {
                var gender = await _genderRepository.GetAsync(id);

                if (gender == null)
                {
                    throw new Exception($"No Gender Found for id {id}");
                }

                bool row = await _genderRepository.DeleteAsync(gender);

                return row;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
