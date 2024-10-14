using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using test.business.Abstract;
using test.entity.Dto.History;

namespace test.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        readonly IHistoryService _historyService;



        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var history = await _historyService.GetALL();

            return Ok(history);
        }
        [HttpGet("gethistory/{id}")]
        public async Task<ActionResult> Index([FromRoute]string id )
        {

            var history = await _historyService.GetById(id);

            return Ok(history);
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateHistoryDto model)
        {
            await _historyService.Create(model);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateHistoryDto model)
        {
           var history =  await _historyService.Update(model);    
            return Ok(history);
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _historyService.Delete(id);
            return Ok();
        }
    }
}
