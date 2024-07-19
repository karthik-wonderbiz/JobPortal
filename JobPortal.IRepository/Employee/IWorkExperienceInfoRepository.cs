using JobPortal.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepository.Employee
{
    public interface IWorkExperienceInfoRepository : IRepository <WorkExperienceInfo>
    {
        Task<IEnumerable<WorkExperienceInfo>> GetByUserId(long userId);
    }
}
