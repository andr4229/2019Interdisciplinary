﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interdisciplinary.Core.DomainServices;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private ICustomerRepository _custRepo;

        public CustomersController(ICustomerRepository custRepo)
        {
            _custRepo = custRepo;
        }
        // GET api/values?CurrentPage=1&ItemsPrPage=2
        [HttpGet]
        public ActionResult<FilteredList<Customer>> Get([FromQuery]Filter filter)
        {
            return _custRepo.ReadAll(filter);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return _custRepo.ReadById(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            _custRepo.Create(customer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            if (id < 1 && id == customer.Id)
            {
                BadRequest("The id on the query and the id in the body doesn't match'");
            }
            else
            {
                Ok(_custRepo.Update(customer));
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _custRepo.Delete(id);
        }
    }
}