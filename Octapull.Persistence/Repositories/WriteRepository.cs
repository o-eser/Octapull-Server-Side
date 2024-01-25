using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Octapull.Application.Repositories;
using Octapull.Domain.Entities.Common.Abstract;
using Octapull.Persistence.Contexts;

namespace Octapull.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : class,IBaseEntity
	{
		readonly OctapullDbContext _context;

		public WriteRepository(OctapullDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public async Task<bool> AddAsync(T entity)
		{
			EntityEntry<T> entityEntry = await Table.AddAsync(entity);
			return entityEntry.State == EntityState.Added;
		}

		public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
		{
			await Table.AddRangeAsync(entities);
			return true;
		}

		public bool Remove(T entity)
		{
			EntityEntry<T> entityEntry = Table.Remove(entity);
			return entityEntry.State == EntityState.Deleted;
		}

		public bool RemoveRange(T entities)
		{
			Table.RemoveRange(entities);
			return true;
		}

		public async Task<bool> RemoveAsync(string id)
		{
			T entity = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
			return Remove(entity);
		}

		public bool Update(T entity)
		{
			EntityEntry entityEntry = Table.Update(entity);
			return entityEntry.State == EntityState.Modified;
		}

		public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
	}
}
