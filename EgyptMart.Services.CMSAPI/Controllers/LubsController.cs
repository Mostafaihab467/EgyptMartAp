using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.CMSAPI.Controllers
{
    [Route("api/v1/Lups")]
    [ApiController]
    public class LubsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public LubsController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet("LangList")]
        public async Task<IActionResult> GetLangList()
        {
            try
            {
                var dataResult = await _repositoryWrapper.lubsRepository.GetLubsAsync();
                return Ok(new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpPost("TranslateTo")]
        public async Task<IActionResult> TranslateTo(byte LangID)
        {

            try
            {
                var dataResult = await _repositoryWrapper.lubsRepository.TranslateTo(LangID);
                return Ok(new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }
    }
}

