using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Application.Repositories;
using Octapull.Persistence.Contexts;
using F=Octapull.Domain.Entities;

namespace Octapull.Persistence.Repositories
{
	public class FileReadRepository : ReadRepository<F::File>, IFileReadRepository
	{
		public FileReadRepository(OctapullDbContext context) : base(context)
		{
		}
	}
}
