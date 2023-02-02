using SalesProject_Ec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject_Ec.Repos.IRepositary
{
 public   interface IWarehouse
    {
        bool? RegisterWh(UserLoginModel newRegister);
        bool? AddStock(ProductsModel newStock);
        bool AddStockInvent(ProductAvailModel productQty);
        int GetProductquantity(int ProductID);
        bool UpdateStock(ProductsModel product);
        bool DispatchOrder(int orderID);
        List<UserLoginModel> GetAllEmmployees();
        bool BlockEmployee(int id);
        bool UpdateQuantity(ProductAvailModel productQty);
    }
}
