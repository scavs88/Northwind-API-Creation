using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet()]
        public List<Product> GetAllProducts()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }


        [HttpGet("id")]
        public List<Product> SearchByID(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                List<Product> result = context.Products.ToList().Where(e => e.ProductId == id).ToList();
                return result;
            }
        }
    }
}
