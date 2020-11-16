using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practica_SoloDeportes.Controllers
{
    [Route("api/TradeMarkController")]
    [ApiController]
    public class TradeMarkController : ControllerBase
    {
        // GET: api/<TradeMarkController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var JsonFile = new InteractionJson();
            return Ok(JsonFile.get());
        }

        // GET api/<TradeMarkController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TradeMarkController>
        [HttpPost]

        public async Task<IActionResult>AddTM()
        {
            var JsonFile = new InteractionJson();
            return Ok(JsonFile.AddTM());
        }
        // PUT api/<TradeMarkController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTM()
        {
            var JsonFile = new InteractionJson();
            return Ok(JsonFile.UpdateTM());
        }

        // DELETE api/<TradeMarkController>/5
        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteTM()
        {
            var JsonFile = new InteractionJson();
            return Ok(JsonFile.DeleteTM());
        }
    }
}
