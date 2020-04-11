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
using Microsoft.AspNetCore.Authorization;

namespace EpsSalud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class UserController : ControllerBase
    {

        private IUserService _ILoginService;
        
        public UserController(IConfiguration config, IUserService ILoginService)
        {
            _ILoginService = ILoginService;
            
            
        }

        [HttpGet]
        [Authorize (Roles="Admin")]    
        [Route("Get")]
        public ActionResult GetUsuarios()
        {           
            return Ok(_ILoginService.GetUsers());
        }

        [HttpGet]
        [Authorize]
        [Route("GetPerson")]
        public ActionResult GetPerson(int id)
        {
            return Ok(_ILoginService.GetPerson(id));
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Delete")]
        public ActionResult DeleteUsers([FromBody] UserListDTO user)
        {
            _ILoginService.DeleteUsers(user);
            return Ok("Ok");
        }

        [HttpPost]
        [Authorize]
        [Route("Update")]
        public ActionResult Update([FromBody] UserEditViewDTO obj )
        {
            _ILoginService.UpdateUser(obj.person,obj.user, obj.Id);
            return Ok(obj);
        }

        [HttpPost]
        [Authorize]
        [Route("Add")]
        public ActionResult Add([FromBody] UserEditViewDTO obj)
        {
            _ILoginService.AddUser(obj.person, obj.user, obj.Id);
            return Ok(obj);
        }
    }
}