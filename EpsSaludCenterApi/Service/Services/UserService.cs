using AutoMapper;
using Data.Domain;
using Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.AutoMapper.MapperEntity;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Services
{
    public class UserService:IUserService
    {
        private readonly IMapper _mapper;
        private IConfiguration _config;
        private IUserRepository _repository;
        // _repository = null;
        public UserService(IUserRepository repository, IMapper mapper, IConfiguration config)
        {
            this._repository = repository;
            _mapper = mapper;
            _config = config;
        }

        public UserLoginDTO GetUser(UserView user)
        {
            UserLoginDTO userDTO = _mapper.Map<UserDomainView, UserLoginDTO>(this._repository.GetUserDomain(user.UserName, user.UserPassword));
            userDTO.Token = GenerateJSONWebToken(userDTO.UserName, userDTO.RoleName);
            return userDTO;
        }


        public IEnumerable<UserListDTO> GetUsers()
        {
            IEnumerable<UserListDTO> usersDTO = _mapper.Map<IEnumerable<UserDomainView>, IEnumerable<UserListDTO>>(this._repository.GetAllUsers());
            
            return usersDTO;
        }

        public void DeleteUsers(UserListDTO user)
        {
           this._repository.DeleteUsers(_mapper.Map<UserListDTO,UserDomainView>(user));
        }

        public void UpdateUser(PersonEditView person, UserEditView user, int idSpecialization)
        {
            this._repository.UpdateUser(_mapper.Map<PersonEditView,PersonEditDomainView>(person),_mapper.Map<UserEditView,UserEditDomainView>(user), idSpecialization);
        }

        public void AddUser(PersonEditView person, UserEditView user, int id)
        {
            this._repository.AddUser(_mapper.Map<PersonEditView, PersonEditDomainView>(person), _mapper.Map<UserEditView, UserEditDomainView>(user), id);
        }

        public UserEditDTO GetPerson(int id)
        {
           return _mapper.Map < UserDomainView , UserEditDTO> (this._repository.GetPerson(id));
        }

        public string GenerateJSONWebToken(string username, string rolename)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,username),                
                new Claim(ClaimsIdentity.DefaultRoleClaimType, rolename),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        
    }
}
