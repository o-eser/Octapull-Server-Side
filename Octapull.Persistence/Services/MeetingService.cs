using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Application.Abstraction.Services;
using Octapull.Application.Models.DTOs;
using Octapull.Application.Models.VMs;

namespace Octapull.Persistence.Services
{
	public class MeetingService : IMeetingService
	{
		public Task<CreateMeetingDTO> CreateMeeting(CreateMeetingDTO meeting)
		{
			throw new NotImplementedException();
		}

		public Task DeleteMeeting(string id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<MeetingVM>> GetMeetingsByOrganizerId(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<MeetingVM>> GetMeetingsByUserId(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<UpdateMeetingDTO> UpdateMeeting(UpdateMeetingDTO meeting)
		{
			throw new NotImplementedException();
		}
	}
}
