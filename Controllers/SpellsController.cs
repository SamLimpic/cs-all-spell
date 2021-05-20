using System;
using System.Collections.Generic;
using cs_all_spell.Models;
using cs_all_spell.Services;
using Microsoft.AspNetCore.Mvc;

namespace cs_all_spell.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpellsController : ControllerBase
    {
        private readonly SpellsService _service;

        public SpellsController(SpellsService service)
        {
            _service = service;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Spell>> getAll()
        {
            try
            {
                IEnumerable<Spell> spells = _service.GetAll();
                return Ok(spells);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Spell> GetById(int id)
        {
            try
            {
                Spell spell = _service.GetById(id);
                return Ok(spell);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Spell> Create([FromBody] Spell newSpell)
        {
            try
            {
                Spell spell = _service.Create(newSpell);
                return Ok(spell);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Spell> Update([FromBody] Spell edit, int id)
        {
            try
            {
                edit.Id = id;
                Spell update = _service.Update(edit);
                return Ok(update);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                _service.DeleteSpell(id);
                return Ok("Successfully Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}