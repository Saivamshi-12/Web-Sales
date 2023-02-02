using SalesProject_Ec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject_Ec.Repos.IRepositary
{
    public interface IAdmin
    {
        List<OrdersModel> GetAllOrders();
        bool verifyUser(string email, string userName);
        bool ResetPassword(string userName, string Password);
    }
}
