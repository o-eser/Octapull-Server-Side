using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Octapull.Domain.Entities.Common;
using Octapull.Domain.Entities.Common.Abstract;
using Octapull.Domain.Enums;

namespace Octapull.Domain.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity
	{
		public string Name { get; set; }
        public string Surname { get; set; }
		public Guid PictureId { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? LastModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public Status Status { get; set; }
        public Guid MeetingId { get; set; }

        public ICollection<UserMeeting> UserMeetings { get; set; }
		public ProfilePicture ProfilePicture { get; set; }
		public Meeting Meeting { get; set; }
	}
}
