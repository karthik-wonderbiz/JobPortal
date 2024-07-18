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
                .ToListAsync();

            return languageInfos;
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to retrieve language info by user id.", ex);
        }
    }
}
