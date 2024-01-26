using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octapull.Application.Abstraction.Services;
using Octapull.Application.Models.DTOs;

namespace OctaPull.API.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class MeetingController : ControllerBase
	{
		readonly IMeetingService _meetingService;

		public MeetingController(IMeetingService meetingService)
		{
			_meetingService = meetingService;
		}

		[HttpGet]
		[Route("GetAll")]
		public IActionResult GetAll()
		{
			return Ok(_meetingService.GetAllMeetings());
		}
		[HttpGet]
		[Route("GetByUserrId/{id}")]
		public IActionResult GetByUserId(string id)
		{
			return Ok(_meetingService.GetMeetingsByUserId(id));
		}

		[HttpGet]
		[Route("GetByOrganizerId/{id}")]
		public IActionResult GetByOrganizerId(string id)
		{
			return Ok(_meetingService.GetMeetingsByOrganizerId(id));
		}

		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create(CreateMeetingDTO meeting)
		{
			return Ok(await _meetingService.CreateMeeting(meeting));
		}

		[HttpPut]
		[Route("Update")]
		public async Task<IActionResult> Update(UpdateMeetingDTO meeting)
		{
			return Ok(await _meetingService.UpdateMeeting(meeting));
		}

		[HttpDelete]
		[Route("Delete/{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			return Ok(await _meetingService.DeleteMeeting(id));
		}
	}
}
