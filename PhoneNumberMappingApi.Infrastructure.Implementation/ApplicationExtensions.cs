using Microsoft.Extensions.DependencyInjection;
using PhoneNumberMappingApi.Infrastructure.Implementation.Services;
using PhoneNumberMappingApi.Infrastructure.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberMappingApi.Infrastructure.Implementation
{
    public static class ApplicationExtensions
    {
        public static void AddPhoneNumberMappingServices(this IServiceCollection services)
        {
            services.AddTransient<IPhoneNumberService, PhoneNumberService>();
        }
    }
}
