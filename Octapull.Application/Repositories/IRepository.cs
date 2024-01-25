using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Octapull.Domain.Entities.Common.Abstract;

namespace Octapull.Application.Repositories
{
	public interface IRepository <T> where T : class, IBaseEntity
	{
		DbSet<T> Table { get; }
	}
}
