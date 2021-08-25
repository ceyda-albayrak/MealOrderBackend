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

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var cache = MemoryCache.Default;
            var categorylist = new List<Category>();
            categorylist = (List<Category>)cache.Get("categorylist");
            if (categorylist == null)
            {

                categorylist = _categoryService.GetAll().Data;
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were not in the cache.I got the from data source SLOW at " + DateTime.Now);

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                cache.Set("categorylist", categorylist, policy);
                return Ok(categorylist);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were in the cache.I got the from data source FAST at " + DateTime.Now);
            }

            return Ok(categorylist);
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var cache = MemoryCache.Default;
            var categorylistid = new Category();
            categorylistid = (Category) cache.Get("categorylistid");
            if (categorylistid == null)
            {

                categorylistid = _categoryService.Get(id).Data;
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were not in the cache.I got the from data source SLOW at " + DateTime.Now);

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                cache.Set("categorylistid", categorylistid, policy);
                return Ok(categorylistid);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were in the cache.I got the from data source FAST at " + DateTime.Now);
            }

            return Ok(categorylistid);
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
