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
        Task<IEnumerable<Gender>> GetGendersAsync();

        Task<Gender> GetGenderAsync(long id);

        Task<Gender> CreateGenderAsync(Gender gender);

        Task<Gender> UpdateGenderAsync(long id, Gender gender);

        Task<bool> DeleteGenderAsync(long id);
    }
}
