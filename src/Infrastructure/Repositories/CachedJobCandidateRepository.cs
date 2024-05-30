using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories;
public class CachedJobCandidateRepository : IJobCandidateRepository
{
    private readonly IJobCandidateRepository _jobCandidateRepository;
    private readonly IMemoryCache _cache;
    private readonly MemoryCacheEntryOptions _cacheOptions;

    public CachedJobCandidateRepository(IJobCandidateRepository jobCandidateRepository, IMemoryCache cache)
    {
        _jobCandidateRepository = jobCandidateRepository;
        _cache = cache;
        _cacheOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            SlidingExpiration = TimeSpan.FromMinutes(5)
        };
    }

    public async Task AddAsync(JobCandidate candidate, CancellationToken cancellationToken = default)
    {
        await _jobCandidateRepository.AddAsync(candidate, cancellationToken);
        _cache.Set(candidate.Email, candidate, _cacheOptions);
    }

    public async Task<JobCandidate?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        if (_cache.TryGetValue(email, out JobCandidate? cachedCandidate))
        {
            return cachedCandidate;
        }

        var candidate = await _jobCandidateRepository.GetByEmailAsync(email, cancellationToken);
        if (candidate != null)
        {
            _cache.Set(email, candidate, _cacheOptions);
        }

        return candidate;
    }

    public async Task UpdateAsync(JobCandidate candidate, CancellationToken cancellationToken = default)
    {
        await _jobCandidateRepository.UpdateAsync(candidate, cancellationToken);
        _cache.Set(candidate.Email, candidate, _cacheOptions);
    }
}
