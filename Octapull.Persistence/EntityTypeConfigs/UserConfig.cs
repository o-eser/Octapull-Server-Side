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
	public class UserConfig : BaseEntityConfig<User>, IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			base.Configure(builder);

			builder.Property(u => u.Name)
				.IsRequired()
				.HasMaxLength(25);
			builder.Property(u => u.Surname)
				.IsRequired()
				.HasMaxLength(15);
			builder.Property(u => u.PhoneNumber)
				.HasMaxLength(20);

			builder.HasMany(u => u.UserMeetings).WithOne(um => um.User).HasForeignKey(um => um.UserId);
			builder.HasOne(u => u.ProfilePicture).WithOne(pp => pp.User).HasForeignKey<ProfilePicture>(pp => pp.UserId);
		}
	}
}
