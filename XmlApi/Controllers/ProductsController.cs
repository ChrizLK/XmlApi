using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using XmlApi.Data;
using XmlApi.Models;
using static Azure.Core.HttpHeader;
using static XmlApi.Data.AppDbContext;

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
        public IActionResult Getall(string name)
        {
            var products = _db.Products.First(u => u.Name == name);


            return Ok(products);

            // Parse the XML data
            //var xmlDoc = XDocument.Parse(products);

            // Return the raw XML
            //return Content(products.ToString(), "application/xml");

           
        }

    }
}
