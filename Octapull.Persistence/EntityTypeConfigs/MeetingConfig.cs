using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Octapull.Domain.Entities;

namespace Octapull.Persistence.EntityTypeConfigs
{
	public class MeetingConfig : BaseEntityConfig<Meeting>, IEntityTypeConfiguration<Meeting>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Meeting> builder)
		{
			base.Configure(builder);

			builder.Property(m => m.MeetingName)
				.IsRequired()
				.HasMaxLength(100);
			builder.Property(m => m.StartTime)
				.IsRequired();
			builder.Property(m => m.EndTime).IsRequired();
			builder.Property(m => m.Description)
				.HasMaxLength(500);
			builder.Property(m => m.OrganizerId).IsRequired();

			builder.HasOne(m => m.Organizer).WithOne(u => u.Meeting).HasForeignKey<Meeting>(m => m.OrganizerId);
			builder.HasMany(m => m.UserMeetings).WithOne(um => um.Meeting).HasForeignKey(um => um.MeetingId).OnDelete(DeleteBehavior.NoAction);
			builder.HasMany(m => m.Documents).WithOne(d => d.Meeting).HasForeignKey(d => d.MeetingId).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
