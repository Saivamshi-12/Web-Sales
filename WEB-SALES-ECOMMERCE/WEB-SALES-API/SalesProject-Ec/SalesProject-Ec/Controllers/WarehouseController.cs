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
    public class WarehouseController : ApiController
    {
        public readonly IWarehouse iWarehouse;

        public WarehouseController(IWarehouse iWarehouse)
        {
            this.iWarehouse = iWarehouse;
        }

        [Route("api/Warehouse/register")]
        [HttpPost]
        public IHttpActionResult Registerwh(UserLoginModel newRegister)
        {
            var registered = iWarehouse.RegisterWh(newRegister);
            if(registered == true)
            {
                return Ok(registered);
            }
            return BadRequest();
        }

        [Route("api/Warehouse/addStock")]
        [HttpPost]

        public  IHttpActionResult Addstock(ProductsModel product)
        {
            var isProductAdded = iWarehouse.AddStock(product);
            if(isProductAdded == true)
            {
                return Ok(isProductAdded);
            }
            return BadRequest("stock not updated");
        }

        [Route("api/Warehouse/addStockQty")]
        [HttpPost]

        public IHttpActionResult AddStockInvent(ProductAvailModel productQty)
        {
            var isQtyAdded = iWarehouse.AddStockInvent(productQty);
            if (isQtyAdded)
            {
                return Ok(isQtyAdded);
            }
            return BadRequest("stock is not updated");
        }


        [Route("api/Warehouse/getqty/{productID}")]
        [HttpGet]

        public IHttpActionResult GetProductQuantity(int productId)
        {
            var qty = iWarehouse.GetProductquantity(productId);
            return Ok(qty);
        }

        [Route("api/Warehouse/updateStock")]
        [HttpPost]
        public IHttpActionResult UpdateStock(ProductsModel product)
        {
            var res = iWarehouse.UpdateStock(product);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest();
        }
        [Route("api/Warehouse/updateStockQty")]
        [HttpPost]
        public IHttpActionResult UpdateQuantity(ProductAvailModel productQty)
        {
            var res = iWarehouse.UpdateQuantity(productQty);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest();
        }
        [Route("api/Warehouse/dispatch/{orderID}")]
        [HttpGet]
        public IHttpActionResult DispatchOrder(int orderID)
        {
            var res = iWarehouse.DispatchOrder(orderID);
            return Ok(res);
        }
        [Route("api/Warehouse/Emps")]
        [HttpGet]
        public IHttpActionResult GetAllEmployees()
        {
            var employees = iWarehouse.GetAllEmmployees();
            if(employees.Count != 0)
            {
                return Ok(employees);
            }
            return NotFound();
        }
        [Route("api/Warehouse/blockEmp/{id}")]
        [HttpGet]
        public IHttpActionResult blockEmployee(int id)
        {
            var res = iWarehouse.BlockEmployee(id);
            if (res)
            {
                return Ok(res);
            }
            return BadRequest();
        }
    }
}
