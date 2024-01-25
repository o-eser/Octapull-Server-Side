using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Octapull.Application.Abstraction.Services.Token;
using Octapull.Application.Models.DTOs;

namespace Octapull.Infrastructure.Services.TokenService
{
    public class TokenHandler : ITokenHandler
	{
		readonly IConfiguration _configuration;

		public TokenHandler(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public Token CreateAccessToken(int minute, string username, string password)
		{
			Token token = new Token();

			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:secretKey"]));

			SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			token.AccessTokenExpiration = DateTime.UtcNow.AddMinutes(minute);

			JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
					issuer: _configuration["JwtSettings:validIssuer"],
					audience: _configuration["JwtSettings:validAudience"],
					expires: token.AccessTokenExpiration,
					notBefore: DateTime.UtcNow,
					signingCredentials: credentials
				);

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

			tokenHandler.WriteToken(jwtSecurityToken);
			return token;
		}
	}
}
