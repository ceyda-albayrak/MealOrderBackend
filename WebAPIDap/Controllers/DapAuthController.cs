using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract.DapService;
using Entities.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic;

namespace WebAPI.Controllers.Dap
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapAuthController : Controller
    {
        private IDapAuthService _authService;

        public DapAuthController(IDapAuthService authService)
        {
            _authService = authService;
          
        }

        [HttpPost("login")]
        public ActionResult Login(UserDto user)
        {
            var userToLogin = _authService.Login(user);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var loginResult = _authService.Login(user);
            var result = _authService.CreateAccessToken(loginResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserDto user)
        {
            var userExists = _authService.UserExists(user.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(user);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}