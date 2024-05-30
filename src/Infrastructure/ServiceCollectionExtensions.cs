using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IJobCandidateRepository, JobCandidateRepository>();
        services.Decorate<IJobCandidateRepository, CachedJobCandidateRepository>();
    }
}
