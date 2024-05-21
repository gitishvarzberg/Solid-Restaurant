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
        public async Task <ActionResult> Get()
        {
            return Ok(await _DoseService.GetDosesAsync());
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public async Task< ActionResult> Get(int id)
        {
            var does = await _DoseService.GetDoseByIdAsync(id);
            return Ok( does );
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
        public async Task <ActionResult> Put(int id, [FromBody] Dose d)
        {
           return Ok( await _DoseService.UpdateDoseAsync(id, d));
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public async Task < ActionResult> Delete(int id)
        {
            var temp =await _DoseService.GetDoseByIdAsync(id);
            if (temp is null)
            {
                return NotFound();
            }
            await _DoseService.DeleteDoseAsync(id);
            return NoContent(); 

        }
    }
}
