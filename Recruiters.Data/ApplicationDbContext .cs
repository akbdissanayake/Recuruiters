using Microsoft.EntityFrameworkCore;
using Recruiters.Domain.Entities;

namespace Recruiters.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Recruiter> Recruiters { get; set; }
    }
}
