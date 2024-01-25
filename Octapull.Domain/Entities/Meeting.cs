using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Domain.Entities.Common.Concrete;

namespace Octapull.Domain.Entities
{
    public class Meeting : BaseEntity
	{
		public Meeting()
		{
			UserMeetings = new HashSet<UserMeeting>();
			Documents = new HashSet<Document>();
		}
		public string MeetingName { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Description { get; set; }

		public Guid OrganizerId { get; set; }
		public User Organizer { get; set; } 

		public ICollection<UserMeeting> UserMeetings { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
