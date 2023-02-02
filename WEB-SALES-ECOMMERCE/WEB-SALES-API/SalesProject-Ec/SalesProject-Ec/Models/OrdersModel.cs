using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesProject_Ec.Models
{
    public class OrdersModel
    {
        public System.DateTime OrderPlacedDate { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalCost { get; set; }
        public string OrderStatus { get; set; }
        public int DistributerID { get; set; }
    }
}