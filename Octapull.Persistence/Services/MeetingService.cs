using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Octapull.Application.Abstraction.Services;
using Octapull.Application.Models.DTOs;
using Octapull.Application.Models.VMs;
using Octapull.Application.Repositories;
using Octapull.Domain.Entities;
using Octapull.Persistence.Repositories;

namespace Octapull.Persistence.Services
{
	public class MeetingService : IMeetingService
	{
		readonly IMapper _mapper;
		readonly IMeetingReadRepository _meetingReadRepository;
		readonly IMeetingWriteRepository _meetingWriteRepository;


		public MeetingService(IMapper mapper, IMeetingReadRepository meetingReadRepository, IMeetingWriteRepository meetingWriteRepository)
		{
			_mapper = mapper;
			_meetingReadRepository = meetingReadRepository;
			_meetingWriteRepository = meetingWriteRepository;
		}

		public async Task<bool> CreateMeeting(CreateMeetingDTO meeting)
		{
			await _meetingWriteRepository.AddAsync(_mapper.Map<Meeting>(meeting));
			return await _meetingWriteRepository.SaveAsync()>0;
		}

		public async Task<bool> DeleteMeeting(string id)
		{
			await _meetingWriteRepository.RemoveAsync(id);
			return await _meetingWriteRepository.SaveAsync()>0;
		}

		public IEnumerable<MeetingVM> GetMeetingsByOrganizerId(string userId)
		{
			return _mapper.Map<IEnumerable<MeetingVM>>(_meetingReadRepository.GetWhere(x => x.Id == Guid.Parse(userId), false));
		}

		public IEnumerable<MeetingVM> GetMeetingsByUserId(string userId)
		{
			return _mapper.Map<IEnumerable<MeetingVM>>(_meetingReadRepository.GetWhere(x => x.Id == Guid.Parse(userId), false));
		}
		public IEnumerable<MeetingVM> GetAllMeetings()
		{
			return _mapper.Map<IEnumerable<MeetingVM>>(_meetingReadRepository.GetAll());
		}

		public async Task<bool> UpdateMeeting(UpdateMeetingDTO meeting)
		{
			_meetingWriteRepository.Update(_mapper.Map<Meeting>(meeting));
			return await _meetingWriteRepository.SaveAsync()>0;
		}
	}
}
