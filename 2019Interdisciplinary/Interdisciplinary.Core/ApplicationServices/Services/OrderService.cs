using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Interdisciplinary.Core.DomainServices;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;

namespace Interdisciplinary.Core.ApplicationServices.Services
{
    public class OrderService: IOrderService
    {
        private IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public void Create(Order order)
        {
            try
            {
                _orderRepo.Create(order);
            }
            catch(Exception ex)
            {
                throw new InvalidDataException("Order can not be created, fill all the data");
            }
        }

        public Order ReadById(int id)
        {
            try
            {
                return _orderRepo.ReadById(id);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("The id does not exist");
            }
        }

        public FilteredList<Order> ReadAll(Filter filter)
        {
            try
            {
                return _orderRepo.ReadAll(filter);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("There is no orders");
            }
        }

        public Order Update(Order orderUpdate)
        {
            try
            {
                return _orderRepo.Update(orderUpdate);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("The order is not there");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _orderRepo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("You can not delete the order, because  the id does not exist");
            }
        }
    }
}
