using BlockexBlazor.Models;
using BlockexBlazor.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlockexBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceHeadersController : ControllerBase
    {
        private readonly MongodbService _mongodbService;

        public SourceHeadersController(MongodbService mongodbService)
        {
            _mongodbService = mongodbService;
        }

        [HttpGet]
        public ActionResult<List<SourceHeader>> Get() =>
            _mongodbService.Get();

        [HttpGet("{id:length(24)}", Name = "GetSourceHeader")]
        public ActionResult<SourceHeader> Get(string id)
        {
            var sourceHeader = _mongodbService.Get(id);

            if (sourceHeader == null)
            {
                return NotFound();
            }

            return sourceHeader;
        }

        [HttpPost]
        public ActionResult<SourceHeader> Create(SourceHeader sourceHeader)
        {
            _mongodbService.Create(sourceHeader);

            return CreatedAtRoute("GetSourceHeader", new { id = sourceHeader.Id.ToString() }, sourceHeader);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, SourceHeader SourceHeaderIn)
        {
            var sourceHeader = _mongodbService.Get(id);

            if (sourceHeader == null)
            {
                return NotFound();
            }

            _mongodbService.Update(id, SourceHeaderIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var sourceHeader = _mongodbService.Get(id);

            if (sourceHeader == null)
            {
                return NotFound();
            }

            _mongodbService.Remove(sourceHeader.Id);

            return NoContent();
        }
    }
}