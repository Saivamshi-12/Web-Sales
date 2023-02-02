using SalesProject_Ec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject_Ec.Repos.IRepositary
{
    public interface IAuthorizer
    {
        List<DistributorModel> GetAllDistributors();
        List<PurchaseOrderModel> PurchaseOrders(int id);
        bool AcceptReject(int OrderID, string isAccepted, int distid);
        List<AuthorizerProfileModel> GetProfile(int id);
    }
}
