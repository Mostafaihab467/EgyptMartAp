using EgyptMart.Services.CMSAPI.DTOS.FooterLink;
using EgyptMart.Services.CMSAPI.Filters;
using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.CMSAPI.Controllers.v2.jpt
{
    [Route("api/jpt/v2/WidgetsFooterLinks")]
    [Authorize]
    [Signture]
    [ApiController]
    public class WidgetsFooterLinksV2Controller : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public WidgetsFooterLinksV2Controller(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] WidgetsFooterLinksCreateRequestDto widgetsHeaderMenuCreateDto)
        {
            if (widgetsHeaderMenuCreateDto == null)
            {
                return BadRequest(new { success = false, error = "Invalid data" });
            }

            try
            {
                var dataResult = await _repositoryWrapper.footerLinksRepository.Create(widgetsHeaderMenuCreateDto);
                return StatusCode(200, new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> WidgetsFooterLinks([FromBody] FooterLinkEditDto model)
        {
            try
            {
                var dataResult = await _repositoryWrapper.footerLinksRepository.Widgets_FooterLinks_Edit(model);
                return StatusCode(200, new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] FooterLinkStatusDto model)
        {
            try
            {
                var dataResult = await _repositoryWrapper.footerLinksRepository.ChangeFooterLinkStatus(model);
                return StatusCode(200, new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpGet("GetItem/{FooterItemID}")]
        public async Task<IActionResult> GetItem(int FooterItemID)
        {
            try
            {
                var dataResult = await _repositoryWrapper.footerLinksRepository.GetFooterLinkByID(FooterItemID);
                return StatusCode(200, new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var dataResult = await _repositoryWrapper.footerLinksRepository.GetAllFooterLinks();
                return StatusCode(200, new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpPost("Translate")]
        public async Task<IActionResult> Translate([FromBody] FooterLinkTranslateDto footerLinkTranslateDto)
        {
            try
            {
                var dataResult = await _repositoryWrapper.footerLinksRepository.TranslateFooterLink(footerLinkTranslateDto);
                return StatusCode(200, new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpGet("GetListFront/{LangID}")]
        public async Task<IActionResult> GetListFront(byte LangID)
        {
            try
            {
                var dataResult = await _repositoryWrapper.footerLinksRepository.GetFront(LangID);
                return StatusCode(200, new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpGet("GetTranlated/{ColumnIndex}/{LangID}")]
        public async Task<IActionResult> GetTranslated(byte ColumnIndex, byte LangID)
        {
            try
            {
                var dataResult = await _repositoryWrapper.footerLinksRepository.GetTranslated(ColumnIndex, LangID);
                return StatusCode(200, new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }


        [HttpGet("GetChild/{FooterItemID}/{LangID}")]
        public async Task<IActionResult> GetChild(int FooterItemID, byte LangID = 1)
        {
            try
            {
                var dataResult = await _repositoryWrapper.footerLinksRepository.GetChild(FooterItemID, LangID);
                return StatusCode(200, new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }
    }
}
