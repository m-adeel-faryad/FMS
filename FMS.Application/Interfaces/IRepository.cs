using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.Domain.Models.Base;

namespace FMS.Application.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    List<T> GetAll();
    Task<T?> Get(int id);
    Task Insert(T entity,CancellationToken token = default, bool autoSave = true);
    Task Update(T entity, CancellationToken token = default, bool autoSave = true);
    Task Delete(T entity, CancellationToken token = default, bool autoSave = true);
}