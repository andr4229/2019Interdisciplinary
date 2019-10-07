using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.DomainServices
{
    public interface INeonLightRepository
    {
        void Create();
        Neonlight ReadById(int id);
        IEnumerable<Neonlight> ReadAll();
        Neonlight Update(int id);
        void Delete(int id);
    }
}
