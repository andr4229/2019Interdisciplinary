using System;
using System.Collections.Generic;
using System.Text;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.DomainServices
{
    public interface IOrderRepository
    {
        void Create(Order order);
        Order ReadById(int id);
        FilteredList<Order> ReadAll(Filter filter);
        Order Update(Order updatedOrder);
        void Delete(int id);

    }
}
