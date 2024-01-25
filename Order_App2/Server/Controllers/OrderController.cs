using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Order_App2.Server.Interfaces;
using Order_App2.Shared.Entities;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Order_App2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _OrderService;

        public OrderController(IOrder iOrder)
        {
            _OrderService = iOrder;
        }
        [HttpGet]
        public async Task<List<Order>> Get()
        {
            return await Task.FromResult(_OrderService.GetOrderDetails());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Order order = _OrderService.GetOrderData(id);
           
            try
            {
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound();
            }
            catch (HttpRequestException ex)
            {
                // Log or handle the exception
                //Console.Error.WriteLine($"Error making HTTP request: {ex.Message}");
                throw ex;
            }
        }

        [HttpPost]
        public void Post(Order order)
        {
            _OrderService.AddOrder(order);
        }

        [HttpPut]
        public void Put(Order order)
        {
            _OrderService.UpdateOrder(order);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _OrderService.DeleteOrder(id);
            return Ok();
        }
    }
}

