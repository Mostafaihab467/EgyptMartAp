using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace EgyptMart.Services.CMSAPI.Controllers.v2.store
{
    [Route("api/store/v2/Lubs")]
    [ApiController]

    public class LubsV2Controller : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public LubsV2Controller(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [EnableRateLimiting("AllRate")]
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

        [EnableRateLimiting("AllRate")]
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

