using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octapull.Application.Abstraction.Services;
using Octapull.Application.Models.DTOs;

namespace OctaPull.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterDTO register)
		{
			CreateUserResponse response = await _accountService.Register(register);

			return Ok(response);
		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login(LoginDTO login)
		{
			Token token = await _accountService.Login(login);
			if (token.AccessToken == null)
			{
				return Unauthorized();
			}
			return Ok(token);
		}



		//[HttpPost]
		//[Route("RefreshToken")]
		//public async Task<IActionResult> RefreshToken(RefreshTokenDTO refreshToken)
		//{
		//	
		//}

		//[HttpPost]
		//[Route("RevokeRefreshToken")]
		//public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDTO refreshToken)
		//{
		//	
		//}
	}
}
