using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystemApp.Models.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }       
        public string CustName { get; set; }
        public int CustContact { get; set; }
        public string CustAddress { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductUnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Paid { get; set; }       
        public decimal Due { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public string ActionType { get; set; }
    }
}