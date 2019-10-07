using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UI.RestAPI.Controllers
{
    public class NeonlightsController : Controller
    {
        /*private readonly INeonService _neonService;
        public NeonlightsController(INeonService neonService)
        {
            _neonService = neonService;
        }*/
        // GET api/neonlights
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/neonlights/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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