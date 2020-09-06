using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskCore.Helpers;
using TaskCore.Services;
using TaskCore.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskCore.Controllers
{
    [Authorize]
    [ApiController]
    public class LoginRegisterController : ControllerBase
    {
        private readonly JwtHelper jwt;
        private readonly IUserService userService;

        public LoginRegisterController(JwtHelper jwt, IUserService userService)
        {
            this.jwt = jwt;
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("~/signin")]
        public async Task<ActionResult<string>> SignIn(LoginViewModel login)
        {
            if (await ValidateUserAsync(login))
            {
                return jwt.GenerateToken(login.UserName);
            }
            else
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost("~/register")]
        public async Task<ActionResult<string>> Register(LoginViewModel newUser)
        {
            if (await userService.CreateUserAsync(newUser))
            {
                return jwt.GenerateToken(newUser.UserName);
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<bool> ValidateUserAsync(LoginViewModel login)
        {
            return await userService.ValidUserAsync(login);
        }

        [HttpGet("~/claims")]
        public IActionResult GetClaims()
        {
            return Ok(User.Claims.Select(p => new { p.Type, p.Value }));
        }

        [HttpGet("~/username")]
        public IActionResult GetUserName()
        {
            return Ok(User.Identity.Name);
        }

        [HttpGet("~/jwtid")]
        public IActionResult GetUniqueId()
        {
            var jti = User.Claims.FirstOrDefault(p => p.Type == "jti");
            return Ok(jti.Value);
        }
    }
}
