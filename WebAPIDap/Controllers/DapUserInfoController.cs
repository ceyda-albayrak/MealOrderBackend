using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Abstracts.DapService;
using Business.Abstracts.EfService;
using Entities;

namespace WebAPI.Controllers.Dap
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapUserInfoController : Controller
    {
        private IDapUserInfoService _infoService;

        public DapUserInfoController(IDapUserInfoService infoService)
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

        [HttpPost("add")]
        public IActionResult Add(UserInfo info)
        {
            var result = _infoService.Add(info);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(UserInfo info)
        {
            var result = _infoService.Update(info);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(UserInfo info)
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
