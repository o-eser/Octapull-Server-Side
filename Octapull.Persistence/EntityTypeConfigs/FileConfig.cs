using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octapull.Domain.Entities;
using F=Octapull.Domain.Entities;

namespace Octapull.Persistence.EntityTypeConfigs
{
	public class FileConfig : BaseEntityConfig<F.File>,IEntityTypeConfiguration<F.File>
	{
		public override void Configure(EntityTypeBuilder<F.File> builder)
		{
			base.Configure(builder);
			builder.ToTable("Files").
				HasDiscriminator<string>("FileType").
				HasValue<ProfilePicture>(nameof(ProfilePicture)).
				HasValue<Document>(nameof(Document));
		}
	}
}
