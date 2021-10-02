using DataAccessLayer;
using DataAccessLayer.DB;
using DataAccessLayer.Services;
using DataAccessLayer.Services.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Model.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    /// <summary>
    /// Orders API
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly Result res;
        private readonly IjwtAuth jwtAuth;
        private readonly IOrderService orderService;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="jwtAuth"></param>
        /// <param name="orderService"></param>
        public OrdersController(IjwtAuth jwtAuth, IOrderService orderService, Result res)
        {
            this.res = res;
            this.jwtAuth = jwtAuth;
            this.orderService = orderService;
        }

        /// <summary>
        /// Add order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public Order Add(Order order)
        {
            orderService.AddOrder(order);
            return order;
        }

        /// <summary>
        /// Edit Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost("Edit")]
        public IActionResult Edit([FromBody] Order order)
        {
            orderService.UpdateOrder(order);
            res.header.success = true;
            res.header.message = "Edit Order Success";
            return Ok(res);
        }

        /// <summary>
        /// GetAllOrderByUser
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var orders = orderService.GetAllOrderByUser(userId);
            var orderVM = orders.Select(x => new
            {
                Id = x.Id,
                OrderNumber = x.OrderNumber,
                OrderDueDate = x.OrderDueDate,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                MobileNum = x.User.MobileNum,
                OrderTotal = x.OrderTotal
            }).ToList();

            res.header.success = true;
            res.header.message = "GetAll Order Success";
            res.data = orderVM;
            return Ok(res);
        }
    }
}
