using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octapull.Domain.Entities;

namespace Octapull.Application.Abstraction.Services.Token
{
    public interface ITokenHandler
    {
        Models.DTOs.Token CreateAccessToken(int second, User user);
        

	}
}
