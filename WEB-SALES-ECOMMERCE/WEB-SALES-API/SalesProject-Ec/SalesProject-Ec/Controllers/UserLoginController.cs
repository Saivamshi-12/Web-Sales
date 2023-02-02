using SalesProject_Ec.Models;
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
    public class UserLoginController : ApiController
    {
        public readonly IUserLogin iUserLogin;
        public UserLoginController(IUserLogin iUserLogin)
        {
            this.iUserLogin = iUserLogin;
        }

        [Route("api/UserLogin/authentication/{loginId}/{password}")]
        [HttpGet]
        public IHttpActionResult IsUserValid(string loginId, string Password)
        {
            var isUser = iUserLogin.AuthenticateUser(loginId, Password);
            return Ok(isUser);
        }

        [Route("api/UserLogin/myProfile/{id}")]
        [HttpGet]
        public IHttpActionResult GetMyProfile(int id)
        {
            var myProfile = iUserLogin.GetProfile(id);
            if (myProfile == null)
            {
                return NotFound();
            }
            return Ok(myProfile);
        }

        [Route("api/UserLogin/getProducts")]
        [HttpGet]
        public HttpResponseMessage GetProducts()
        {
            var products = iUserLogin.getProducts();
            if (products.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "No data found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        [Route("api/UserLogin/editProfile")]
        [HttpPost]
        public IHttpActionResult EditProfile(UserLoginModel user)
        {
            var res = iUserLogin.EditProfiles(user);
            if (res)
            {
                return Ok(res);

            }
            return BadRequest();
        }
        [Route("api/UserLogin/getProfiles/{id}")]
        [HttpGet]
        public IHttpActionResult GetProfiles(int id)
        {
            var profile = iUserLogin.GetProfile(id);
            if (profile != null)
            {
                return Ok(profile);
            }
            return NotFound();
        }
        [Route("api/UserLogin/editProfiles")]
        [HttpPost]
        public IHttpActionResult EditProfiles(UserLoginModel profile)
        {
            var isEdited = iUserLogin.EditProfiles(profile);
            if (isEdited)
            {
                return Ok(isEdited);
            }
            return BadRequest();
        }
    }
}
