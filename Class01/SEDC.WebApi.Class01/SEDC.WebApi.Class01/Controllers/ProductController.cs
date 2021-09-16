using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC.WebApi.Class01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Coca - cola",
                Barcode = 123456,
                Price = 25
            },
            new Product()
            {
                Id = 2,
                Name = "Pepsi",
                Barcode = 123886,
                Price = 33
            },
            new Product()
            {
                Id = 3,
                Name = "Sprite",
                Barcode = 1234988,
                Price = 30
            },
            new Product()
            {
                Id = 4,
                Name = "Fanta",
                Barcode = 989456,
                Price = 29
            }

        };



        // GET: api/<ProductController>
        [HttpGet] // endpoint. koga na url kje pisam localhost/api/product kje gi zeme dvata get methodi zatoa kje kreiram route.
        public List<Product> Get()
        {
            return products;
        }

        // locat host/api/product - pad varijabla
        // localhost/api/product/rutata?id=2 - primer za kveri varijabla. pisuvame prasalnik , pa imeto na varijablata i vrednosta
        [HttpGet]
        [Route ("product")]
        public Product GetById ([FromQuery]int id)
        {
            return products.FirstOrDefault(x => x.Id == id);

        }

        //// GET api/<ProductController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
