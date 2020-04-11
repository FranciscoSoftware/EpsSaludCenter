
using Data.Domain;
using Service.AutoMapper.MapperEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IUserService
    {

        UserLoginDTO GetUser(UserView user);
        IEnumerable<UserListDTO> GetUsers();
        void DeleteUsers(UserListDTO user);
        UserEditDTO GetPerson(int id);
        void UpdateUser(PersonEditView person, UserEditView user, int idSpecialization);
        void AddUser(PersonEditView person, UserEditView user, int id);
    }
}
