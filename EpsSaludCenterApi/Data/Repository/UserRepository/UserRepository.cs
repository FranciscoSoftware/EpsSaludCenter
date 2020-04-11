using Data.Domain;
using Data.Domain.Enums;
using Data.Models;
using Data.Respository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private epsContext _context = null;
        public UserRepository()
        {
            _context = new epsContext();
        }

        public UserDomainView GetUserDomain(string username, string password)
        {
            UserDomainView userDomain;
                var query = from user in _context.Users
                            join person in _context.Persons on user.PersonId equals person.Id
                            join roles in _context.Roles on user.RoleId equals roles.Id
                            where user.UserName == username && user.UserPassword == password
                            select new
                            {
                                user.Id,
                                user.UserName,
                                person.FirstName,
                                person.MiddleName,
                                person.LastName,
                                person.ImageUrl,
                                user.RoleId,
                                roles.RoleName,
                                user.IsActive
                            };
                var obj = query.FirstOrDefault();

                userDomain = new UserDomainView()
                {
                    Id = obj.Id,
                    FirstName = obj.FirstName,
                    UserName = obj.UserName,
                    MiddleName = obj.MiddleName != null ? obj.MiddleName : "",
                    LastName = obj.LastName,
                    ImageUrl = obj.ImageUrl != null ? obj.ImageUrl : "",                    
                    RoleId = obj.RoleId,
                    RoleName = obj.RoleName,
                    IsActive = obj.IsActive
                };
            
            return userDomain;
        }

        public IEnumerable<UserDomainView> GetAllUsers()
        {
            
            var query = from user in _context.Users
                        join person in _context.Persons on user.PersonId equals person.Id
                        join roles in _context.Roles on user.RoleId equals roles.Id                        
                        select new UserDomainView
                        {
                            Id=user.Id,
                            UserName=user.UserName,
                            FirstName= person.FirstName,
                            MiddleName=person.MiddleName!=null? person.MiddleName : "",
                            LastName=person.LastName,
                            ImageUrl=person.ImageUrl,
                            RoleId=user.RoleId,
                            RoleName=roles.RoleName,
                            IsActive=user.IsActive
                        };
            
            return query.ToList();
        }

        public void DeleteUsers(UserDomainView userDeleted)
        {
            Users user = GetById(userDeleted.Id);
            user.IsActive = !user.IsActive;
            Update(user);
            Save();
        }
        

        public UserDomainView GetPerson(int id)
        {
            var query = from user in _context.Users
                        join person in _context.Persons on user.PersonId equals person.Id
                        join roles in _context.Roles on user.RoleId equals roles.Id
                        where user.Id == id
                        select new UserDomainView
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            UserPassword = user.UserPassword,
                            RoleId = user.RoleId,
                            IdPerson = person.Id,
                            FirstName = person.FirstName,
                            MiddleName = person.MiddleName,
                            LastName = person.LastName,
                            Age = person.Age,
                            HomeAddress = person.HomeAddress,
                            Phone = person.Phone,
                            ImageUrl = person.ImageUrl



                        };

            return query.FirstOrDefault();
        }

        public void UpdateUser(PersonEditDomainView personEditDomainView, UserEditDomainView userEditDomainView, int idSpecialization)
        {
            
            Users existing = GetById(userEditDomainView.Id);
            Persons existingperson = _context.Persons.Find(personEditDomainView.Id);
            if (existing.RoleId == (int)EnumRole.Doctor && existing.RoleId != userEditDomainView.RoleId)
            {
                var query = from doctors in _context.Doctors
                            where doctors.PersonId == existingperson.Id
                            select new Doctors
                            {
                                Id = doctors.Id,
                                SpecializationId = doctors.SpecializationId
                            };
                Doctors doctor = query.FirstOrDefault();
                _context.Doctors.Remove(doctor);


            }
            else if (userEditDomainView.RoleId == (int)EnumRole.Doctor)
            {
                var query = from doctors in _context.Doctors
                            where doctors.PersonId == existingperson.Id
                            select new Doctors
                            {
                                Id = doctors.Id,
                                SpecializationId = doctors.SpecializationId
                            };
                Doctors doctor = query.FirstOrDefault();
                if (doctor == null)
                {
                    doctor = new Doctors()
                    {
                        PersonId = existingperson.Id,
                        SpecializationId = idSpecialization
                    };
                    _context.Doctors.Add(doctor);
                }
                else
                {
                    doctor.SpecializationId = idSpecialization;
                    _context.Doctors.Update(doctor);

                }
            }
            existing.RoleId = userEditDomainView.RoleId!=null? userEditDomainView.RoleId: existing.RoleId; //_context.Roles.Find(userEditDomainView.RoleId);
            existing.UserName = userEditDomainView.UserName;
            existing.UserPassword = userEditDomainView.UserPassword;
            
            existingperson.FirstName = personEditDomainView.FirstName;
            existingperson.LastName = personEditDomainView.LastName;
            existingperson.MiddleName = personEditDomainView.MiddleName;
            existingperson.Phone = personEditDomainView.Phone;
            existingperson.Age = personEditDomainView.Age;
            existingperson.HomeAddress = personEditDomainView.HomeAddress;
            existingperson.ImageUrl = personEditDomainView.ImageUrl;
            Update(existing);
            _context.Persons.Update(existingperson);

            Save();


        }

        public void AddUser(PersonEditDomainView personEditDomainView, UserEditDomainView userEditDomainView, int id)
        {
            Persons newpersons = new Persons()
            {
                FirstName= personEditDomainView.FirstName,
                MiddleName = personEditDomainView.MiddleName,
                LastName = personEditDomainView.LastName,
                Age = personEditDomainView.Age,
                HomeAddress = personEditDomainView.HomeAddress,
                Phone = personEditDomainView.Phone,
                ImageUrl =personEditDomainView.ImageUrl                

            };
            newpersons = _context.Persons.Add(newpersons).Entity;
            Save();
            Users newuser = new Users()
            {
                UserName = userEditDomainView.UserName,
                UserPassword = userEditDomainView.UserPassword,
                IsActive = true,
                RoleId = userEditDomainView.RoleId,
                PersonId=newpersons.Id
            };
            Insert(newuser);
            if (userEditDomainView.RoleId == (int)EnumRole.Doctor) {
                Doctors newdoctor = new Doctors()
                {
                    PersonId = newpersons.Id,
                    SpecializationId = id
                };
                _context.Doctors.Add(newdoctor);
            }
            Save();
        }

        public void Delete(int id)
        {
            Users existing = _context.Users.Find(id);
            _context.Users.Remove(existing);
        }

        public IEnumerable<Users> GetAll()
        {
            return _context.Users.ToList();
        }

        public Users GetById(int Id)
        {
            return _context.Users.Find(Id);
        }

        public void Insert(Users obj)
        {
            this._context.Users.Add(obj);
        }

        public void Update(Users obj)
        {
            this._context.Users.Attach(obj);
            this._context.Entry(obj).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        
    }
}
