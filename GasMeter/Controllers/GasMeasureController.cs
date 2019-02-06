using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GasMeter.DataModels;
using GasMeter.Interfaces.Repositories;
using GasMeter.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GasMeter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GasMeasureController : ControllerBase
    {

        private readonly IMeasureRepository measureRepository;

        public GasMeasureController(IMeasureRepository measureRepository)
            => this.measureRepository = measureRepository;

        // GET api/gasmeasure
        [HttpGet]
        public ActionResult<IEnumerable<MeasureViewModel>> Get()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(measureRepository.GetAll());
        }

        // GET api/gasmeasure/e37a4f8a-c046-4c83-a455-08d68bae5a28
        [HttpGet("{id:guid}")]
        public ActionResult<MeasureViewModel> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!measureRepository.HasAny(m => m.Id == id))
                NoContent();

            return Ok(measureRepository.GetById(id));
        }

        // POST api/gasmeasure
        [HttpPost]
        public IActionResult Post([FromBody] MeasureViewModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Measure measure = Mapper.Map<Measure>(value);
            measureRepository.Create(measure);
            return CreatedAtAction("Get", new { Id = measure.Id});
        }

        // PUT api/gasmeasure/e37a4f8a-c046-4c83-a455-08d68bae5a28
        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, [FromBody] MeasureViewModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!measureRepository.HasAny(m => m.Id == id))
                NoContent();
            var dbMeasure = measureRepository.GetById(id);
            Mapper.Map<MeasureViewModel, Measure>(value, dbMeasure);
            measureRepository.Update(dbMeasure);
            return Ok();
        }

        // DELETE api/gasmeasure/e37a4f8a-c046-4c83-a455-08d68bae5a28
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!measureRepository.HasAny(m => m.Id == id))
                NoContent();
            var itemToDelete = measureRepository.GetById(id);
            measureRepository.Delete(itemToDelete);
            return Ok();
        }
    }
}
