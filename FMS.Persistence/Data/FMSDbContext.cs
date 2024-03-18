using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.Domain.Models;

namespace FMS.Persistence.Data;

public  sealed class FmsDbContext(DbContextOptions<FmsDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
}