using encuestas.Common;
using encuestas.Models;
using encuestas.Models.Request;
using encuestas.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace encuestas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService) {
            this._userService = userService;
        }
        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] AuthRequest userRequest) {
            Resp resp = new Resp();
            try {
                string pass = Encrypt.GetSHA256(userRequest.Password);
                userRequest.Password = pass;
                var user = _userService.Auth(userRequest);
                if (user == null)
                {
                    resp.message = "Usuario o contraseña incorrectos";
                    return BadRequest(resp);
                }
                resp.Status = 1;
                resp.data = user;
                return Ok(resp);
            }
            catch (Exception e) {
                resp.message = e.Message;
                return BadRequest(resp);
            }
            
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult Signup([FromBody] AuthRequest userRequest) {
            Resp resp = new Resp();
            try {
                string pass = Encrypt.GetSHA256(userRequest.Password);
                userRequest.Password = pass;
                var user = _userService.Create(userRequest);
                
                resp.Status = 1;
                resp.data = user;
                return Ok(resp);
            }
            catch (Exception e) {
                resp.message = e.Message;
                return BadRequest(resp);
            }
        }
    }
}
