using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interdisciplinary.Core.ApplicationServices;
using Interdisciplinary.Core.ApplicationServices.Services;
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
        public ActionResult<IEnumerable<Neonlight>> Get()
        {
            _neonService.ReadAll();
            return tempList;
        }

        // GET api/neonlights/5
        [HttpGet("{id}")]
        public ActionResult<Neonlight> Get(int id)
        {
            return _neonService.ReadById(id);
        }

        // POST api/neonlights
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/neonlights/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/neonlights/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}