using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Domain.Entities;
using F = Octapull.Domain.Entities;

namespace Octapull.Application.Repositories
{
	public interface IFileReadRepository : IReadRepository<F::File>
	{
	}
}
