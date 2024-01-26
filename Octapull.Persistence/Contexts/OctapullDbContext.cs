using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Octapull.Domain.Entities;
using Octapull.Domain.Entities.Common.Abstract;
using Octapull.Domain.Entities.Common.Concrete;
using Octapull.Domain.Enums;
using Octapull.Persistence.EntityTypeConfigs;
using F = Octapull.Domain.Entities;

namespace Octapull.Persistence.Contexts
{
    public class OctapullDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
	{
		public OctapullDbContext(DbContextOptions<OctapullDbContext> options) : base(options) { }
		public DbSet<F::File> Files { get; set; }
		public DbSet<Document> Documents { get; set; }
		public DbSet<ProfilePicture> ProfilePictures { get; set; }


		public DbSet<Meeting> Meetings { get; set; }
		public DbSet<UserMeeting> UserMeetings { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new MeetingConfig());
			builder.ApplyConfiguration(new UserConfig());
			builder.ApplyConfiguration(new UserMeetingConfig());
			builder.ApplyConfiguration(new FileConfig());


			base.OnModelCreating(builder);
		}


		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{

			var datas = ChangeTracker.Entries<IBaseEntity>();

			if (datas != null)
			{
				foreach (var data in datas)
				{
					switch (data.State)
					{
						case EntityState.Added:
							data.Entity.CreatedDate = DateTime.UtcNow;
							data.Entity.Status=Status.Inserted;
							break;
						case EntityState.Modified:
							data.Entity.LastModifiedDate = DateTime.UtcNow;
							data.Entity.Status=Status.Updated;
							break;
						case EntityState.Deleted:
							data.Entity.CreatedDate = DateTime.UtcNow;
							data.Entity.Status=Status.Deleted;
							break;
						default:
							break;
					}
				}
			}

			return await base.SaveChangesAsync(cancellationToken);
		}
	}
}
