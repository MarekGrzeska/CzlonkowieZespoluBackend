using CzlonkowieZespoluBackend.Domain.Interfaces;
using CzlonkowieZespoluBackend.Infrastucture.DbProvider;
using CzlonkowieZespoluBackend.Infrastucture.Repositories;
using CzlonkowieZespoluBackend.Infrastucture.Seeder;
using CzlonkowieZespoluBackend.Infrastucture.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CzlonkowieZespoluBackend.Infrastucture.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrasctructure(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("PostrgreDb");
            services.AddDbContext<TeamMemberDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IRandomUserService, RandomUserService>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<InitialSeeder>();
        }
    }
}
