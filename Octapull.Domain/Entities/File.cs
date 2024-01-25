using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Domain.Entities.Common.Concrete;

namespace Octapull.Domain.Entities
{
    public class File : BaseEntity
	{
		public string FileName { get; set; }
		public string FilePath { get; set; }
		public string Storage { get; set; }
		[NotMapped]
		public override DateTime? LastModifiedDate { get => base.LastModifiedDate; set => base.LastModifiedDate = value; }
	}
}
