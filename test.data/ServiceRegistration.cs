using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using test.data.Context;
using test.data.Concrete;
using test.data.Abstract;
using test.entity.Entities.Identity;

using Microsoft.AspNet.Identity.EntityFramework;
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


            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;

            })
            .AddEntityFrameworkStores<AppDbContext>();



            services.AddScoped<ITagsWriteRepository, TagsWriteRepository>();
            services.AddScoped<ITagsReadRepository, TagsReadRepository>();  
            services.AddScoped<IHistoryWriteRepository, HistoryWriteRepository>();  
            services.AddScoped<IHistoryReadRepository, HistoryReadRepository>();    
            services.AddScoped<IRequestReadRepository, RequestReadRepository>();
            services.AddScoped<IRequestWriteRepository, RequestWriteRepository>();
            services.AddScoped<ITagsCheckboxReadRepository, TagsCheckboxReadRepository>();
            services.AddScoped<ITagsCheckboxWriteRepository, TagsCheckboxWriteRepository>();
        }
    }
}
