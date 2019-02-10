using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GasMeter.DataModels;
using GasMeter.Interfaces.Repositories;
using GasMeter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Tesseract;

namespace GasMeter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GasMeasureController : ControllerBase
    {

        private readonly IMeasureRepository measureRepository;
        private readonly ICapturedImageRepository imageRepository;

        public GasMeasureController(IMeasureRepository measureRepository, ICapturedImageRepository imageRepository)
        {
            this.measureRepository = measureRepository;
            this.imageRepository = imageRepository;
        }

        // GET api/gasmeasure
        [HttpGet]
        public ActionResult<IEnumerable<MeasureDTO>> Get()
        {
            var t = System.IO.File.ReadAllBytes(@"Z:\Gaz\unt2.png");
            var str = System.Text.Encoding.UTF8.GetString(t);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(measureRepository.GetAll());
        }

        // GET api/gasmeasure/e37a4f8a-c046-4c83-a455-08d68bae5a28
        [HttpGet("{id:guid}")]
        public ActionResult<MeasureDTO> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!measureRepository.HasAny(m => m.Id == id))
                NoContent();

            return Ok(measureRepository.GetById(id));
        }

        // POST api/gasmeasure
        [HttpPost]
        public IActionResult Post([FromBody] CapturedImageDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            CapturedImage image = Mapper.Map<CapturedImage>(value);
            imageRepository.Create(image);
            return CreatedAtAction("Get", new { Id = image.Id});
        }

        // PUT api/gasmeasure/e37a4f8a-c046-4c83-a455-08d68bae5a28
        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, [FromBody] MeasureDTO value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!measureRepository.HasAny(m => m.Id == id))
                NoContent();
            var dbMeasure = measureRepository.GetById(id);
            Mapper.Map<MeasureDTO, Measure>(value, dbMeasure);
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
