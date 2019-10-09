using System;
using System.Collections.Generic;
using System.Text;
using Interdisciplinary.Core.DomainServices;
using Interdisciplinary.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using Interdisciplinary.Core.DomainServices.Filtering;

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
            return _ctx.Neonlights
                .Include(nl=>nl.Orders)
                .ThenInclude(ol => ol.Order)
                .FirstOrDefault(nl => nl.Id == id);
        }

        public FilteredList<Neonlight> ReadAll(Filter filter)
        {
            var filteredList = new FilteredList<Neonlight>();
            if (filter != null && filter.ItemsPrPage > 0 && filter.CurrentPage > 0)
            {
                filteredList.List = _ctx.Neonlights
                    .Include(nl => nl.Orders)
                    .ThenInclude(ol => ol.Order)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
                filteredList.Count = _ctx.Neonlights.Count();
                return filteredList;
            }

            //return the list, so it is not filtered, if all the items should be on the page
            filteredList.List = _ctx.Neonlights
                .Include(nl => nl.Orders)
                .ThenInclude(ol => ol.Products);
            filteredList.Count = _ctx.Neonlights.Count();
            return filteredList;
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
