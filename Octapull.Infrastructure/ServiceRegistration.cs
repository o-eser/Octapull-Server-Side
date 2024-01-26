using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Octapull.Application.Abstraction.Services;
using Octapull.Application.Abstraction.Services.Token;
using Octapull.Application.Repositories;
using Octapull.Domain.Entities;
using Octapull.Infrastructure.Services.TokenService;

namespace Octapull.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureServices(this IServiceCollection services)
		{
			services.AddScoped<ITokenHandler,TokenHandler>();
		}
	}
}
