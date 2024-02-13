﻿using Booking.Notifications.Application.Repositories;
using Booking.Notifications.Domain;
using Booking.Notifications.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Booking.Notifications.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DataContext Context;

    protected BaseRepository(DataContext context)
    {
        Context = context;
    }
    
    public async Task Create(T entity)
    {
        entity.CreatedAt = DateTimeOffset.UtcNow;
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        Context.Update(entity);
    }

    public void Delete(T entity)
    {
        Context.Remove(entity);
    }

    public Task<T> Get(Guid id, CancellationToken cancellationToken)
    {
        return Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return Context.Set<T>().ToListAsync(cancellationToken);
    }
}