using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Service.Interfaces;

namespace EpsSalud.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class SpecializationController : ControllerBase
    {

        
        private ISpecializationServices _rolesServices;

        public SpecializationController(ISpecializationServices rolesServices)
        {
            _rolesServices= rolesServices;
        }

        [HttpGet]
        [AllowAnonymous]
        [Authorize]
        public ActionResult Get()
        {
            return Ok(_rolesServices.getSpecialization());
        }
    }
}
