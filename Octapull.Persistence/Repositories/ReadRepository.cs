using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Octapull.Application.Repositories;
using Octapull.Domain.Entities.Common.Abstract;
using Octapull.Persistence.Contexts;

namespace Octapull.Persistence.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : class,IBaseEntity
	{
		private readonly OctapullDbContext _context;

		public ReadRepository(OctapullDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public IQueryable<T> GetAll(bool tracking = true)
		{
			var query = Table.AsQueryable();
			if (!tracking) query = query.AsNoTracking();
			return query;
		}

		public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
		{
			var query = Table.Where(expression);
			if (!tracking) query = query.AsNoTracking();
			return query;
		}

		public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
		{
			var query = Table.AsQueryable();
			if (!tracking) query = query.AsNoTracking();
			return await query.FirstOrDefaultAsync(expression);
		}

		public async Task<T> GetByIdAsync(string id, bool tracking = true) /*=> await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));*/
		//=> await GetSingleAsync(x => x.Id == Guid.Parse(id));
		{
			var query = Table.AsQueryable();
			if (!tracking) query = query.AsNoTracking();
			return await query.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
		}

	}
}
