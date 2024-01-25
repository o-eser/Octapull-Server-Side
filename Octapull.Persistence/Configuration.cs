using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Octapull.Persistence
{
	internal static class Configuration
	{
		static internal string ConnectionString
		{
			get
			{
				ConfigurationManager configurationManager = new ConfigurationManager();
				configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../OctaPull.API"));
				configurationManager.AddJsonFile("appsettings.json");

				return configurationManager.GetConnectionString("MsSQL");
			}
		}
	}
}
