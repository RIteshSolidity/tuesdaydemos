using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using WebApplication7.ApplicationServices;
using WebApplication7.Repository;
using WebApplication7.dtos;
using WebApplication7.commands;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ISqlRepository repo;
        ICustomerApplicationServices services;
        public ValuesController(ISqlRepository _sql, ICustomerApplicationServices  _services)
        {
            repo = _sql;
            services = _services;
        }
        // GET api/values
        //[HttpGet]
        //public async Task<ActionResult<ICollection<CustomerDTO>>> Get()
        //{
        //    IEnumerable<Customer> aa = await repo.getAllCustomers();
        //    return Ok(aa);
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<CustomerDTO> Get(int id)
        //{
        //    return Ok(repo.GetCustomerbyID(id));
        //}

        // POST api/values
        [HttpPost]
        public async Task<CustomerDTO> Post([FromBody] CustomerDTO value)
        {
            string firstname = value.Name.Split(" ")[0];
            string lastname = value.Name.Split(" ")[1];
            ICommand cmd = new NewCustomerCommand(value.CustomerId, firstname, lastname, value.CreditScore);
            //Customer ee = await repo.InsertCustomer(value);
            services.Handle(cmd);
            return value;
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public async Task<CustomerDTO> Put(int id, [FromBody] CustomerDTO value)
        //{
        //    Customer ee = await repo.UpdateCustomer(value);
        //    return ee;
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public async Task<bool> Delete(int id)
        //{
        //    return await repo.DeleteCustomer(id);
        //}
    }
}
