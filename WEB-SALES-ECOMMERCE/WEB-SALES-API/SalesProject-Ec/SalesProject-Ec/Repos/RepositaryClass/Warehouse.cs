using SalesProject_Ec.Models;
using SalesProject_Ec.Repos.IRepositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesProject_Ec.Repos.RepositaryClass
{
    public class Warehouse:IWarehouse
    {
        salesProjectEntities1 dbContext = new salesProjectEntities1();

        bool? IWarehouse.RegisterWh(UserLoginModel newRegister)
        {
            var userexists = dbContext.UserLogins.Where(e => e.ID == newRegister.ID).FirstOrDefault();
            if(userexists == null)
            {
                dbContext.UserLogins.Add(new SalesProject_Ec.UserLogin
                {
                    DateInserted = newRegister.DateInserted,
                    ID = newRegister.ID,
                    UserTypeID = newRegister.UserTypeID,
                    MemberID = newRegister.MemberID,
                    FirstName = newRegister.FirstName,
                    LastName = newRegister.LastName,
                    LoginID = newRegister.LoginID,
                    EmailID = newRegister.EmailID,
                    Password = newRegister.Password,
                    FirmName = newRegister.FirmName,
                    PhoneNumber = newRegister.FirmName,
                    SecurityAnswer = newRegister.SecurityAnswer
                });
                dbContext.SaveChanges();
                dbContext.Dispose();
                return true;
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            return false;
        }

        bool? IWarehouse.AddStock(ProductsModel newStock)
        {
            if(newStock != null)
            {
                dbContext.Products.Add(new Product
                {
                    ID = newStock.ID,
                    DateInserted = newStock.DateInserted,
                    MARKETID = newStock.MARKETID,
                    Description = newStock.Description,
                    ExpirationDate = newStock.ExpirationDate,
                    ImageURL = newStock.ImageURL,
                    Name = newStock.Name,
                    Weight = newStock.Weight,
                    TaxPrice = newStock.TaxPrice,
                    ProductID = newStock.ProductID,
                    ProductCategoryID = newStock.ProductCategoryID,
                    UnitPrice = newStock.UnitPrice,
                    MinimumOrderDty = newStock.MinimumOrderDty
                });
                dbContext.SaveChanges();
                dbContext.Dispose();
                return true;

            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            return false;
        }

        bool IWarehouse.AddStockInvent(ProductAvailModel productQty)
        {
            if(productQty != null)
            {
                dbContext.ProductAvailabilities.Add(new ProductAvailability
                {
                    ProductID = productQty.ProductID,
                    InventoryQuantity = productQty.InventoryQuantity
                });
                dbContext.SaveChanges();
                dbContext.Dispose();
                return true;
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            return false;
        }

        int IWarehouse.GetProductquantity(int ProductID)
        {
            var productQty = dbContext.ProductAvailabilities.Where(e => e.ProductID == ProductID).FirstOrDefault();
            if(productQty != null)
            {
                return (int)productQty.InventoryQuantity;
            }
            return 0;
        }

        bool IWarehouse.UpdateStock(ProductsModel product)
        {
            var ProductExists = dbContext.Products.Where(e => e.ProductID == product.ProductID).FirstOrDefault();
            if(ProductExists != null)
            {
                ProductExists.ImageURL = product.ImageURL;
                ProductExists.UnitPrice = product.UnitPrice;
                var productInQty = dbContext.ProductAvailabilities.Where(e => e.ProductID == product.ProductID).FirstOrDefault();
                dbContext.SaveChanges();
                dbContext.Dispose();
                return true;

            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            return true;
        }
        bool IWarehouse.DispatchOrder(int orderID)
        {
            var isOrder = dbContext.Orders.Where(e => e.OrderID == orderID).FirstOrDefault();
            if(isOrder != null)
            {
                isOrder.OrderStatus = "Dispatched";
                dbContext.SaveChanges();
                dbContext.Dispose();
                return true;
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            return true;
        }

        bool IWarehouse.UpdateQuantity(ProductAvailModel productQty)
        {
            var exists = dbContext.ProductAvailabilities.Where(e => e.ProductID == productQty.ProductID).FirstOrDefault();
            if (exists != null)
            {
                exists.InventoryQuantity = productQty.InventoryQuantity;
                dbContext.SaveChanges();
                dbContext.Dispose();
                return true;
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            return false;
        }
        List<UserLoginModel> IWarehouse.GetAllEmmployees()
        {
            var emps = dbContext.UserLogins.Select(emp => new UserLoginModel()
            {
                ID = emp.ID,
                UserTypeID = emp.UserTypeID,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                EmailID = emp.EmailID,
                IsActive = emp.IsActive,
            }).ToList < UserLoginModel > ();
            return emps;
        }
        bool IWarehouse.BlockEmployee(int id)
        {
            var isUser = dbContext.UserLogins.Where(e => e.ID == id).FirstOrDefault();
            if(isUser != null)
            {
                isUser.IsActive = false;
                dbContext.SaveChanges();
                dbContext.Dispose();
            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            return false;
        }
    }
}