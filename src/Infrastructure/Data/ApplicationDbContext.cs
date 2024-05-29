using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<JobCandidate> JobCandidates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobCandidate>()
            .HasIndex(c => c.Email)
            .IsUnique();

        modelBuilder.Entity<JobCandidate>()
            .OwnsOne(e => e.CallTimeInterval);
    }
}
