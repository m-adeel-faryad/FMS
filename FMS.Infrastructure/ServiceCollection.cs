using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.Application.Interfaces;
using FMS.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FMS.Infrastructure;

public static class ServiceCollection
{
    public static void AddInfrastructure(this IServiceCollection service)
    {
        service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}