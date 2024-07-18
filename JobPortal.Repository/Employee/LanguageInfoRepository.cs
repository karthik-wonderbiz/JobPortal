using JobPortal.Data;
using JobPortal.IRepository.Employee;
using JobPortal.Model.Employee;
using JobPortal.Repository;
using Microsoft.EntityFrameworkCore;

public class LanguageInfoRepository : Repository<LanguageInfo>, ILanguageInfoRepository
{
    private readonly JobPortalDbContext _dbContext;

    public LanguageInfoRepository(JobPortalDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

   
    public async Task<IEnumerable<LanguageInfo>> GetLanguageInfoByUserId(long userId)
    {
        try
        {
            var languageInfos = await _dbContext.languageInfos
                .Include(li => li.User)
                .Include(li => li.Language)
                .Where(li => li.UserId == userId)
                .ToListAsync();

            return languageInfos;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<LanguageInfo>> GetAllAsync()
    {
        try
        {
            var languageInfos = await _dbContext.languageInfos
                .Include(li => li.User)
                .Include(li => li.Language)
                .ToListAsync();

            return languageInfos;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<LanguageInfo> GetAsync(long id)
    {
        try
        {
            var skillInfo = await _dbContext.languageInfos
                .Include(li => li.User)
                .Include(li => li.Language)
                .FirstOrDefaultAsync(li => li.Id == id); ;

            return skillInfo;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
