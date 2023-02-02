using SalesProject_Ec.Models;
using SalesProject_Ec.Repos.IRepositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesProject_Ec.Repos.RepositaryClass
{
    public class Distributer:IDistributer
    {
        salesProjectEntities1 dbcontext = new salesProjectEntities1();
        bool IDistributer.OrderProducts(OrdersModel order)
        {
            var exists = dbcontext.Orders.Where(e => e.OrderID == order.OrderID).FirstOrDefault();
            if(exists == null)
            {
                dbcontext.Orders.Add(new Order
                {
                    OrderPlacedDate = order.OrderPlacedDate,
                    OrderID = order.OrderID,
                    ProductID = order.ProductID,
                    ProductName = order.ProductName,
                    UnitPrice = order.UnitPrice,
                    Quantity = order.Quantity,
                    ShippingCost = order.ShippingCost,
                    TotalCost = order.TotalCost,
                    OrderStatus = "pending",
                    DistributerID = order.DistributerID

                });
                dbcontext.SaveChanges();
                dbcontext.Dispose();
                return true;
            }
            dbcontext.SaveChanges();
            dbcontext.Dispose();
            return false;
          
        }
        List<OrdersModel> IDistributer.GetAllOrders()
        {
            var orderList = dbcontext.Orders.Select(e => new OrdersModel()
            {
                OrderPlacedDate = e.OrderPlacedDate,
                OrderID = e.OrderID,
                ProductID = e.ProductID,
                ProductName = e.ProductName,
                UnitPrice = e.UnitPrice,
                Quantity = e.Quantity,
                ShippingCost = e.ShippingCost,
                TotalCost = e.TotalCost,
                OrderStatus = e.OrderStatus,



            }).ToList<OrdersModel>();
            dbcontext.Dispose();
            return orderList;
        }

        List<DistStockModel> IDistributer.GetStock(int id)
        {
            var stock = dbcontext.DistributorStocks.Where(e => e.DistributerID == id).Select(e => new DistStockModel()
            {
                ID = e.ID,
                ProductID = e.ProductID,
                ProductName = e.ProductName,
                UnitPrice = e.UnitPrice,
                Quantity = e.Quantity,

            }).ToList<DistStockModel>();
            return stock;
              
        }
    }
}