using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Application.Repositories;
using Octapull.Domain.Entities;
using Octapull.Persistence.Contexts;

namespace Octapull.Persistence.Repositories
{
	public class UserReadRepository : ReadRepository<User>, IUserReadRepository
	{
		public UserReadRepository(OctapullDbContext context) : base(context)
		{
		}
	}
}
