using JobPortal.Data;
using JobPortal.IRepository;
using JobPortal.IRepository.Company;
using JobPortal.Model.Company;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Company.CompanyInfoDto;

namespace JobPortal.Repository.Company
{
    public class CompanyInfoRepository : Repository<CompanyInfo>, ICompanyInfoRepository
    {
        private readonly JobPortalDbContext _dbcontext;
        public CompanyInfoRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<IEnumerable<CompanyInfo>> GetCompanyInfoByUserId(long userId)
        {
            try
            {
                var companies = await _dbcontext.companyInfo
                    .Include(li => li.User)
                    .Include(li => li.Company)
                    .ToListAsync();
                return companies;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve company by user id.", ex);
            }
        }
        // public async Task<IEnumerable<SkillInfo>> GetAllAsync()
        // {
        //     try
        //     {
        //         var skillInfos = await _dbcontext.skillInfos
        //             .Include(li => li.User)
        //             .Include(li => li.Skill)
        //             .ToListAsync();

        //         return skillInfos;
        //     }
        //     catch (Exception)
        //     {
        //         throw;
        //     }
        // }

        // public async Task<SkillInfo> GetAsync(long id)
        // {
        //     try
        //     {
        //         var skillInfo = await _dbcontext.skillInfos
        //             .Include(li => li.User)
        //             .Include(li => li.Skill)
        //             .FirstOrDefaultAsync(li => li.Id == id); ;

        //         return skillInfo;
        //     }
        //     catch (Exception)
        //     {
        //         throw;
        //     }
        // }
    }
}
