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

        public async Task<Gender> CreateGenderAsync(Gender gender)
        {
            gender.GenderCode = gender.GenderCode != string.Empty ? gender.GenderCode : gender.GenderName.ToUpper().Substring(0, 1);

            gender.CreatedAt = DateTime.Now;
            gender.UpdatedAt = DateTime.Now;

            return await _genderRepository.CreateAsync(gender);
        }

        public async Task<bool> DeleteGenderAsync(long id)
        {
            var gender = await _genderRepository.GetAsync(id);

            if (gender == null)
            {
                throw new Exception($"No Gender Founder for id {id}");
            }

            bool row = await _genderRepository.DeleteAsync(gender);

            return row;
        }

        public async Task<Gender> GetGenderAsync(long id)
        {
            return await _genderRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            return await _genderRepository.GetAllAsync();
        }

        public async Task<Gender> UpdateGenderAsync(long id, Gender gender)
        {
            var oldGender = await _genderRepository.GetAsync(id);

            if (oldGender == null)
            {
                throw new Exception($"No Gender Founder for id {id}");
            }

            oldGender.GenderName = gender.GenderName;
            oldGender.GenderCode = gender.GenderCode != string.Empty ? gender.GenderCode : gender.GenderName.ToUpper().Substring(0, 1);

            oldGender.UpdatedAt = DateTime.Now;

            var res = await _genderRepository.UpdateAsync(oldGender);

            return res;
        }
    }
}
