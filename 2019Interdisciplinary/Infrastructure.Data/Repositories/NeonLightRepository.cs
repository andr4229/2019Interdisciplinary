using System;
using System.Collections.Generic;
using System.Text;
using Interdisciplinary.Core.DomainServices;
using Interdisciplinary.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class NeonLightRepository: INeonLightRepository
    {
        private ShopDbContext _ctx;
        public NeonLightRepository(ShopDbContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(Neonlight nl)
        {
            _ctx.Neonlights.Attach(nl).State = EntityState.Added;
            _ctx.SaveChanges();
        }

        public Neonlight ReadById(int id)
        {
            return _ctx.Neonlights.Include(nl=>nl.Orders)
                .ThenInclude(ol=>ol.Order)
                .FirstOrDefault(nl => nl.Id == id);
        }

        public IEnumerable<Neonlight> ReadAll()
        {
            return _ctx.Neonlights.Include(nl=>nl.Orders)
                .ThenInclude(ol=>ol.Order);
        }

        public Neonlight Update(Neonlight updatedNl)
        {
            var newOrderLines = new List<OrderLine>(updatedNl.Orders);

            _ctx.Attach(updatedNl).State = EntityState.Modified;

            _ctx.RemoveRange(_ctx.OrderLines.Where(ol => ol.NeonlightId == updatedNl.Id));

            foreach (var orderLine in newOrderLines)
            {
                _ctx.Entry(orderLine).State = EntityState.Added;
            }
            ////Uncomment this when there are customers
            //_ctx.Entry(updatedNl).Reference(o => o.Customer).IsModified = true;
            _ctx.SaveChanges();
            return updatedNl;
            
        }

        public void Delete(int id)
        {
            _ctx.Neonlights.Remove(ReadById(id));
            _ctx.SaveChanges();
        }
    }
}
