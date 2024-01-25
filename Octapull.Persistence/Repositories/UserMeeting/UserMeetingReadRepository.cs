﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Application.Repositories;
using Octapull.Domain.Entities;
using Octapull.Persistence.Contexts;

namespace Octapull.Persistence.Repositories
{
	public class UserMeetingReadRepository : ReadRepository<UserMeeting>, IUserMeetingReadRepository
	{
		public UserMeetingReadRepository(OctapullDbContext context) : base(context)
		{
		}
	}
}
