using System;
using System.Collections.Generic;

namespace BusinessManagementSystemApp.Models.Models
{
    public class StockVM
    {
        public StockVM()
        {
            Stocks = new List<StockVM>();
        }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int ReorderLevel { get; set; }
        public string Code { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        public List<StockVM> Stocks { get; }
    }
}
