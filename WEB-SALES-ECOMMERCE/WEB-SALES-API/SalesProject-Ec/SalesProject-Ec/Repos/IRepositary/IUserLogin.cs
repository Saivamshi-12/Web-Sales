using SalesProject_Ec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject_Ec.Repos.IRepositary
{
    public interface IUserLogin
    {
    int[] AuthenticateUser(string loginId, string password);
        List<MyProfileModel> GetProfile(int id);
        List<ProductsModel> getProducts();
        bool EditProfiles(UserLoginModel profile);
    }
}
