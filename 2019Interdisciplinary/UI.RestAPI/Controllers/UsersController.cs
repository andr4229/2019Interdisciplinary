using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interdisciplinary.Core.ApplicationServices;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ActionResult<FilteredList<User>> Get([FromQuery]Filter filter)
        {
            return _userService.ReadAll(filter);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _userService.ReadById(id);
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userService.Create(user);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            if (id < 1 || id != user.Id)
            {
                return BadRequest("The parameter id and id in the user is not the same");
            }
            else
            {
                return Ok(_userService.Update(user));
            }
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
    }
}
