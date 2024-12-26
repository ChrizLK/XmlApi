using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XmlApi.Data;
using XmlApi.Models;
using static Azure.Core.HttpHeader;

namespace XmlApi.Controllers.v2
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
            var result = _db.Products.ToList();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == id);
            return Ok(product);

        }

        [HttpPost]
        [Route("api/add")]
        public IActionResult Addproduct([FromBody] Product product)
        {


            _db.Products.Add(product);
            _db.SaveChanges();

            return Ok(product);

        }

    }
}
