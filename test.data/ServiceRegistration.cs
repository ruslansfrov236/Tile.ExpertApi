using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using test.data.Context;
using test.data.Concrete;
using test.data.Abstract;
namespace test.data.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void  AddDataPersistionRegistration( this IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.ConnectionString);
            });
           
            services.AddScoped<ITagsWriteRepository, TagsWriteRepository>();
            services.AddScoped<ITagsReadRepository, TagsReadRepository>();  
            services.AddScoped<IHistoryWriteRepository, HistoryWriteRepository>();  
            services.AddScoped<IHistoryReadRepository, HistoryReadRepository>();    
        }
    }
}
