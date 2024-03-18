using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS.Application.Interfaces;
using FMS.Domain.Models.Base;
using FMS.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace FMS.Infrastructure.Repositories;

public class Repository<T>(FmsDbContext context) : IRepository<T>
    where T : BaseEntity
{
    private readonly DbSet<T> _entities = context.Set<T>();

    public List<T> GetAll()
    {
        return _entities.ToList();
    }

    public async Task<T?> Get(int id)
    {
        return await _entities.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task Insert(T entity, CancellationToken token = default, bool autoSave = true)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _entities.Add(entity);
        if (autoSave)
            await SaveChangeAsync(token);
    }

    public async Task Update(T entity, CancellationToken token = default, bool autoSave = true)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _entities.Update(entity);
        if (autoSave) await SaveChangeAsync(token);
    }

    public async Task Delete(T entity, CancellationToken token = default, bool autoSave = true)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _entities.Remove(entity);
        if (autoSave) await SaveChangeAsync(token);
    }

    #region UnitOfWork

    // don't need to add unit of work class because whenever it used it will instantiate, so it will take memory
    public Task<int> SaveChangeAsync(CancellationToken token)
    {
        return context.SaveChangesAsync(token);
    }
    public Task CommitAsync(CancellationToken token)
    {
        return context.Database.CommitTransactionAsync(token);
    }
    public Task BeginTransaction(CancellationToken token)
    {
        return context.Database.BeginTransactionAsync(token);
    }
    public Task RollBackAsync(CancellationToken token)
    {
        return context.Database.RollbackTransactionAsync(token);
    }

    #endregion
}