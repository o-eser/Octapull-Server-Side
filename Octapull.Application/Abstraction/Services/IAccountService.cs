using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Application.Models.DTOs;
using T=Octapull.Application.Models.DTOs.Token;

namespace Octapull.Application.Abstraction.Services
{
	public interface IAccountService
	{
		Task<CreateUserResponse> Register(RegisterDTO register);
		Task<T> Login(LoginDTO login);
		Task Logout();
	}
}
