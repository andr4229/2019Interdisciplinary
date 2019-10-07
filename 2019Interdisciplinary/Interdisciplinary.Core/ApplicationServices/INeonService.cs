using System;
using System.Collections.Generic;
using System.Text;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.ApplicationServices
{
    public interface INeonService
    {
        void Create(Neonlight nl);
        Neonlight ReadById(int id);
        List<Neonlight> ReadAll();
        Neonlight Update(int id);
        void Delete(int id);
    }
}
