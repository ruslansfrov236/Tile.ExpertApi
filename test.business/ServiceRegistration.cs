using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.business.Abstract;
using test.business.Concrete;

namespace test.business.ServiceRegistration
{
    public static class ServiceRegistration
    {

        public static void AddBussinessPersistionRegistration(this IServiceCollection services)
        {
            services.AddTransient<ITagsCheckboxService, TagsCheckboxService>();
            services.AddTransient<ITagsService, TagsService>();
            services.AddTransient<IHistoryService, HistoryService>();
            services.AddTransient<IRequestService, RequestService>();       
         
        }
    }
}
