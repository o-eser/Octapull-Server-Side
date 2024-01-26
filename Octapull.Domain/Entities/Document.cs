using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octapull.Domain.Entities
{
	public class Document : File
	{
		public Guid MeetingId { get; set; }
        public Guid UserId { get; set; }

        public Meeting Meeting { get; set; }
        public User User { get; set; }
    }
}
