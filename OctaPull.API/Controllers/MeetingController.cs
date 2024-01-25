using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OctaPull.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MeetingController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok("Hello World");
		}
	}
}
