using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerViewerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static CustomerViewerAPI.Database.MySqlDb;

namespace CustomerViewerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet("api/customers")]
        public List<User> Customers()
        {
            return GetAllCustomers().Result;
        }
        
        [HttpGet("api/customers/{id}")]
        public User Customers(int id)
        {
            return GetCustomer(id).Result;
        }

        [HttpPost("api/customers")]
        public void SaveNewCustomer(User customer)
        {
            Task.WaitAll(AddCustomer(customer));
        }

        [HttpPut("api/customers")]
        public void PutCustomer(User customer)
        {
            Task.WaitAll(UpdateCustomer(customer));
        }

        [HttpDelete("api/customers/{id}")]
        public void RemoveCustomer(int id)
        {
            Task.WaitAll(DeleteCustomer(id));
        }
    }
}