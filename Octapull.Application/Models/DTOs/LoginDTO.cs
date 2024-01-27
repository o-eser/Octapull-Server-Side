using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octapull.Application.Models.DTOs
{
	public class LoginDTO
	{
		public string UserNameorEmail { get; set; }
		public string Password { get; set; }
	}
}
