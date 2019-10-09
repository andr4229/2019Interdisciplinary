using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.DomainServices
{
    public interface INeonLightRepository
    {
        void Create(Neonlight nl);
        Neonlight ReadById(int id);
        FilteredList<Neonlight> ReadAll(Filter filter);
        Neonlight Update(Neonlight updatedNl);
        void Delete(int id);
    }
}
