using System;
using System.Collections.Generic;
using System.Text;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.DomainServices
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        Customer ReadById(int id);
        List<Customer> ReadAll();
        Customer Update(Customer customerUpdate);
        void Delete(int id);
    }
}
