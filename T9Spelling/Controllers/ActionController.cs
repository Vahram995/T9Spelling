using Microsoft.AspNetCore.Mvc;
using T9Spelling.Models.RequestModels;
using T9Spelling.Models.ResponseModels;
using T9Spelling.Services.Abstraction;

namespace T9Spelling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionController : ControllerBase
    {
        private readonly IT9SpellingService _t9SpellingService;

        public ActionController(IT9SpellingService t9SpellingService)
        {
            _t9SpellingService = t9SpellingService;
        }

        [HttpPost("convertToT9")]
        public async Task<ActionResult<T9SpellingResponseModel>> ConvertToT9([FromBody] T9SpellingRequestModel model)
        {
            var result = _t9SpellingService.ConvertToT9(model);
            return Ok(result);
        }
    }
}