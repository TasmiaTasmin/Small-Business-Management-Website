using BusinessManagementSystemApp.BLL.Manager;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystemApp.Controllers
{
    public class OrderController : Controller
    {
        OrderManager _orderManager = new OrderManager();
        Order order = new Order();

        public ActionResult Index()
        {
            List<OrderViewModel> orders = _orderManager.GetOrders().Select(c => new OrderViewModel { Id = c.Id, CustName = c.CustName, CustContact = c.CustContact, CustAddress = c.CustAddress, ProductId = c.ProductId, ProductName = c.ProductName, ProductQuantity = c.ProductQuantity, ProductUnitPrice = c.ProductUnitPrice, TotalPrice = c.TotalPrice, Paid = c.Paid, Due = c.Due }).ToList();
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.Orders = orders;
            return View(orderViewModel);       
        }
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                orderViewModel.ActionType = "Insert";
                if (_orderManager.IsExistItem(orderViewModel) == false)
                {
                    order.CustName = orderViewModel.CustName;
                    order.CustContact = orderViewModel.CustContact;
                    order.CustAddress = orderViewModel.CustAddress;
                    order.ProductId = orderViewModel.ProductId;
                    order.ProductName = orderViewModel.ProductName;
                    order.ProductQuantity = orderViewModel.ProductQuantity;
                    order.ProductUnitPrice = orderViewModel.ProductUnitPrice;
                    order.TotalPrice = orderViewModel.TotalPrice;
                    order.Paid = orderViewModel.Paid;
                    order.Due = orderViewModel.Due;

                    if (_orderManager.SaveOrder(order))
                    {
                        TempData["SuccessMessage"] = "Data Saved SuccessFully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Operation Failed!";
                    }
                }
                else
                {
                    TempData["SuccessDeleteMessage"] = "This order is already exist!";
                    ViewBag.Message = "This order is already exist!";
                }
            }
            else
            {
                ViewBag.Message = "Input Validation Error!";
            }
            return View(orderViewModel);
        }

        public ActionResult Update(int id)
        {
            if (id > 0)
            {
                order.Id = id;
                var aOrder = _orderManager.OrderGetById(order);
                if (aOrder != null)
                {
                    OrderViewModel orderViewModel = new OrderViewModel();
                    orderViewModel.CustName = aOrder.CustName;
                    orderViewModel.CustContact = aOrder.CustContact;
                    orderViewModel.CustAddress = aOrder.CustAddress;
                    orderViewModel.ProductId = aOrder.ProductId;
                    orderViewModel.ProductName = aOrder.ProductName;
                    orderViewModel.ProductQuantity = aOrder.ProductQuantity;
                    orderViewModel.ProductUnitPrice = aOrder.ProductUnitPrice;
                    orderViewModel.TotalPrice = aOrder.TotalPrice;
                    orderViewModel.Paid = aOrder.Paid;
                    orderViewModel.Due = aOrder.Due;

                    return View(orderViewModel);
                }
                else
                {
                    ViewBag.Message = "No Data Found!";
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Update(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                orderViewModel.ActionType = "Update";
                if (_orderManager.IsExistItem(orderViewModel) == false)
                {
                    order.Id = orderViewModel.Id;
                    order = _orderManager.OrderGetById(order);
                    order.CustName = orderViewModel.CustName;
                    order.CustContact = orderViewModel.CustContact;
                    order.CustAddress = orderViewModel.CustAddress;
                    order.ProductId = orderViewModel.ProductId;
                    order.ProductName = orderViewModel.ProductName;
                    order.ProductQuantity = orderViewModel.ProductQuantity;
                    order.ProductUnitPrice = orderViewModel.ProductUnitPrice;
                    order.TotalPrice = orderViewModel.TotalPrice;
                    order.Paid = orderViewModel.Paid;
                    order.Due = orderViewModel.Due;

                    if (_orderManager.UpdateOrder(order))
                    {
                        TempData["SuccessMessage"] = "Data Update SuccessFully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Opereation Failed!";
                    }
                }
                else
                {
                    ViewBag.Message = "This order is already exist!";
                }
            }
            else
            {
                ViewBag.Message = "Input Validation Failed";
            }
            return View(orderViewModel);
        }

        public ActionResult GetDetails(int id)
        {
            if (id > 0)
            {
                order.Id = id;
                var aOrder = _orderManager.OrderGetById(order);
                if (aOrder != null)
                {
                    OrderViewModel orderViewModel = new OrderViewModel();
                    orderViewModel.CustName = aOrder.CustName;
                    orderViewModel.CustContact = aOrder.CustContact;
                    orderViewModel.CustAddress = aOrder.CustAddress;
                    orderViewModel.ProductId = aOrder.ProductId;
                    orderViewModel.ProductName = aOrder.ProductName;
                    orderViewModel.ProductQuantity = aOrder.ProductQuantity;
                    orderViewModel.ProductUnitPrice = aOrder.ProductUnitPrice;
                    orderViewModel.TotalPrice = aOrder.TotalPrice;
                    orderViewModel.Paid = aOrder.Paid;
                    orderViewModel.Due = aOrder.Due;
                    return View(orderViewModel);
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                order.Id = id;
                var aOrder = _orderManager.OrderGetById(order);
                if (aOrder != null)
                {
                    OrderViewModel orderViewModel = new OrderViewModel();
                    orderViewModel.CustName = aOrder.CustName;
                    orderViewModel.CustContact = aOrder.CustContact;
                    orderViewModel.CustAddress = aOrder.CustAddress;
                    orderViewModel.ProductId = aOrder.ProductId;
                    orderViewModel.ProductName = aOrder.ProductName;
                    orderViewModel.ProductQuantity = aOrder.ProductQuantity;
                    orderViewModel.ProductUnitPrice = aOrder.ProductUnitPrice;
                    orderViewModel.TotalPrice = aOrder.TotalPrice;
                    orderViewModel.Paid = aOrder.Paid;
                    orderViewModel.Due = aOrder.Due;
                    return View(orderViewModel);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(OrderViewModel orderViewModel)
        {
            if (orderViewModel.Id > 0)
            {
                order.CustName = orderViewModel.CustName;
                order.CustContact = orderViewModel.CustContact;
                order.CustAddress = orderViewModel.CustAddress;
                order.ProductId = orderViewModel.ProductId;
                order.ProductName = orderViewModel.ProductName;
                order.ProductQuantity = orderViewModel.ProductQuantity;
                order.ProductUnitPrice = orderViewModel.ProductUnitPrice;
                order.TotalPrice = orderViewModel.TotalPrice;
                order.Paid = orderViewModel.Paid;
                order.Due = orderViewModel.Due;

                if (_orderManager.DeleteOrder(order))
                {
                    TempData["SuccessDeleteMessage"] = "Record Delete Successfully";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

    }
}