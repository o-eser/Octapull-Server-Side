using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Octapull.Application.Models.DTOs;
using Octapull.Application.Models.VMs;
using Octapull.Domain.Entities;

namespace Octapull.Persistence.Mapper
{
	public class Mapping : Profile
	{
		public Mapping()
		{
			CreateMap<Meeting,MeetingVM>().ReverseMap();
			CreateMap<Meeting,CreateMeetingDTO>().ReverseMap();
			CreateMap<Meeting,UpdateMeetingDTO>().ReverseMap();
		}
	}
}
