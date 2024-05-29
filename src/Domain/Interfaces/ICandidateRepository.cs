﻿using Domain.Entities;

namespace Domain.Interfaces;
public interface ICandidateRepository
{
    Task<JobCandidate?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task AddAsync(JobCandidate candidate, CancellationToken cancellationToken = default);
    Task UpdateAsync(JobCandidate candidate, CancellationToken cancellationToken = default);
}
