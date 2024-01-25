using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Application.Models.DTOs;
using Octapull.Application.Models.VMs;

namespace Octapull.Application.Abstraction.Services
{
	public interface IMeetingService
	{
		Task<CreateMeetingDTO> CreateMeeting(CreateMeetingDTO meeting);
		Task<UpdateMeetingDTO> UpdateMeeting(UpdateMeetingDTO meeting);
		Task DeleteMeeting(string id);
		Task<IEnumerable<MeetingVM>> GetMeetingsByOrganizerId(string userId);
		Task<IEnumerable<MeetingVM>> GetMeetingsByUserId(string userId);
	}
}
