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
    public class OrderDetailController : Controller
    {
        private IOrderDetailService _detailService;

        public OrderDetailController(IOrderDetailService detailService)
        {
            _detailService = detailService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _detailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _detailService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(OrderDetail detail)
        {
            var result = _detailService.Add(detail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(OrderDetail detail)
        {
            var result = _detailService.Update(detail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(OrderDetail detail)
        {
            var result = _detailService.Delete(detail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
