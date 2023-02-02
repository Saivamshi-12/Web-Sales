using SalesProject_Ec.Repos.IRepositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SalesProject_Ec.Controllers
{
    [EnableCors(methods: "*", headers: "*", origins: "*")]
    public class AdminController : ApiController
    {
        public readonly IAdmin iAdmin;
        public AdminController(IAdmin iAdmin)
        {
            this.iAdmin = iAdmin;
        }
        [Route("api/Admin/orders")]
        [HttpGet]
        public IHttpActionResult GetAllOrdeers()
        {
            var orders = iAdmin.GetAllOrders();
            if(orders.Count != 0)
            {
                return Ok(orders);
            }
            return NotFound();
        }
        [Route("api/Admin/verifyEmail/{email}/{userName}")]
        [HttpGet]

        public IHttpActionResult verifyUser(string email, string userName)
        {
            var isUser = iAdmin.verifyUser(email, userName);
           
                return Ok(isUser);
          
        }
        [Route("api/Admin/passReset/{userName}/{password}")]
        [HttpGet]
        public IHttpActionResult ResetPassword(string userName, string password)
        {
            var res = iAdmin.ResetPassword(userName, password);
            return Ok(res);
        }
    }
}
