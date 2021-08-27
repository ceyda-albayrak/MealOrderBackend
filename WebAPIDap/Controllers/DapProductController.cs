using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Abstracts.DapService;
using Business.Abstracts.EfService;
using Entities;
using Microsoft.Extensions.Caching.Memory;
using MemoryCache = System.Runtime.Caching.MemoryCache;
using Vse.Web.Serialization;

namespace WebAPI.Controllers.Dap
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapProductController : Controller
    {
        private IDapProductService _productService;

        public DapProductController(IDapProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var cache = MemoryCache.Default;
            var productlistdap = new List<Product>();
            productlistdap = (List<Product>)cache.Get("productlist");
            if (productlistdap == null)
            {

                productlistdap = _productService.GetAll().Data;
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were not in the cache.I got the from data source SLOW at " + DateTime.Now);

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                cache.Set("productlistdap", productlistdap, policy);
                return Ok(productlistdap);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were in the cache.I got the from data source FAST at " + DateTime.Now);
            }

            return Ok(productlistdap);

        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var cache = MemoryCache.Default;
            var productlistdapid = new Product();
            productlistdapid = (Product)cache.Get("productlistid");
            if (productlistdapid == null)
            {

                productlistdapid = _productService.Get(id).Data;
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were not in the cache.I got the from data source SLOW at " + DateTime.Now);

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                cache.Set("productlistdapid", productlistdapid, policy);
                return Ok(productlistdapid);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were in the cache.I got the from data source FAST at " + DateTime.Now);
            }

            return Ok(productlistdapid);
        }

        [HttpGet("getbyresid")]
        public IActionResult GetByRestaurantId(int id)
        {
            var cache = MemoryCache.Default;
            var productlistdapresid = new List<Product>();
            productlistdapresid = (List<Product>)cache.Get("productlistresid");
            if (productlistdapresid == null)
            {

                productlistdapresid = _productService.GetByRestaurantId(id).Data;
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were not in the cache.I got the from data source SLOW at " + DateTime.Now);

                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                cache.Set("productlistdapresid", productlistdapresid, policy);
                return Ok(productlistdapresid);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(
                    "TEntity were in the cache.I got the from data source FAST at " + DateTime.Now);
            }

            return Ok(productlistdapresid);
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
