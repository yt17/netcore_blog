using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Abstract;
using Entity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IAuthService authService;
        public UserController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("login")]
        public ActionResult Login(UserForLoginDTO userForLoginDto)
        {
            var Usetolog = authService.Login(userForLoginDto);
            if (!Usetolog.Succesfull == false)
            {
                return BadRequest(Usetolog.Message);
            }

            var result = authService.CreateAccestoken(Usetolog.Data);
            if (result.Succesfull == false)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Register")]
        public ActionResult Register(UserForRegisterDTO userForRegisterDto)
        {
            var userexit = authService.userExists(userForRegisterDto.Email);
            if (userexit.Succesfull == false)
            {
                return BadRequest(userexit.Message);
            }

            var registerresult = authService.Register(userForRegisterDto);
            var result = authService.CreateAccestoken(registerresult.Data);
            if (result.Succesfull == true)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
