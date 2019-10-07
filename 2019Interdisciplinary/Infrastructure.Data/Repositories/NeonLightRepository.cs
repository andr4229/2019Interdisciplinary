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
            return _ctx.Neonlights.FirstOrDefault(nl => nl.Id == id);
        }

        public IEnumerable<Neonlight> ReadAll()
        {
            return _ctx.Neonlights;
        }

        public Neonlight Update(int id, Neonlight updatedNl)
        {
            _ctx.Neonlights.Attach(ReadById(id)).State = EntityState.Modified;
            _ctx.SaveChanges();
            return ReadById(id);
        }

        public void Delete(int id)
        {
            _ctx.Neonlights.Remove(ReadById(id));
        }
    }
}
