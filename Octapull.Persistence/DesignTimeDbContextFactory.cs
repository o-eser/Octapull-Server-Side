using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Octapull.Persistence.Contexts;

namespace Octapull.Persistence
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OctapullDbContext>
	{
		public OctapullDbContext CreateDbContext(string[] args)
		{
			DbContextOptionsBuilder<OctapullDbContext> dbContextOptionsBuilder = new();
			dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
			return new(dbContextOptionsBuilder.Options);
		}
	}
}
