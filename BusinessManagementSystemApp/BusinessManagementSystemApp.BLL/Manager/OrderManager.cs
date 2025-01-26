using BusinessManagementSystemApp.Models.Models;
using BusinessManagementSystemApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystemApp.Models;

namespace BusinessManagementSystemApp.BLL.Manager
{
    public class OrderManager        
    {
        OrderRepository _orderRepository = new OrderRepository();

        public bool IsExistItem(OrderViewModel orderViewModel)
        {
            return _orderRepository.IsExistOrder(orderViewModel);
        }
        public bool SaveOrder(Order order)
        {
            return _orderRepository.SaveOrder(order);
        }
        public bool UpdateOrder(Order order)
        {
            return _orderRepository.UpdateOrder(order);
        }
        public bool DeleteOrder(Order order)
        {
            return _orderRepository.DeleteOrder(order);
        }
        public List<Order> GetOrders()
        {
            return _orderRepository.GetOrders();
        }
        public Order OrderGetById(Order order)
        {
            return _orderRepository.OrderGetById(order);
        }
    }
}
