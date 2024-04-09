using Konsom.Application.Interfaces;
using Konsom.DAL.Services.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Konsom.DAL.DIExtension
{
    public static class DIExtension
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            return services
                .AddScoped<INoteRepository, NoteRepository>()
                .AddScoped<IReminderRepository, ReminderRepository>()
                .AddScoped<ITagRepository, TagRepository>()
                
                .AddScoped<IUnitOfWork, UnitOfWork>()
                
                .AddScoped<IBaseDbContext, ApplicationDBContext>();
        }
    }
}
