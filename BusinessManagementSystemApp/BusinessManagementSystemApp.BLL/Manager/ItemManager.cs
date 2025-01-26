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
	public class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();

        public bool IsExistItem(ItemViewModel itemViewModel)
        {
            return _itemRepository.IsExistItem(itemViewModel);
        }
        public bool SaveItem(Item item)
        {
            return _itemRepository.SaveItem(item);
        }
        public bool UpdateItem(Item item)
        {
            return _itemRepository.UpdateItem(item);
        }
        public bool DeleteItem(Item item)
        {
            return _itemRepository.DeleteItem(item);
        }
        public List<Item> GetItems()
        {
            return _itemRepository.GetItems();
        }
        public Item ItemGetById(Item item)
        {
            return _itemRepository.ItemGetById(item);
        }    
    }
}
