using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;
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
        public IActionResult GetAll() 
        {

            try
            {
                var products = _db.Products.ToList();
                var xmlDoc = new XElement("Products",
                products.Select(p => new XElement("Product",
                new XElement("ProductID", p.id),
                new XElement("Name", p.Name)
             
           ))
       );

               
                return Content(xmlDoc.ToString(), "application/xml");
            }
            
            catch (Exception ex)   
            { 
                return BadRequest(ex.Message); 
            }

            return null;    
        
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetbyId(int id)
        {

            try
            {
                var products = _db.Products.First(u => u.id == id);
                

              var xmlDoc = new XElement("Product",
              new XElement("Name", products.Name),
              new XElement("Price", products.id)
            
      );

                return Content(xmlDoc.ToString(), "application/xml");

            }

            catch (Exception ex) 
            {
                Ok(ex);
            }
           
            return Ok(null);
      
           
        }

    }
}
