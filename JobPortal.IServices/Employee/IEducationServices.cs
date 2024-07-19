using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.EducationDto;

namespace JobPortal.IServices.Employee
{
    public interface IEducationServices
    {
        Task<IEnumerable<GetEducationDto>> GetEducationAsync();

        Task<GetEducationDto> GetEducationAsync(long id);

        Task<GetEducationDto> CreateEducationAsync(CreateEducationDto createEducationDto);

        Task<GetEducationDto> UpdateEducationAsync(long id, UpdateEducationDto updateEducationDto);

        Task<bool> DeleteEducationAsync(long id);

        Task<IEnumerable<GetEducationDto>> GetEducationByUserId(long userId);
    }
}
