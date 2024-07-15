using JobPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices
{
    public interface IGenderServices
    {
        public Task<IEnumerable<Gender>> GetGendersAsync();

        public Task<Gender> GetGenderAsync(int id);

        public Task<Gender> CreateGenderAsync(Gender gender);

        public Task<Gender> UpdateGenderAsync(int id, Gender gender);

        public Task<bool> DeleteGenderAsync(int id);
    }
}
