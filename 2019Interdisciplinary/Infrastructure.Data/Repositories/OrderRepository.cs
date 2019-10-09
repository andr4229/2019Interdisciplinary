using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interdisciplinary.Core.DomainServices;
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
                .Include(o=>o.OrderLines)
                .ThenInclude(ol=>ol.Products)
                .FirstOrDefault(o => o.Id == id);
            return order;
        }

        public IEnumerable<Order> ReadAll()
        {
            return _ctx.Orders
                .Include(o=>o.OrderLines)
                .ThenInclude(ol=>ol.Products);
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
            //Uncomment this when there are customers
            //_ctx.Entry(orderUpdate).Reference(o => o.Customer).IsModified = true;
            _ctx.SaveChanges();
            return orderUpdate;
        }

        public void Delete(int id)
        {
            _ctx.RemoveRange(ReadById(id));
        }
    }
}
