using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octapull.Domain.Entities
{
	public class ProfilePicture : File
	{
		public Guid UserId { get; set; }
		public User User { get; set; }
	}
}
