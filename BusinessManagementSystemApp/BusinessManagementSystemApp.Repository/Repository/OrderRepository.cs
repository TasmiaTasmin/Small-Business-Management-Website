using BusinessManagementSystemApp.DatabaseContext.DatabaseContext;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Repository.Repository
{
    public class OrderRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
        public bool IsExistOrder(OrderViewModel orderViewModel)
        {
            if (orderViewModel.ActionType == "Insert")
            {
                var aOrder = db.Orders.Where(c => c.CustName.ToLower() == orderViewModel.CustName.ToLower()).FirstOrDefault();
                if (aOrder != null)
                {
                    return true;
                }
            }
            if (orderViewModel.ActionType == "Update")
            {
                var aOrder = db.Orders.Where(c => c.CustName.ToLower() == orderViewModel.CustName.ToLower()).FirstOrDefault();
                if (aOrder != null)
                {
                    if (aOrder.Id == orderViewModel.Id)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool SaveOrder(Order order)
        {
            db.Orders.Add(order);
            return db.SaveChanges() > 0;
        }
        public bool UpdateOrder(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool DeleteOrder(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public List<Order> GetOrders()
        {
            return db.Orders.ToList();
        }
        public Order OrderGetById(Order order)
        {
            var aOrder = db.Orders.FirstOrDefault(c => c.Id == order.Id);
            return aOrder;
        }
    }
}