using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesProject_Ec.Models
{
    public class AuthorizerProfileModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string PhoneNumber { get; set; }

    }
}