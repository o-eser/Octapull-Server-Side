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
		Task<bool> CreateMeeting(CreateMeetingDTO meeting);
		Task<bool> UpdateMeeting(UpdateMeetingDTO meeting);
		Task<bool> DeleteMeeting(string id);
		IEnumerable<MeetingVM> GetMeetingsByOrganizerId(string userId);
		IEnumerable<MeetingVM> GetMeetingsByUserId(string userId);
		IEnumerable<MeetingVM> GetAllMeetings();
	}
}
