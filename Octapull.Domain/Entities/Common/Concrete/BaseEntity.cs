using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Domain.Entities.Common.Abstract;

namespace Octapull.Domain.Entities.Common.Concrete
{
	public class BaseEntity : IBaseEntity
	{
		public Guid Id { get; set; }
		virtual public DateTime CreatedDate { get; set; }
		virtual public DateTime? LastModifiedDate { get; set; }
		virtual public DateTime? DeletedDate { get; set; }
		public Status Status { get; set; }
	}
}
