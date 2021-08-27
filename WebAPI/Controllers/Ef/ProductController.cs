using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Abstracts.EfService;
using Entities;
using Microsoft.Extensions.Caching.Memory;
using MemoryCache = System.Runtime.Caching.MemoryCache;
using Vse.Web.Serialization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var cache = MemoryCache.Default;
            var productlist = new List<Product>();
            productlist = (List<Product>)cache.Get("productlist");
            if (productlist == null)
            {

                productlist = _productService.GetAll().Data;
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were not in the cache.I got the from data source SLOW at " + DateTime.Now);

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                cache.Set("productlist", productlist, policy);
                return Ok(productlist);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were in the cache.I got the from data source FAST at " + DateTime.Now);
            }

            return Ok(productlist);

        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var cache = MemoryCache.Default;
            var productlistid = new Product();
            productlistid = (Product)cache.Get("productlistid");
            if (productlistid == null)
            {

                productlistid = _productService.Get(id).Data;
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were not in the cache.I got the from data source SLOW at " + DateTime.Now);

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                cache.Set("productlistid", productlistid, policy);
                return Ok(productlistid);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were in the cache.I got the from data source FAST at " + DateTime.Now);
            }

            return Ok(productlistid);
        }

        [HttpGet("getbyresid")]
        public IActionResult GetByRestaurantId(int id)
        {
            var cache = MemoryCache.Default;
            var productlistresid = new List<Product>();
            productlistresid = (List<Product>)cache.Get("productlistresid");
            if (productlistresid == null)
            {

                productlistresid = _productService.GetByRestaurantId(id).Data;
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were not in the cache.I got the from data source SLOW at " + DateTime.Now);

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                cache.Set("productlistresid", productlistresid, policy);
                return Ok(productlistresid);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were in the cache.I got the from data source FAST at " + DateTime.Now);
            }

            return Ok(productlistresid);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
