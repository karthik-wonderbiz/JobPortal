using JobPortal.Data;
using JobPortal.DTO;
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
        Task<IEnumerable<GetGenderDto>> GetGendersAsync();

        Task<GetGenderDto> GetGenderAsync(long id);

        Task<GetGenderDto> CreateGenderAsync(CreateGenderDto genderDto);

        Task<GetGenderDto> UpdateGenderAsync(long id, UpdateGenderDto genderDto);

        Task<bool> DeleteGenderAsync(long id);
    }
}
