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
            gender.CreatedAt = DateTime.Now;
            gender.LastUpdatedAt = DateTime.Now;

            return await _genderRepository.CreateAsync(gender);
        }

        public async Task<bool> DeleteGenderAsync(int id)
        {
            var gender = await _genderRepository.GetAsync(id);

            if (gender != null)
            {
                bool row = await _genderRepository.DeleteAsync(gender);

                return row;
            }
            return false;
        }

        public async Task<Gender> GetGenderAsync(int id)
        {
            return await _genderRepository.GetAsync(id);
        }

        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            return await _genderRepository.GetAllAsync();
        }

        public async Task<Gender> UpdateGenderAsync(int id, Gender gender)
        {
            var oldGender = await _genderRepository.GetAsync(id);

            if (oldGender != null)
            {
                oldGender.GenderName = gender.GenderName;

                oldGender.LastUpdatedAt = DateTime.Now;
            }

            return oldGender;
        }
    }
}
