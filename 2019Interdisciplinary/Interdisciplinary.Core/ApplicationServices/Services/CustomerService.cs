using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Interdisciplinary.Core.DomainServices;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.ApplicationServices.Services
{
    public class CustomerService: ICustomerService
    {
        private ICustomerRepository _custRepo;

        public CustomerService(ICustomerRepository custRepo)
        {
            _custRepo = custRepo;
        }
        public void Create(Customer customer)
        {
            try
            {
                _custRepo.Create(customer);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("You cannot make a this customer");
            }
        }

        public Customer ReadById(int id)
        {
            try
            {
                return _custRepo.ReadById(id);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("The id does not exist");
            }
        }

        public FilteredList<Customer> ReadAll(Filter filter)
        {
            try
            {
                return _custRepo.ReadAll(filter);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("There is no customers in your shop");
            }
        }

        public Customer Update(Customer customer)
        {
            try
            {
                return _custRepo.Update(customer);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _custRepo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("The id does not exist");
            }
        }
    }
}
