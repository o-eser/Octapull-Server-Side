using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Domain;

namespace Octapull.Application.Models.DTOs
{
	public class RegisterDTO
	{
		public string Name { get; set; }
		public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }

	}
}
