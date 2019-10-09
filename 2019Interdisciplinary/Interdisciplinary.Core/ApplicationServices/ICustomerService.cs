using System;
using System.Collections.Generic;
using System.Text;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.ApplicationServices
{
    public interface ICustomerService
    {
        void Create(Customer customer);
        Customer ReadById(int id);
        FilteredList<Customer> ReadAll(Filter filter);
        Customer Update(Customer customer);
        void Delete(int id);
    }
}
