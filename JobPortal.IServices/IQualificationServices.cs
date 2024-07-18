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
    public interface IQualificationServices
    {
        Task<IEnumerable<GetQualificationDto>> GetQualificationsAsync();

        Task<GetQualificationDto> GetQualificationAsync(long id);

        Task<GetQualificationDto> CreateQualificationAsync(CreateQualificationDto qualificationDto);

        Task<GetQualificationDto> UpdateQualificationAsync(long id, UpdateQualificationDto qualificationDto);

        Task<bool> DeleteQualificationAsync(long id);
    }
}
