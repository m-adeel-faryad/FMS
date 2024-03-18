using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FMS.Persistence;

public static class ServiceCollection
{
    public static void AddPersistence(this IServiceCollection service,string connectionString)
    {
        service.AddDbContext<FmsDbContext>(options =>
            options.UseSqlServer(connectionString));
    }
}