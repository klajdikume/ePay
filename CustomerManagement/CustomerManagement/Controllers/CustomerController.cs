using CustomerManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpPost(Name = "PostCustomers")]
        public IActionResult Post([FromBody]List<Customer> customers)
        {
            
            return Ok();
        }
    }
}

/*
    
 
 
 */