using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octapull.Application.Models.VMs
{
	public class MeetingVM
	{
		public MeetingVM()
		{
			Users = new HashSet<UserVM>();
			Documents = new HashSet<DocumentVM>();
		}
		public string MeetingName { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Description { get; set; }

		public Guid OrganizerId { get; set; }
		public UserVM Organizer { get; set; } 

		public ICollection<UserVM> Users { get; set; }
		public ICollection<DocumentVM> Documents { get; set; }
	}
}
