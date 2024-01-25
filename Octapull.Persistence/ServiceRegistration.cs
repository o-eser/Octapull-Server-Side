using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Octapull.Application.Abstraction.Services;
using Octapull.Application.Repositories;
using Octapull.Domain.Entities;
using Octapull.Persistence.Contexts;
using Octapull.Persistence.Mapper;
using Octapull.Persistence.Repositories;
using Octapull.Persistence.Services;

namespace Octapull.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{

			services.AddDbContext<OctapullDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));

			services.AddIdentity<User, IdentityRole<Guid>>(opt =>
			{
				opt.SignIn.RequireConfirmedEmail = false;
				opt.SignIn.RequireConfirmedPhoneNumber = false;
				opt.SignIn.RequireConfirmedAccount = false;
				opt.User.RequireUniqueEmail = true;
				opt.Password.RequireUppercase = false;
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequiredLength = 3;
				opt.Password.RequireLowercase = false;
			}).AddEntityFrameworkStores<OctapullDbContext>()
				.AddDefaultTokenProviders();

			services.AddScoped<IDocumentReadRepository,DocumentReadRepository>();
			services.AddScoped<IDocumentWriteRepository,DocumentWriteRepository>();
			services.AddScoped<IMeetingReadRepository, MeetingReadRepository>();
			services.AddScoped<IMeetingWriteRepository, MeetingWriteRepository>();
			services.AddScoped<IUserMeetingReadRepository, UserMeetingReadRepository>();
			services.AddScoped<IUserMeetingWriteRepository, UserMeetingWriteRepository>();
			services.AddScoped<IUserReadRepository, UserReadRepository>();
			services.AddScoped<IUserWriteRepository, UserWriteRepository>();
			services.AddScoped<IFileReadRepository, FileReadRepository>();
			services.AddScoped<IFileWriteRepository, FileWriteRepository>();
			services.AddScoped<IProfilePictureReadRepository, ProfilePictureReadRepository>();
			services.AddScoped<IProfilePictureWriteRepository, ProfilePictureWriteRepository>();

			services.AddScoped<IMeetingService, MeetingService>();

			services.AddAutoMapper(typeof(Mapping));

			//var mappingConfig = new MapperConfiguration(mc =>
			//{
			//	mc.AddProfile(new Mapping()); 
			//});

			//IMapper mapper = mappingConfig.CreateMapper();
			//services.AddSingleton(mapper);
		}
	}
}
