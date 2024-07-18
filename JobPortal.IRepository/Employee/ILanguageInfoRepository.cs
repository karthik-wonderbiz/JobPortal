using JobPortal.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.LanguageInfoDto;

namespace JobPortal.IRepository.Employee
{
    public interface ILanguageInfoRepository : IRepository<LanguageInfo>
    {
        Task<IEnumerable<LanguageInfo>> GetLanguageInfoByUserId(long userId);
    }
}
