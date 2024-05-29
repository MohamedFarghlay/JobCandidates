using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class JobCandidateRepository(ApplicationDbContext _context) : IJobCandidateRepository
{
    public async Task AddAsync(JobCandidate candidate, CancellationToken cancellationToken = default)
    {
        await _context.JobCandidates.AddAsync(candidate, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<JobCandidate?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context.JobCandidates.FirstOrDefaultAsync(c => c.Email == email, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(JobCandidate candidate, CancellationToken cancellationToken = default)
    {
        _context.JobCandidates.Update(candidate);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
