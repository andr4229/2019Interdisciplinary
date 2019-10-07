using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.ApplicationServices
{
    public interface IOrderService
    {
        void Create(Order order);
        Order ReadById(int id);
        List<Order> ReadAll();
        Order Update(Order orderUpdate);
        void Delete(int id);
    }
}
