using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestServer.Data;

namespace RestServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
         private IAdultService adultsService;

        public AdultController(IAdultService adultsService)
        {
            this.adultsService = adultsService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            try
            {
                IList<Adult> adults = await adultsService.ReadAllAdults();
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int adultId
        ) {
            try {
                await adultsService.DeleteAdult(adultId);
                return Ok();
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult addAdult) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Adult added = await adultsService.AddAdult(addAdult);
                return Created($"/{added.Id}",added);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{Id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdult([FromBody] Adult updateAdult) {
            try {
                Adult updatedAdult = await adultsService.UpdateAdult(updateAdult);
                return Ok(updatedAdult); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}