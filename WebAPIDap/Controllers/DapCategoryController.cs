using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Results;
using Entities;
using System.Runtime.Caching;
using Business.Abstracts.DapService;
using Business.Abstracts.EfService;

namespace WebAPI.Controllers.Dap
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapCategoryController : Controller
    {
        private IDapCategoryService _categoryService;

        public DapCategoryController(IDapCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var cache = MemoryCache.Default;
            var categorylistdap = new List<Category>();
            categorylistdap = (List<Category>)cache.Get("categorylist");
            if (categorylistdap == null)
            {

                categorylistdap = _categoryService.GetAll().Data;
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were not in the cache.I got the from data source SLOW at " + DateTime.Now);

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                cache.Set("categorylistdap", categorylistdap, policy);
                return Ok(categorylistdap);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were in the cache.I got the from data source FAST at " + DateTime.Now);
            }

            return Ok(categorylistdap);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var cache = MemoryCache.Default;
            var categorylistdapid = new Category();
            categorylistdapid = (Category) cache.Get("categorylistid");
            if (categorylistdapid == null)
            {

                categorylistdapid = _categoryService.Get(id).Data;
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were not in the cache.I got the from data source SLOW at " + DateTime.Now);

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                cache.Set("categorylistdapid", categorylistdapid, policy);
                return Ok(categorylistdapid);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were in the cache.I got the from data source FAST at " + DateTime.Now);
            }

            return Ok(categorylistdapid);
        }

        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Category category)
        {
            var result = _categoryService.Delete(category);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }


    }
}
