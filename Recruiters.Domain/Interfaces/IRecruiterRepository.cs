using Recruiters.Domain.Entities;

namespace Recruiters.Domain.Interfaces
{
    public interface IRecruiterRepository
    {
        Task<IEnumerable<Recruiter>> GetAllRecruitersAsync();
        Task<Recruiter?> GetRecruiterByIdAsync(int id); // Change return type to Task<Recruiter?>
        Task<Recruiter> AddRecruiterAsync(Recruiter recruiter);
        Task<bool> UpdateRecruiterAsync(Recruiter recruiter);
        Task<bool> DeleteRecruiterAsync(int id);
    }
}
