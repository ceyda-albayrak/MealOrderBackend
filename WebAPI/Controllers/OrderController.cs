using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _orderService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Order order)
        {
            var result = _orderService.Add(order);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(Order order)
        {
            var result = _orderService.Update(order);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Order order)
        {
            var result = _orderService.Delete(order);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }


    }
}
