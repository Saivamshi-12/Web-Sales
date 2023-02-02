using SalesProject_Ec.Repos.IRepositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using SalesProject_Ec.Models;

namespace SalesProject_Ec.Repos.RepositaryClass
{
    public class UserLogin : IUserLogin
    {
        salesProjectEntities1 dbContext = new salesProjectEntities1();

       
        int[] IUserLogin.AuthenticateUser(string loginId, string password)
        {
            int[] user = new int[2];
            var isUser = dbContext.UserLogins.Where(e => e.LoginID == loginId && e.Password == password).FirstOrDefault();
            if (isUser != null)
            {
                user[0] = isUser.ID;
                user[1] = (int)isUser.UserTypeID;
                dbContext.Dispose();
                return user;
            }
            return user;
        }

        List<MyProfileModel> IUserLogin.GetProfile(int id)
        {
            var exists = dbContext.UserLogins.Where(e => e.ID == id).FirstOrDefault();
            List<MyProfileModel> myProfile = null;
            if(exists != null)
            {
                myProfile = (from U in dbContext.UserLogins
                             join M in dbContext.Members
                             on U.ID equals M.ID
                             join MCP in dbContext.MemberContactPhones
                             on U.ID equals MCP.ID
                             join A in dbContext.AddressDetails
                             on U.ID equals A.ID
                             where U.ID == id
                             select new MyProfileModel()
                             {
                                 UserName = M.UserName,
                                 EmailID = U.EmailID,
                                 FirstName = U.FirstName,
                                 MiddleInitial = U.MiddleInitial,
                                 LastName = U.LastName,
                                 PhoneNumber = MCP.PhoneNumber,
                                 AddressLine1 = A.AdressLine1,
                                 AddressLine2 = A.Adressline2,
                                 City = A.City,
                                 StateName = A.StateName,
                                 Country = A.Country,
                                 ZipCode = A.ZipCode

                             }).ToList<MyProfileModel>();
            }
            dbContext.Dispose();
            return myProfile;
        }

        List<ProductsModel> IUserLogin.getProducts()
        {
            var productList = dbContext.Products.Select(e => new ProductsModel()
            {
                ID = e.ID,
                Name = e.Name,
                Description = e.Description,
                MARKETID = e.MARKETID,
                DateInserted = e.DateInserted,
                ExpirationDate = e.ExpirationDate,
                ImageURL = e.ImageURL,
                TaxPrice = e.TaxPrice,
                Weight = e.Weight,
                UnitPrice = e.UnitPrice,
                MinimumOrderDty = e.MinimumOrderDty,
                ProductCategoryID = e.ProductCategoryID

            }).ToList<ProductsModel>();
            dbContext.Dispose();
            return productList;
        }

         bool IUserLogin.EditProfiles(UserLoginModel profile)
        {
            var isProfile = dbContext.UserLogins.Single(e => e.ID == profile.ID);
            if(isProfile != null)
            {
                isProfile.LoginID = profile.LoginID;
                isProfile.FirmName = profile.FirstName;
                isProfile.EmailID = profile.LastName;
                isProfile.PhoneNumber = profile.PhoneNumber;
                dbContext.Dispose();
                return true;

            }
            dbContext.SaveChanges();
            dbContext.Dispose();
            return false;
        }
    }
}