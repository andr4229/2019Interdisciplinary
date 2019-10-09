using System;
using System.Collections.Generic;
using System.Text;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.ApplicationServices
{
    public interface INeonService
    {
        void Create(Neonlight nl);
        Neonlight ReadById(int id);
        FilteredList<Neonlight> ReadAll(Filter filter);
        Neonlight Update(Neonlight nlToUpdate);
        void Delete(int id);
    }
}
