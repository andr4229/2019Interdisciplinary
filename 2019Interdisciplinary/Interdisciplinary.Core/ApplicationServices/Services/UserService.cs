using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Interdisciplinary.Core.DomainServices;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.ApplicationServices.Services
{
    public class UserService: IUserService
    {
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public void Create(User user)
        {
            try
            {
                _userRepo.Create(user);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("User can not be created, fill all the data");
            }
        }

        public User ReadById(int id)
        {
            try
            {
                return _userRepo.ReadById(id);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("The id does not exist");
            }
        }

        public FilteredList<User> ReadAll(Filter filter)
        {
            try
            {
                return _userRepo.ReadAll(filter);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("There is no users");
            }
        }

        public User Update(User user)
        {
            try
            {
                return _userRepo.Update(user);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("The user is not there");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _userRepo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("You can not delete the user, because  the id does not exist");
            }
        }
    }
}
