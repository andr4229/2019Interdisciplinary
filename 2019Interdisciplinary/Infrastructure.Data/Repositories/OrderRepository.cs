using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interdisciplinary.Core.DomainServices;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Infrastructure.Data.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private ShopDbContext _ctx;

        public OrderRepository(ShopDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(Order order)
        {
            _ctx.Orders.Attach(order).State = EntityState.Added;
            _ctx.SaveChanges();
        }

        public Order ReadById(int id)
        {
            var order = _ctx.Orders
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Products)
                .Include(o => o.Customer)
                .ThenInclude(c=>c.Address)
                .FirstOrDefault(o => o.Id == id);
            return order;
        }

        public FilteredList<Order> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<Order>();
            if (filter != null && filter.ItemsPrPage > 0 && filter.CurrentPage > 0)
            {
                filteredList.List = _ctx.Orders
                    .Include(o=>o.OrderLines)
                    .ThenInclude(ol=>ol.Products)
                    .Include(o=>o.Customer)
                    .ThenInclude(c=>c.Address)
                    .ThenInclude(ca=>ca.Address)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
                filteredList.Count = _ctx.Customers.Count();
                return filteredList;
            }

            //return the list, so it is not filtered, if all the items should be on the page
            filteredList.List = _ctx.Orders
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Products)
                .Include(o => o.Customer)
                .ThenInclude(c => c.Address)
                .ThenInclude(ca => ca.Address);
            filteredList.Count = _ctx.Customers.Count();
            return filteredList;
        }

        public Order Update(Order orderUpdate)
        {
            var newOrderLines = new List<OrderLine>(orderUpdate.OrderLines);

            _ctx.Attach(orderUpdate).State = EntityState.Modified;
            //now i remove all orderlines with that orderid
            _ctx.OrderLines.RemoveRange(_ctx.OrderLines.Where(ol => ol.OrderId == orderUpdate.Id));

            foreach (var orderLine in newOrderLines)
            {
                _ctx.Entry(orderLine).State = EntityState.Added;
            }
            _ctx.Entry(orderUpdate).Reference(o => o.Customer).IsModified = true;
            _ctx.SaveChanges();
            return orderUpdate;
        }

        public void Delete(int id)
        {
            _ctx.RemoveRange(ReadById(id));
            _ctx.SaveChanges();
        }
    }
}
