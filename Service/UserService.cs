using encuestas.Common;
using encuestas.Models.Dal;
using encuestas.Models.Request;
using encuestas.Models.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

            UserDal dal = new UserDal();
            UserResponse user = dal.GetUsers().FirstOrDefault(u => u.Email == model.Email &&u.Password==model.Password);
            if (user == null) return null;
            user.Token = this.getToken(user);
            user.Password = "";
            return user;

        }
        public UserResponse Create(AuthRequest model)
        {

            UserDal dal = new UserDal();
            UserResponse user = dal.Insert(model);
            
            user.Password = "";
            return user;

        }

        public UserResponse ValidateToken(int id)
        {
            UserDal dal = new UserDal();
            UserResponse user = dal.GetUsers().FirstOrDefault(u=>u.Id==id);
            if (user == null) {
                return null;
            }
            user.Token=this.getToken(user);
            user.Password = "";
            return user;
        }
        private string getToken(UserResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            TokenValidationParameters tvp = new TokenValidationParameters();

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email)
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
