using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.AutoMapper.MapperEntity;
using Service.Interfaces;

namespace EpsSalud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        
        private IUserService _ILoginService;

        public AuthentificationController(IConfiguration config, IUserService ILoginService)
        {
            _ILoginService = ILoginService;
            
            
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AuthenticateUser([FromBody] UserView user)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            return Ok(_ILoginService.GetUser(user));
        }

    }
}