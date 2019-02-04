using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GasMeter.DataModels;
using GasMeter.Interfaces.Repositories;
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

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Measure>> Get()
        {
            return Ok(measureRepository.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id:guid}")]
        public ActionResult<Measure> Get(Guid id)
        {
            return Ok(measureRepository.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Measure value)
        {
            measureRepository.Create(value);
        }

        // PUT api/values/5
        [HttpPut("{id:guid}")]
        public void Put(Guid id, [FromBody] Measure value)
        {
            measureRepository.Update(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            var itemToDelete = measureRepository.GetById(id);
            measureRepository.Delete(itemToDelete);
        }
    }
}
