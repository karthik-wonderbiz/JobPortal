
using JobPortal.DTO.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.IServices.Company
{
    public interface IJobPostServices
    {
        public Task<GetJobPostDto> GetJobPostByIdAsync(long id);

        public Task<IEnumerable<GetJobPostDto>> GetAllJobPostsAsync();
        public Task<GetJobPostDto> CreateJobPostAsync(CreateJobPostDto jobPostDto);
        public Task<GetJobPostDto> UpdateJobPostAsync(long id, UpdateJobPostDto jobPostDto);
        public Task<bool> DeleteJobPostAsync(long id);
        public Task<IEnumerable<GetJobPostDto>> GetJobPostByCompanyId(long companyId);
    }
}
