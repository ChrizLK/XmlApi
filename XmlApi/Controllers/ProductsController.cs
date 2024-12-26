using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XmlApi.Data;
using XmlApi.Models;
using XmlApi.Services.Caching;
using static Azure.Core.HttpHeader;

namespace XmlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly AppDbContext _db;
        private readonly IRedisCacheService _cache;
       
        public ProductsController(AppDbContext db , IRedisCacheService cache)
        {

            _db = db;
            _cache = cache;

           
        }

        [HttpGet]
        public IActionResult Getall()
        {
            var result = _db.Coupons.ToList();
            return Ok(result);
        }

    }
}
