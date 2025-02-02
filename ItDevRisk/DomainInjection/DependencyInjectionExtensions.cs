using Domain.OperationCategory.Repository;
using Domain.OperationCategory.Service;
using Infraestructure.Context;
using Infraestructure.Repository.OperationCategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItDevRisk.DomainInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureContext(services, configuration);
            ConfigureOperationCategory(services);
            return services;
        }

        public static void ConfigureContext(IServiceCollection services, IConfiguration configuration)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var DbPath = System.IO.Path.Join(path, "blogging.db");
            services.AddDbContext<DevRiskContext>(options => options.UseSqlite(configuration.GetConnectionString("Database")));
        }

        public static void ConfigureOperationCategory(IServiceCollection services)
        {
            services.AddScoped<IOperationCategoryService, OperationCategoryService>();
            services.AddScoped<IOperationCategoryRepository, OperationCategoryRepository>();
        }
    }
}
