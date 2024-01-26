using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Octapull.Application.Abstraction.Services.Token;
using Octapull.Application.Models.DTOs;
using Octapull.Domain.Entities;

namespace Octapull.Infrastructure.Services.TokenService
{
    public class TokenHandler : ITokenHandler
	{
		readonly IConfiguration _configuration;

		public TokenHandler(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public Token CreateAccessToken(int second, User user)
		{
			var authClaims = new List<Claim>
				{
					new Claim(ClaimTypes.Email, user.Email),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
					new Claim(ClaimTypes.Name, user.Name),
					new Claim(ClaimTypes.Surname, user.Surname),
                };


			//var userRoles = await _personnelService.GetRoles(model.Email);

			//if (userRoles.Length == 0)
			//	return Unauthorized("Kullanıcının Rolü mevcut değil");

			//foreach (var userRole in userRoles)
			//{
			//	authClaims.Add(new Claim(ClaimTypes.Role, userRole));
			//}

			var token = GetToken(authClaims);


			return new Token { 
			AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
			AccessTokenExpiration=token.ValidTo,
			};
		}

		private JwtSecurityToken GetToken(List<Claim> authClaims)
		{
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:secretKey"]));
			var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				_configuration["JwtSettings:validIssuer"],
				_configuration["JwtSettings:validAudience"],
				authClaims,
				expires: DateTime.Now.AddMinutes(15),
				signingCredentials: signIn);

			return token;
		}
	}
}
