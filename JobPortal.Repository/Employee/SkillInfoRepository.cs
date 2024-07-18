using JobPortal.Data;
using JobPortal.IRepository;
using JobPortal.IRepository.Employee;
using JobPortal.Model.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobPortal.DTO.Employee.SkillInfoDto;

namespace JobPortal.Repository.Employee
{
    public class SkillInfoRepository : Repository<SkillInfo>, ISkillInfoRepository
    {
        private readonly JobPortalDbContext _dbcontext;

        public SkillInfoRepository(JobPortalDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<SkillInfo>> GetByUserId(long userId)
        {
            try
            {
                var skillInfos = await _dbcontext.skillInfos
                    .Include(li => li.User)
                    .Include(li => li.Skill)
                    .Where(li => li.UserId == userId)
                    .ToListAsync();

                return skillInfos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SkillInfo>> GetAllAsync()
        {
            try
            {
                var skillInfos = await _dbcontext.skillInfos
                    .Include(li => li.User)
                    .Include(li => li.Skill)
                    .ToListAsync();

                return skillInfos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SkillInfo> GetAsync(long id)
        {
            try
            {
                var skillInfo = await _dbcontext.skillInfos
                    .Include(li => li.User)
                    .Include(li => li.Skill)
                    .FirstOrDefaultAsync(li => li.Id == id); ;

                return skillInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
