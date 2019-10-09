using System;
using System.Collections.Generic;
using System.Text;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.DomainServices
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        Customer ReadById(int id);
        FilteredList<Customer> ReadAll(Filter filter);
        Customer Update(Customer customerUpdate);
        void Delete(int id);
    }
}
