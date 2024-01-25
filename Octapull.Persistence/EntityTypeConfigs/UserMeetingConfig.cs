using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octapull.Domain.Entities;

namespace Octapull.Persistence.EntityTypeConfigs
{
	public class UserMeetingConfig : BaseEntityConfig<UserMeeting>, IEntityTypeConfiguration<UserMeeting>
	{
		public void Configure(EntityTypeBuilder<UserMeeting> builder)
		{
			base.Configure(builder);

		}
	}
}
