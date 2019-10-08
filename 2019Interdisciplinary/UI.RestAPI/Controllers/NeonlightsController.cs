using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interdisciplinary.Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeonlightsController : Controller
    {
        /*private readonly INeonService _neonService;
        public NeonlightsController(INeonService neonService)
        {
            _neonService = neonService;
        }*/
        // GET api/neonlights

        private List<Neonlight> tempList = new List<Neonlight>();
        
        [HttpGet]
        public ActionResult<IEnumerable<Neonlight>> Get()
        {
            tempList.Add(new Neonlight{
                Name ="name1",
                Battery =true,
                Color =Neonlight.Colour.Green,
                Description ="it is a neonlight",
                EnergyLabel ="A+",
                Price =22,
                Shape =Neonlight.Shapes.Banana,
                Size =12,
                WpH =44});
            tempList.Add(new Neonlight { Name = "name2" });
            tempList.Add(new Neonlight { Name = "name3" });
            return tempList;
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