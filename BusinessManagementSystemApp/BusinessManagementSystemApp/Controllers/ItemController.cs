using BusinessManagementSystemApp.BLL.Manager;
using BusinessManagementSystemApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystemApp.Controllers
{
    public class ItemController : Controller
    {
        ItemManager _itemManager = new ItemManager();
        Item item = new Item();

        // GET: Item
        public ActionResult Index()
        {
            List<ItemViewModel> items = _itemManager.GetItems().Select(c => new ItemViewModel { Id = c.Id, Name = c.Name, Price = c.Price}).ToList();
            ItemViewModel itemViewModel = new ItemViewModel();
            itemViewModel.Items = items;            
            return View(itemViewModel);
        }
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(ItemViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {
                itemViewModel.ActionType = "Insert";
                if (_itemManager.IsExistItem(itemViewModel) == false)
                {
                    item.Name = itemViewModel.Name;
                    item.Price = itemViewModel.Price;
                    
                    if (_itemManager.SaveItem(item))
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
                    TempData["SuccessDeleteMessage"] = "This item is already exist!";
                    ViewBag.Message = "This item is already exist!";
                }
            }
            else
            {
                ViewBag.Message = "Input Validation Error!";
            }
            return View(itemViewModel);
        }

        public ActionResult Update(int id)
        {
            if (id > 0)
            {
                item.Id = id;
                var aItem = _itemManager.ItemGetById(item);
                if (aItem != null)
                {
                    ItemViewModel itemViewModel = new ItemViewModel();
                    itemViewModel.Id = aItem.Id;
                    itemViewModel.Name = aItem.Name;
                    itemViewModel.Price = aItem.Price;
                 
                    return View(itemViewModel);
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
        public ActionResult Update(ItemViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {
                itemViewModel.ActionType = "Update";
                if (_itemManager.IsExistItem(itemViewModel) == false)
                {
                    item.Id = itemViewModel.Id;
                    item = _itemManager.ItemGetById(item);
                    item.Name = itemViewModel.Name;
                    item.Price = itemViewModel.Price;
                    
                    if (_itemManager.UpdateItem(item))
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
                    ViewBag.Message = "This category is already exist!";
                }
            }
            else
            {
                ViewBag.Message = "Input Validation Failed";
            }
            return View(itemViewModel);
        }
        public ActionResult GetDetails(int id)
        {
            if (id > 0)
            {
                item.Id = id;
                var aItem = _itemManager.ItemGetById(item);
                if (aItem != null)
                {
                    ItemViewModel itemViewModel = new ItemViewModel();
                    itemViewModel.Id = aItem.Id;
                    itemViewModel.Name = aItem.Name;
                    itemViewModel.Price = aItem.Price;
                    return View(itemViewModel);
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
                item.Id = id;
                var aItem = _itemManager.ItemGetById(item);
                if (aItem != null)
                {
                    ItemViewModel itemViewModel = new ItemViewModel();
                    itemViewModel.Id = aItem.Id;
                    itemViewModel.Name = aItem.Name;
                    itemViewModel.Price = aItem.Price;
                    return View(itemViewModel);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(ItemViewModel itemViewModel)
        {
            if (itemViewModel.Id > 0)
            {
                item.Id = itemViewModel.Id;
                item.Name = itemViewModel.Name;
                item.Price = itemViewModel.Price;
               
                if (_itemManager.DeleteItem(item))
                {
                    TempData["SuccessDeleteMessage"] = "Record Delete Successfully";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}