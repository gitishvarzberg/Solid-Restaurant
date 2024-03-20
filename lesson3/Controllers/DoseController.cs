using Restaurant.Core.Models;
using Restaurant.Core.Repositories;
using Restaurant.Service.Services;
//using lesson3.Entities;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoseController : ControllerBase
    {
        private readonly IDoseService _DoseService;
        public DoseController(IDoseService DoseService)
        {
            _DoseService = DoseService;
        }

        // GET: api/<MenuController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_DoseService.GetDoses());
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok( _DoseService.GetById(id));
        }

        // POST api/<MenuController>
        [HttpPost]
        public async Task< ActionResult> Post([FromBody] Dose dose)
        {
            var newDose = await _DoseService.AddDoseAsync(dose);
            return Ok(newDose );
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Dose d)
        {
           return Ok( _DoseService.UpdateDose(id, d));
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var temp = _DoseService.GetById(id);
            if (temp is null)
            {
                return NotFound();
            }
            _DoseService.DeleteDose(id);
            return NoContent(); 

        }
    }
}
