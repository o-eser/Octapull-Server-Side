﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octapull.Application.Models.DTOs
{
	public class Token
	{
		public string AccessToken { get; set; }
		public DateTime AccessTokenExpiration { get; set; }
	}
}
