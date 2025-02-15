﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interdisciplinary.Core.DomainServices;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private ShopDbContext _ctx;

        public CustomerRepository(ShopDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(Customer customer)
        {
            _ctx.Customers.Attach(customer).State = EntityState.Added;
            _ctx.SaveChanges();
        }

        public Customer ReadById(int id)
        {
            return _ctx.Customers
                .Include(c => c.Address)
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderLines)
                .FirstOrDefault(c => c.Id == id);
        }

        public FilteredList<Customer> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<Customer>();
            if (filter != null && filter.ItemsPrPage > 0 && filter.CurrentPage > 0)
            {
                filteredList.List = _ctx.Customers
                    .Include(c => c.Address)
                    .ThenInclude(ca => ca.Address)
                    .Include(c => c.Orders)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
                filteredList.Count = _ctx.Customers.Count();
                return filteredList;
            }

            //return the list, so it is not filtered, if all the items should be on the page
            filteredList.List = _ctx.Customers
                .Include(c => c.Address)
                .ThenInclude(ca => ca.Address)
                .Include(c => c.Orders);
            filteredList.Count = _ctx.Customers.Count();
            return filteredList;
        }

        public Customer Update(Customer customerUpdate)
        {
            _ctx.Attach(customerUpdate).State = EntityState.Modified;
            _ctx.Entry(customerUpdate).Collection(c => c.Orders).IsModified = true;
            var orders = _ctx.Orders.Where(o => o.Customer.Id == customerUpdate.Id
                                                && !customerUpdate.Orders.Exists(co => co.Id == o.Id));
            foreach (var order in orders)
            {
                order.Customer = null;
                _ctx.Entry(order).Reference(o => o.Customer)
                    .IsModified = true;
            }
            _ctx.SaveChanges();
            return customerUpdate;
        }

        public void Delete(int id)
        {
            _ctx.Customers.Remove(new Customer {Id = id});
            _ctx.SaveChanges();
        }
    }
}
