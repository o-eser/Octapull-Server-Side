using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octapull.Application.Abstraction.Services.Token
{
    public interface ITokenHandler
    {
        Models.DTOs.Token CreateAccessToken(int minute, string username, string password);
    }
}
