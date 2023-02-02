using SalesProject_Ec.Models;
using SalesProject_Ec.Repos.IRepositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesProject_Ec.Repos.RepositaryClass
{
    public class Admin:IAdmin
    {
        salesProjectEntities1 dbContext = new salesProjectEntities1();
        List<OrdersModel> IAdmin.GetAllOrders()
        {
            var orders = dbContext.Orders.Select(e => new OrdersModel()
            {
                OrderPlacedDate = e.OrderPlacedDate,
                OrderID = e.OrderID,
                ProductID = e.ProductID,
                ProductName = e.ProductName,
                UnitPrice = e.UnitPrice,
                Quantity = e.Quantity,
                TotalCost = e.TotalCost,
                OrderStatus = e.OrderStatus,

            }).ToList<OrdersModel>();
            dbContext.SaveChanges();
            return orders;
        }
        bool IAdmin.verifyUser(string email, string userName)
        {
            var exists = dbContext.UserLogins.Where(e => e.EmailID == email && e.LoginID == userName);
            if(exists != null)
            {
                dbContext.Dispose();
                return true;
            }
            dbContext.Dispose();
            return false;
        }
       
        bool IAdmin.ResetPassword(string userName, string Password)
        {
            var isUser = dbContext.UserLogins.Where(e => e.LoginID == userName).FirstOrDefault();
            if(isUser != null)
            {
                isUser.Password = Password;
                dbContext.SaveChanges();
                dbContext.Dispose();
                return true;
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            return false;
        }
    }
}