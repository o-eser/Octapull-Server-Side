using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Octapull.Domain.Entities.Common.Abstract;

namespace Octapull.Persistence.EntityTypeConfigs
{
	public class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : class, IBaseEntity
	{
		public virtual void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.CreatedDate).IsRequired();
			builder.Property(e => e.LastModifiedDate).IsRequired(false);
			builder.Property(e => e.DeletedDate).IsRequired(false);
		}
	}
}
