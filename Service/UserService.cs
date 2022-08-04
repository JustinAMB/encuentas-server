using encuestas.Common;
using encuestas.Models.Request;
using encuestas.Models.Response;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace encuestas.Service
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public UserResponse Auth(AuthRequest model)
        {
            throw new NotImplementedException();
        }

        public UserResponse ValidateToken(int id)
        {
            throw new NotImplementedException();
        }
    }
}
