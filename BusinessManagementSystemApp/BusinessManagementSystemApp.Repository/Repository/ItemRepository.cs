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
    public class ItemRepository
    {
        BusinessManagementDbContext db = new BusinessManagementDbContext();
		public bool IsExistItem(ItemViewModel itemViewModel)
        {
            if (itemViewModel.ActionType == "Insert")
            {
                var aItem = db.Items.Where(c => c.Name.ToLower() == itemViewModel.Name.ToLower()).FirstOrDefault();
                if (aItem != null)
                {
                    return true;
                }
            }
            if (itemViewModel.ActionType == "Update")
            {
                var aItem = db.Items.Where(c => c.Name.ToLower() == itemViewModel.Name.ToLower()).FirstOrDefault();
                if (aItem != null)
                {
                    if (aItem.Id == itemViewModel.Id)
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
        public bool SaveItem(Item item)
        {
            db.Items.Add(item);
            return db.SaveChanges() > 0;
        }
        public bool UpdateItem(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool DeleteItem(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public List<Item> GetItems()
        {
            return db.Items.ToList();
        }
        public Item ItemGetById(Item item)
        {
            var aItem = db.Items.FirstOrDefault(c => c.Id == item.Id);
            return aItem;
        }
    }
}
