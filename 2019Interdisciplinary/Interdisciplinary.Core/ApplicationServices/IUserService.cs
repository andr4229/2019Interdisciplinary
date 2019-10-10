using System;
using System.Collections.Generic;
using System.Text;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.ApplicationServices
{
    public interface IUserService
    {
        void Create(User user);
        User ReadById(int id);
        FilteredList<User> ReadAll(Filter filter);
        User Update(User user);
        void Delete(int id);
    }
}
