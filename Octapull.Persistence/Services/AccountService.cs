using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Octapull.Application.Abstraction.Services;
using Octapull.Application.Abstraction.Services.Token;
using Octapull.Application.Exceptions;
using Octapull.Application.Models.DTOs;
using Octapull.Domain;
using Octapull.Domain.Entities;

namespace Octapull.Persistence.Services
{
	public class AccountService : IAccountService
	{
		readonly SignInManager<User> _signInManager;
		readonly UserManager<User> _userManager;
		readonly IMapper _mapper;
		readonly ITokenHandler _tokenHandler;

		public AccountService(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper, ITokenHandler tokenHandler)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_mapper = mapper;
			_tokenHandler = tokenHandler;
		}

		public async Task<Token> Login(LoginDTO login)
		{
			User user = await _userManager.FindByNameAsync(login.UserNameorEmail);

			if (user == null)
				user = await _userManager.FindByEmailAsync(login.UserNameorEmail);

			if (user == null)
				throw new NotFoundUserException();

			SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
			if (result.Succeeded) //Authentication başarılı!
			{
				Token token = _tokenHandler.CreateAccessToken(150, user);
				return token;
			}
			throw new AuthenticationErrorException();
		}

		public async Task Logout()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<CreateUserResponse> Register(RegisterDTO register)
		{
			

			IdentityResult result= await _userManager.CreateAsync(new User
			{
				UserName = register.UserName,
				Email = register.Email,
				Name = register.Name,
				Surname = register.Surname,
				PhoneNumber=register.Phone,
			}, register.Password);

			CreateUserResponse response = new() { Succeeded = result.Succeeded };

			if (result.Succeeded)
				response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
			else
				foreach (var error in result.Errors)
					response.Message += $"{error.Code} - {error.Description}\n";

			return response;
		}

	
	}
}
