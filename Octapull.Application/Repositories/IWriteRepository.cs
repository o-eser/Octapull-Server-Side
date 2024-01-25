using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Domain.Entities.Common.Abstract;

namespace Octapull.Application.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T : class, IBaseEntity
	{
		Task<bool> AddAsync(T entity);
		Task<bool> AddRangeAsync(IEnumerable<T> entities);
		bool Remove(T entity);
		bool RemoveRange(T entities);
		Task<bool> RemoveAsync(string id);
		bool Update(T entity);
		Task<int> SaveAsync();
	}
}
