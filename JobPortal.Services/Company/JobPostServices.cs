using JobPortal.Data;
using JobPortal.DTO.Company;
using JobPortal.IRepository;
using JobPortal.IRepository.Company;
using JobPortal.IServices.Company;
using JobPortal.Model;
using JobPortal.Model.Company;
using JobPortal.Model.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Services.Company
{
    public class JobPostServices : IJobPostServices
    {
        private readonly IJobPostRepository _jobPostRepository;

        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly IRecruiterRepository _recruiterRepository;
        private readonly IDesignationRepository _designationRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ITrainLineRepository _trainLineRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly IShiftRepository _shiftRepository;
        private readonly IWorkTypeRepository _workTypeRepository;
        private readonly IEmploymentTypeRepository _employmentTypeRepository;
        private readonly IQualificationRepository _qualificationRepository;

        public JobPostServices(IJobPostRepository jobPostRepository,
                                ICompanyInfoRepository companyInfoRepository,
                                IRecruiterRepository recruiterRepository,
                                IDesignationRepository designationRepository,
                                ISkillRepository skillRepository,
                                ITrainLineRepository trainLineRepository,
                                ILanguageRepository languageRepository,
                                IShiftRepository shiftRepository,
                                IWorkTypeRepository workTypeRepository,
                                IEmploymentTypeRepository employmentTypeRepository,
                                IQualificationRepository qualificationRepository)
        {
            _jobPostRepository = jobPostRepository;
            _companyInfoRepository = companyInfoRepository;
            _recruiterRepository = recruiterRepository;
            _designationRepository = designationRepository;
            _skillRepository = skillRepository;
            _trainLineRepository = trainLineRepository;
            _languageRepository = languageRepository;
            _shiftRepository = shiftRepository;
            _workTypeRepository = workTypeRepository;
            _employmentTypeRepository = employmentTypeRepository;
            _qualificationRepository = qualificationRepository;
        }

        public async Task<GetJobPostDto> CreateJobPostAsync(CreateJobPostDto jobPostDto)
        {
            try
            {
                var jobPost = await _jobPostRepository.CreateAsync(new JobPost()
                {
                    CompanyId = jobPostDto.CompanyId,
                    RecruiterId = jobPostDto.RecruiterId,
                    DesignationId = jobPostDto.DesignationId,
                    SkillId = jobPostDto.SkillId,
                    TrainLineId = jobPostDto.TrainLineId,
                    LanguageId = jobPostDto.LanguageId,
                    ShiftId = jobPostDto.ShiftId,
                    WorkTypeId = jobPostDto.WorkTypeId,
                    EmploymentTypeId = jobPostDto.EmploymentTypeId,
                    QualificationId = jobPostDto.QualificationId,
                    Bond = jobPostDto.Bond,
                    JobDescription = jobPostDto.JobDescription,
                    MinExperience = jobPostDto.MinExperience,
                    MaxExperience = jobPostDto.MaxExperience,
                    MinSalary = jobPostDto.MinSalary,
                    MaxSalary = jobPostDto.MaxSalary,
                    NoticePeriod = jobPostDto.NoticePeriod,
                    Vacancy = jobPostDto.Vacancy,
                    ApplicationStartDate = DateTime.Now,
                    ApplicationEndDate = jobPostDto.ApplicationEndDate, 
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
                var companyInfo = await _companyInfoRepository.GetAsync(jobPost.CompanyId);
                var recruiterInfo = await _recruiterRepository.GetAsync(jobPost.RecruiterId);
                var designationInfo = await _designationRepository.GetAsync(jobPost.DesignationId);
                var skillInfo = await _skillRepository.GetAsync(jobPost.SkillId);
                var trainLineInfo = await _trainLineRepository.GetAsync(jobPost.TrainLineId);
                var languageInfo = await _languageRepository.GetAsync(jobPost.LanguageId);
                var shiftInfo = await _shiftRepository.GetAsync(jobPost.ShiftId);
                var workTypeinfo = await _workTypeRepository.GetAsync(jobPost.WorkTypeId); 
                var employmentTypeInfo = await _employmentTypeRepository.GetAsync(jobPost.EmploymentTypeId);
                var qualificationInfo = await _qualificationRepository.GetAsync(jobPost.QualificationId);


                if (companyInfo != null || recruiterInfo != null || designationInfo != null || skillInfo != null || trainLineInfo != null ||
                    languageInfo != null || shiftInfo != null || workTypeinfo != null || employmentTypeInfo != null || qualificationInfo != null)
                {
                    var jobPostData = new GetJobPostDto(
                        jobPost.Id,
                        companyInfo.CompanyName,
                        companyInfo.CompanyLogo,
                        recruiterInfo.RecruiterName,
                        recruiterInfo.RecruiterPhone,
                        recruiterInfo.RecruiterEmail,
                        designationInfo.DesignationName,
                        skillInfo.SkillName,
                        trainLineInfo.TrainLineName,
                        languageInfo.LanguageName,
                        shiftInfo.ShiftName,
                        workTypeinfo.WorkTypeName,
                        employmentTypeInfo.EmploymentTypeName,
                        qualificationInfo.QualificationName,
                        jobPost.Bond,
                        jobPost.JobDescription,
                        jobPost.MinExperience,
                        jobPost.MaxExperience,
                        jobPost.MinSalary,
                        jobPost.MaxSalary,
                        jobPost.NoticePeriod,
                        jobPost.Vacancy,
                        jobPost.ApplicationStartDate,
                        jobPost.ApplicationEndDate,
                        jobPost.IsActive
                        );
                    return jobPostData;
                }
                else
                {
                    throw new Exception("Invalid User");
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteJobPostAsync(long id)
        {
            try
            {
                var jobPost = await _jobPostRepository.GetAsync(id);

                if (jobPost == null)
                {
                    throw new Exception($"Job Post not found for id : {id}");
                }
                var deletedJobPostData = await _jobPostRepository.DeleteAsync(jobPost);
                return deletedJobPostData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<GetJobPostDto>> GetAllJobPostsAsync()
        {
            try
            {
                var jobPosts = await _jobPostRepository.GetAllAsync();
                var jobPostDto = jobPosts.Select(jobPost => new GetJobPostDto(
                    jobPost.Id,
                    jobPost.CompanyInfo.CompanyName,
                    jobPost.CompanyInfo.CompanyLogo,
                    jobPost.Recruiter.RecruiterName,
                    jobPost.Recruiter.RecruiterPhone,
                    jobPost.Recruiter.RecruiterEmail,
                    jobPost.Designation.DesignationName,
                    jobPost.Skill.SkillName,
                    jobPost.TrainLine.TrainLineName,
                    jobPost.Language.LanguageName,
                    jobPost.Shift.ShiftName,
                    jobPost.WorkType.WorkTypeName,
                    jobPost.EmploymentType.EmploymentTypeName,
                    jobPost.Qualification.QualificationName,
                    jobPost.Bond,
                    jobPost.JobDescription,
                    jobPost.MinExperience,
                    jobPost.MaxExperience,
                    jobPost.MinSalary,
                    jobPost.MaxSalary,
                    jobPost.NoticePeriod,
                    jobPost.Vacancy,
                    jobPost.ApplicationStartDate,
                    jobPost.ApplicationEndDate,
                    jobPost.IsActive
                    ));
                return jobPostDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetJobPostDto> GetJobPostByIdAsync(long id)
        {
            try
            {
                var jobPost = await _jobPostRepository.GetAsync(id);

                if (jobPost == null)
                {
                    throw new Exception($"Job Post not found for id : {id}");
                }

                var jobPostData = new GetJobPostDto(
                    jobPost.Id,
                    jobPost.CompanyInfo.CompanyName,
                    jobPost.CompanyInfo.CompanyLogo,
                    jobPost.Recruiter.RecruiterName,
                    jobPost.Recruiter.RecruiterPhone,
                    jobPost.Recruiter.RecruiterEmail,
                    jobPost.Designation.DesignationName,
                    jobPost.Skill.SkillName,
                    jobPost.TrainLine.TrainLineName,
                    jobPost.Language.LanguageName,
                    jobPost.Shift.ShiftName,
                    jobPost.WorkType.WorkTypeName,
                    jobPost.EmploymentType.EmploymentTypeName,
                    jobPost.Qualification.QualificationName,
                    jobPost.Bond,
                    jobPost.JobDescription,
                    jobPost.MinExperience,
                    jobPost.MaxExperience,
                    jobPost.MinSalary,
                    jobPost.MaxSalary,
                    jobPost.NoticePeriod,
                    jobPost.Vacancy,
                    jobPost.ApplicationStartDate,
                    jobPost.ApplicationEndDate,
                    jobPost.IsActive
                    );
                return jobPostData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<GetJobPostDto> UpdateJobPostAsync(long id, UpdateJobPostDto JobPostDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetJobPostDto>> GetJobPostByCompanyId(long companyId)
        {
            throw new NotImplementedException();
        }
    }

}
