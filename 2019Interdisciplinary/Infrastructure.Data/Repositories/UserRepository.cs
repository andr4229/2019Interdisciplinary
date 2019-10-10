using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interdisciplinary.Core.DomainServices;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository: IUserRepository
    {
        private ShopDbContext _ctx;

        public UserRepository(ShopDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(User user)
        {
            _ctx.Users.Attach(user).State = EntityState.Added;
            _ctx.SaveChanges();
        }

        public User ReadById(int id)
        {
            return _ctx.Users.Include(u => u.Customer)
                .ThenInclude(r => r.Customer)
                .ThenInclude(c => c.Address)
                .ThenInclude(ca => ca.Address)
                .FirstOrDefault(u => u.Id == id);
        }

        public FilteredList<User> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<User>();
            if (filter != null && filter.ItemsPrPage > 0 && filter.CurrentPage > 0)
            {
                filteredList.List = _ctx.Users
                    .Include(u=>u.Customer)
                    .ThenInclude(r=>r.Customer)
                    .ThenInclude(c=>c.Address)
                    .ThenInclude(ca=>ca.Address)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
                filteredList.Count = _ctx.Neonlights.Count();
                return filteredList;
            }

            //return the list, so it is not filtered, if all the items should be on the page
            filteredList.List = _ctx.Users
                .Include(u => u.Customer)
                .ThenInclude(r => r.Customer)
                .ThenInclude(c => c.Address)
                .ThenInclude(ca => ca.Address);
            filteredList.Count = _ctx.Users.Count();
            return filteredList;
        }

        public User Update(User user)
        {
            var newOrderLines = new List<Role>(user.Customer);

            _ctx.Attach(user).State = EntityState.Modified;
            //now i remove all orderlines with that orderid
            _ctx.OrderLines.RemoveRange(_ctx.OrderLines.Where(ol => ol.OrderId == user.Id));

            foreach (var orderLine in newOrderLines)
            {
                _ctx.Entry(orderLine).State = EntityState.Added;
            }
            _ctx.Entry(user).Reference(u => u.Customer).IsModified = true;
            _ctx.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            _ctx.Users.Remove(ReadById(id));
            _ctx.SaveChanges();
        }
    }
}
