using System;
using System.Collections.Generic;
using cs_all_spell.Models;
using cs_all_spell.Services;
using Microsoft.AspNetCore.Mvc;

namespace cs_all_spell.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReagentsController : ControllerBase
    {
        private readonly ReagentsService _service;

        public ReagentsController(ReagentsService service)
        {
            _service = service;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Reagent>> getAll()
        {
            try
            {
                IEnumerable<Reagent> reagents = _service.GetAll();
                return Ok(reagents);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Reagent> GetById(int id)
        {
            try
            {
                Reagent reagent = _service.GetById(id);
                return Ok(reagent);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Reagent> Create([FromBody] Reagent newReagent)
        {
            try
            {
                Reagent reagent = _service.Create(newReagent);
                return Ok(reagent);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Reagent> Update([FromBody] Reagent edit, int id)
        {
            try
            {
                edit.Id = id;
                Reagent update = _service.Update(edit);
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
                _service.DeleteReagent(id);
                return Ok("Successfully Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}