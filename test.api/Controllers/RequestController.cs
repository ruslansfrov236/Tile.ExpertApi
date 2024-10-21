using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using test.business.Abstract;
using test.entity.Dto.Request;

namespace test.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        readonly private IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;   
        }
        [HttpGet]   
        public async Task<ActionResult> Index()
        {
            var request = await _requestService.GetAll();
            return Ok(request);
        }

        [HttpGet("request/{id}")]
        public async Task<IActionResult> Index([FromRoute]string id)
        {
            var request = await _requestService.GetById(id);

            return Ok(request);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateRequestDto model)
        {
            await _requestService.Create(model);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateRequestDto model)
        {
            await _requestService.Update(model);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete ([FromRoute]string id)
        {
            await _requestService.Delete(id);

            return Ok();
        }
    }
}
