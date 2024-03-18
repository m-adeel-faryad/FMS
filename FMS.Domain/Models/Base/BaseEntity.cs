using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Domain.Models.Base;

public class BaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? LastModifiedDateTime { get; set; }
}