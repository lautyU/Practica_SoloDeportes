using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practica_SoloDeportes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        // GET: api/<SizeController>
        [HttpGet]
        public async Task<IActionResult> GetS()
        {
            var JsonFile = new InteractionJson();
            return Ok(JsonFile.GetS());
        }

        // GET api/<SizeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SizeController>
        [HttpPost]
        public async Task<IActionResult>AddSize()
        {
            var JsonFile= new InteractionJson();
            return Ok(JsonFile.AddSize());
    
        }

        // PUT api/<SizeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateSize()
        {
            var JsonFile = new InteractionJson();
            return Ok(JsonFile.UpdateSize());
        }

        // DELETE api/<SizeController>/5
        [HttpDelete("{id}")]
       public async Task<IActionResult>DeletedSize()
        {
            var JsonFile = new InteractionJson();
            return Ok(JsonFile.DeleteSize());
        }
    }
}
