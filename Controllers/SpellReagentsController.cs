using System;
using cs_all_spell.Models;
using cs_all_spell.Services;
using Microsoft.AspNetCore.Mvc;

namespace cs_all_spell.Controllers
{
    [ApiController]
    [Route("api/[controller]")]



    public class SpellReagentsController : ControllerBase
    {
        private readonly SpellReagentsService _service;

        public SpellReagentsController(SpellReagentsService service)
        {
            _service = service;
        }



        [HttpPost]
        public ActionResult<SpellReagentDTO> Create([FromBody] SpellReagentDTO data)
        {
            try
            {
                SpellReagentDTO newReagent = _service.Create(data);
                return Ok(newReagent);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPut("{id}")]
        public ActionResult<SpellReagentDTO> Update([FromBody] SpellReagentDTO data)
        {
            try
            {
                SpellReagentDTO update = _service.Update(data);
                return Ok(update);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpDelete("{id}")]
        public ActionResult<SpellReagentDTO> Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Successfully Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}