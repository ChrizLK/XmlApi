using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XmlApi.Data;
using XmlApi.Models;
using static Azure.Core.HttpHeader;

namespace XmlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly AppDbContext _db;
       
        public ProductsController(AppDbContext db)
        {

            _db = db;
           
        }

        [HttpGet]
        public IActionResult Getall()
        {
            var result = _db.Coupons.ToList();
            return Ok(result);
        }

    }
}
