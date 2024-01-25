using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octapull.Application.Models.DTOs
{
	public class CreateMeetingDTO
	{
		public string MeetingName { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public string Description { get; set; }

		public Guid OrganizerId { get; set; }
	}
}
