using Microsoft.AspNetCore.Mvc;
using System.Net;
using test.business.Abstract;
using test.entity.Dto.Tags;
using test.entity.Entities;

namespace test.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {

        readonly private ITagsService _tagsService;

        public TagsController(ITagsService tagsService)
        {
            _tagsService = tagsService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var _tags = await _tagsService.GetAsync();
            if (_tags == null) return NotFound();
            return Ok(_tags);
        }
        [HttpGet("tagsIndex/{Id}")]
        public async Task<IActionResult> Index([FromRoute]string Id)
        {
            var tags = await _tagsService.GetAllByIdAsync(Id);
            if (tags == null) return NotFound();
            return Ok(tags);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateTagsDto model)
        {
            await _tagsService.Create(model);

            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody]UpdateTagsDto model)
        {
            var _tags = await _tagsService.Update(model);

            return Ok(_tags);
        }

        [HttpDelete("delete/{id}")]
        public  async Task<IActionResult> Delete([FromRoute]string id)
        {
           
          var _tags =  await _tagsService.DeleteAsync(id);
            return Ok(_tags);
        }


        [HttpGet("filter")]
        public async Task<IActionResult> Search(string search)
        {

            var filter = await _tagsService.GetFilter(search);

            return Ok(filter);  
        }
    }
}
