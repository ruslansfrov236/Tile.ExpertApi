using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using test.business.Abstract;
using test.entity.Dto.TagsCheckbox;

namespace test.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsCheckboxController : ControllerBase
    {
        readonly private ITagsCheckboxService _tagsCheckboxService;

        public TagsCheckboxController(ITagsCheckboxService tagsCheckboxService) => _tagsCheckboxService = tagsCheckboxService;

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var tagsCheckbox = await _tagsCheckboxService.GetAll();
            return Ok(tagsCheckbox);
        }
        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var tagsCheckbox = await _tagsCheckboxService.GetById(id);

            return Ok(tagsCheckbox);
        }

        [HttpPost]
        public async Task<IActionResult> Create( CreateTagsCheckboxDto model)
        {
            await _tagsCheckboxService.Create( model);

            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPatch("edit")]
        public async Task<IActionResult> Update ( UpdateTagsCheckboxDto model)
        {
            await _tagsCheckboxService.Update(model);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _tagsCheckboxService.Delete(id);
            return Ok();
        }
    }
}
