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
    public class OrderController : ControllerBase
    {
        [HttpGet()]
        public List<Order> GetAllOrders()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Orders.ToList();
            }
        }

        [HttpGet("{id}")]
        public List<Order> SearchByID(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                List<Order> result = context.Orders.ToList().Where(e => e.OrderId == id).ToList();
                return result;
            }
        }

    }
}
