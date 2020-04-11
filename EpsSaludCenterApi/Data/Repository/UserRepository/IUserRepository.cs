using Data.Domain;
using Data.Models;
using System.Collections.Generic;

namespace Data.Repository
{
    public interface IUserRepository
    {
        UserDomainView GetUserDomain(string username, string password);
        IEnumerable<Users> GetAll();
        Users GetById(int Id);
        void Insert(Users obj);
        void Delete(int id);
        void Update(Users obj);
        IEnumerable<UserDomainView> GetAllUsers();
        void DeleteUsers(UserDomainView userDomainView);
        UserDomainView GetPerson(int id);
        void UpdateUser(PersonEditDomainView personEditDomainView, UserEditDomainView userEditDomainView, int idSpecialization);
        void AddUser(PersonEditDomainView personEditDomainView, UserEditDomainView userEditDomainView, int id);
    }
}