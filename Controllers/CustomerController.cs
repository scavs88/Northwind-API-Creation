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
    public class CustomerController : ControllerBase
    {
        [HttpGet()]
        public List<Customer> GetAllOrders()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Customers.ToList();
            }
        }

        
        [HttpDelete("delete/{id}")]
        public string DeleteOrder(int id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                Order order = context.Orders.ToList().Find(o => o.OrderId == id);
                if (order == null)
                {
                    return "That order was not found"; 
                }
                else
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                    return "That order was deleted.";
                }
                
            }
        }


    }
}
