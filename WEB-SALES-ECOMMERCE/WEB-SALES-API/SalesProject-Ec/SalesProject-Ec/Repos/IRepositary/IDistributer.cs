using SalesProject_Ec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject_Ec.Repos.IRepositary
{
 public   interface IDistributer
    {
        bool OrderProducts(OrdersModel order);
        List<OrdersModel> GetAllOrders();
        List<DistStockModel> GetStock(int id);
    }
}
