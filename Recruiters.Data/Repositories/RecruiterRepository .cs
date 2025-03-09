using Microsoft.EntityFrameworkCore;
using Recruiters.Domain.Entities;
using Recruiters.Domain.Interfaces;

namespace Recruiters.Data.Repositories
{
    public class RecruiterRepository : IRecruiterRepository
    {
        private readonly ApplicationDbContext context;

        public RecruiterRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Recruiter>> GetAllRecruitersAsync()
        {
            return await context.Recruiters.ToListAsync();
        }

        public async Task<Recruiter?> GetRecruiterByIdAsync(int id)
        {
            if (id <= 0) return null;
            var recruiter = await context.Recruiters.FindAsync(id);
            return recruiter ?? null;
        }

        public async Task<Recruiter> AddRecruiterAsync(Recruiter recruiter)
        {
            context.Recruiters.Add(recruiter);
            await context.SaveChangesAsync();
            return recruiter;
        }

        public async Task<bool> UpdateRecruiterAsync(Recruiter recruiter)
        {
            context.Entry(recruiter).State = EntityState.Modified;
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRecruiterAsync(int id)
        {
            var recruiter = await context.Recruiters.FindAsync(id);
            if (recruiter == null) return false;

            context.Recruiters.Remove(recruiter);
            return await context.SaveChangesAsync() > 0;
        }
    }
}
