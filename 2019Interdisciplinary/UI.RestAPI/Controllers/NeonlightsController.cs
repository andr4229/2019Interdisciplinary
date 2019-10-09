using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interdisciplinary.Core.ApplicationServices;
using Interdisciplinary.Core.ApplicationServices.Services;
using Interdisciplinary.Core.DomainServices.Filtering;
using Interdisciplinary.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeonlightsController : Controller
    {
        public NeonlightsController(INeonService neonService)
        {
            _neonService = neonService;
        }
        /*private readonly INeonService _neonService;
        public NeonlightsController(INeonService neonService)
        {
            _neonService = neonService;
        }*/
        // GET api/neonlights

        private List<Neonlight> tempList = new List<Neonlight>();
        private readonly INeonService _neonService;

        [HttpGet]
        public ActionResult<FilteredList<Neonlight>> Get([FromQuery]Filter filter)
        {
            return _neonService.ReadAll(filter);
        }

        // GET api/neonlights/5
        [HttpGet("{id}")]
        public ActionResult<Neonlight> Get(int id)
        {
            return _neonService.ReadById(id);
        }

        // POST api/neonlights
        [HttpPost]
        public void Post([FromBody] Neonlight neonlight)
        {
            _neonService.Create(neonlight);
        }

        // PUT api/neonlights/5
        [HttpPut("{id}")]
        public ActionResult<Neonlight> Put(int id, [FromBody] Neonlight neonlight)
        {
            if (id < 1 || id != neonlight.Id)
            {
                return BadRequest("The parameter id and id in the order is not the same");
            }
            else
            {
                return Ok(_neonService.Update(neonlight));
            }
        }

        // DELETE api/neonlights/5
        [HttpDelete("{id}")]
        public ActionResult<Neonlight> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest("The parameter id and id in the order is not the same");
            }
            else
            {
                _neonService.Delete(id);
                return Ok("Deleted");
            }
        }
    }
}