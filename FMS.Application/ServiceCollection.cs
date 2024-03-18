using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace FMS.Application;

public static class ServiceCollection
{
    public static void AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(config =>
            config.RegisterServicesFromAssembly(typeof(ServiceCollection).Assembly));
        service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()).AddScoped<MappingProfile>();
    }
}