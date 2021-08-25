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
    public class RestaurantInfoController : Controller
    {
        private IRestaurantInfoService _infoService;

        public RestaurantInfoController(IRestaurantInfoService infoService)
        {
            _infoService = infoService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _infoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _infoService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getbyregionid")]
        public IActionResult GetByRegionId(int id)
        {
            var result = _infoService.GetByRegionId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(RestaurantInfo info)
        {
            var result = _infoService.Add(info);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(RestaurantInfo info)
        {
            var result = _infoService.Update(info);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(RestaurantInfo info)
        {
            var result = _infoService.Delete(info);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
