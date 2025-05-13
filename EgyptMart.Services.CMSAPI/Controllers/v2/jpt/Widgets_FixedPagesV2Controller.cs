using EgyptMart.Services.CMSAPI.DTOS.Widgets_FixedPages;
using EgyptMart.Services.CMSAPI.Filters;
using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.CMSAPI.Controllers.v2.jpt
{
    [Route("api/jpt/v2/Widgets_FixedPages")]
    [Authorize]
    [Signture]
    [ApiController]
    public class Widgets_FixedPagesV2Controller : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public Widgets_FixedPagesV2Controller(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(FixedPages_CreateDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = ModelState.ErrorCount });

            try
            {
                var result = await _repositoryWrapper.widgets_FixedPagesRepository.Create(model);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(FixedPages_EditDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = ModelState.ErrorCount });

            try
            {
                var result = await _repositoryWrapper.widgets_FixedPagesRepository.Edit(model);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(FixedPages_ChangeStatusDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = ModelState.ErrorCount });

            try
            {
                var result = await _repositoryWrapper.widgets_FixedPagesRepository.ChangeStatus(model);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpGet("GetSingleItem/{GetByID}")]
        public async Task<IActionResult> GetSingleItem(int GetByID)
        {
            try
            {
                var result = await _repositoryWrapper.widgets_FixedPagesRepository.GetByID(GetByID);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(byte LangID = 1)
        {
            try
            {
                var result = await _repositoryWrapper.widgets_FixedPagesRepository.GetList(LangID);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }



        [HttpPost("Translate")]
        public async Task<IActionResult> Translate(WidgetsFixedPagesTranslateDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = ModelState.ErrorCount });

            try
            {
                var result = await _repositoryWrapper.widgets_FixedPagesRepository.Translate(model);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpGet("GetByLang/{BaseID}/{LangeID}")]
        public async Task<IActionResult> GetByLang(int BaseID, byte LangeID)
        {
            try
            {
                var result = await _repositoryWrapper.widgets_FixedPagesRepository.GetByLang(BaseID, LangeID);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }
    }
}
