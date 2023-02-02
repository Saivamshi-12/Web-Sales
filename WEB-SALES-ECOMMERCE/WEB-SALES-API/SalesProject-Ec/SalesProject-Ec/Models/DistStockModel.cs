using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesProject_Ec.Models
{
    public class DistStockModel
    {
        public int ID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> DistributerID { get; set; }
    }
}