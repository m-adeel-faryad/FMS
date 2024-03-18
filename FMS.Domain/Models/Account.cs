using FMS.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Domain.Models;

public class Account : BaseEntity
{
    public string AccountName { get; set; } = default!;
    public string AccountNumber { get; set; } = default!;
    public double Balance { get; set; }
    public AccountTypes AccountType { get; set; }
}