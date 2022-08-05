using encuestas.Models.Request;
using encuestas.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace encuestas.Service
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
        UserResponse Create(AuthRequest model);
        UserResponse ValidateToken(int id);
    }
}
