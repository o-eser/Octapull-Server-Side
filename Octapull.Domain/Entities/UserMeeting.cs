using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Domain.Entities.Common.Concrete;

namespace Octapull.Domain.Entities
{
    public class UserMeeting : BaseEntity
	{
        public Guid UserId { get; set; }
		public Guid MeetingId { get; set; }

		public User User { get; set; }
		public Meeting Meeting { get; set; }

	}
}
