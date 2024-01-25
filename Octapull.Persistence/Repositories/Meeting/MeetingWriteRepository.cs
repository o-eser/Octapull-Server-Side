using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Domain.Entities;
using Octapull.Persistence.Contexts;

namespace Octapull.Persistence.Repositories
{
	public class MeetingWriteRepository : WriteRepository<Meeting>, IMeetingWriteRepository
	{
		public MeetingWriteRepository(OctapullDbContext context) : base(context)
		{
		}
	}
}
