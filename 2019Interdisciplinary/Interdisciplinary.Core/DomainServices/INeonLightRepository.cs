using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.DomainServices
{
    public interface INeonLightRepository
    {
        void Create(Neonlight nl);
        Neonlight ReadById(int id);
        IEnumerable<Neonlight> ReadAll();
        Neonlight Update(Neonlight updatedNl);
        void Delete(int id);
    }
}
