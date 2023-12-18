using AutoMapper;
using CzlonkowieZespoluBackend.Application.Mappings;
using CzlonkowieZespoluBackend.Application.PhotoService;
using CzlonkowieZespoluBackend.Application.Queries.GetAllTeamMembers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CzlonkowieZespoluBackend.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllTeamMembersQuery));
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scoped = provider.CreateScope();
                cfg.AddProfile(new TeamMemberMappingProfile());
            }).CreateMapper());
            services.AddScoped<IPhotoService, PhotoService.PhotoService>();
        }
    }
}