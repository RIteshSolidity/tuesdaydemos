using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerFramework;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace CustomerClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ICustomerService _service;
        public ValuesController()
        {
            _service = ServiceProxy.Create<ICustomerService>(new Uri("fabric:/Walmart/Customer"), new Microsoft.ServiceFabric.Services.Client.ServicePartitionKey(0));
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            var users = await _service.GetAllCustomers();
            return Ok(users);
        }


        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Users value)
        {
            await _service.AddCustomer(value);
        }


    }
}
