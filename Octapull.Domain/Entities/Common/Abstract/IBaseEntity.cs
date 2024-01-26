﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Domain.Enums;

namespace Octapull.Domain.Entities.Common.Abstract
{
    public interface IBaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? LastModifiedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
        public Status Status { get; set; }
    }
}
