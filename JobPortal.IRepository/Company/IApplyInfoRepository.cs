using JobPortal.Model.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IRepository.Company
{
    public interface IApplyInfoRepository : IRepository<ApplyInfo>
    {
        Task<IEnumerable<ApplyInfo>> GetApplyInfoByUserId(long userId);
    }
}
