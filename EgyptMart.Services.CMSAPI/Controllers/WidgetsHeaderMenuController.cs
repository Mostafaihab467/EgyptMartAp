using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.DTOS.WidgetsHeaderMenu;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.CMSAPI.Controllers
{
    [ApiController]
    [Route("api/v1/WidgetsHeaderMenu")]
    public class WidgetsHeaderMenuController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILogger<WidgetsHeaderMenuController> _logger;

        public WidgetsHeaderMenuController(IRepositoryWrapper repositoryWrapper, ILogger<WidgetsHeaderMenuController> logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] WidgetsHeaderMenuCreateDto widgetsHeaderMenuCreateDto)
        {
            if (widgetsHeaderMenuCreateDto == null)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                var dataResult = await _repositoryWrapper.widgets_HeaderMenu_Repository.CreateHeaderMenuAsync(widgetsHeaderMenuCreateDto);
                _logger.LogInformation("Successfully created header menu: {Data}", widgetsHeaderMenuCreateDto);
                return Ok(dataResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating header menu: {Error}", ex.Message);
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Widgets_HeaderMenu_Edit([FromBody] WidgetsHeaderMenuEditDto widgetsHeaderMenuEdit)
        {
            if (widgetsHeaderMenuEdit == null)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                var dataResult = await _repositoryWrapper.widgets_HeaderMenu_Repository.EditHeaderMenuAsync(widgetsHeaderMenuEdit);
                _logger.LogInformation("Successfully edited header menu: {Data}", widgetsHeaderMenuEdit);
                return Ok(dataResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing header menu: {Error}", ex.Message);
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] WidgetsHeaderMenueChangeStatusDto widgetsHeaderMenueChange)
        {
            if (widgetsHeaderMenueChange == null)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                var dataResult = await _repositoryWrapper.widgets_HeaderMenu_Repository.ChangeStatus(widgetsHeaderMenueChange);
                _logger.LogInformation("Successfully changed status: {Data}", widgetsHeaderMenueChange);
                return Ok(dataResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while changing status: {Error}", ex.Message);
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpGet("GetTopLevel/{repType}/{langid}")]
        public async Task<IActionResult> GetTopLevel(byte repType, short langid)
        {
            try
            {
                var dataResult = await _repositoryWrapper.widgets_HeaderMenu_Repository.GetTopLevelHeaderMenusAsync(repType, langid);
                _logger.LogInformation("Successfully fetched top-level header menus for repType: {RepType}, langID: {LangID}", repType, langid);
                return Ok(dataResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching top-level header menus: {Error}", ex.Message);
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpGet("GetChild/{repType}/{langid}/{parentID}")]
        public async Task<IActionResult> GetChild(byte repType, short langid, long parentID)
        {
            if (parentID <= 0)
            {
                return BadRequest("Invalid parent ID");
            }

            try
            {
                var model = new WidgetsHeaderMenuGetChildDtos
                {
                    RepType = repType,
                    LangID = langid,
                    ParentID = parentID
                };

                var dataResult = await _repositoryWrapper.widgets_HeaderMenu_Repository.GetChildWidgetsHeaderMenuAsync(model);
                _logger.LogInformation("Successfully fetched child header menus for ParentID: {ParentID}", parentID);
                return Ok(dataResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching child header menus: {Error}", ex.Message);
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpPost("Translate")]
        public async Task<IActionResult> Translate([FromBody] HeaderMenuTranslateDTO model)
        {
            try
            {
                var dataResult = await _repositoryWrapper.widgets_HeaderMenu_Repository.TranslateHeaderMenuItem(model.BasID, model.MenuItemTitle, model.LangID);

                return Ok(new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpGet("GetByID/{MenuItemID}")]
        public async Task<IActionResult> GetByID(long MenuItemID)
        {
            try
            {

                //Widgets_HeaderMenu_GetByID
                var dataResult = await _repositoryWrapper.widgets_HeaderMenu_Repository.HeaderMenu_GetByID(MenuItemID);

                return Ok(new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }

        [HttpGet("GetByLang/{MenuItemID}/{LangID}")]
        public async Task<IActionResult> GetByLang(long MenuItemID, byte LangID)
        {

            //Widgets_HeaderMenu_GetByLang
            try
            {
                var dataResult = await _repositoryWrapper.widgets_HeaderMenu_Repository.GetByLang(MenuItemID, LangID);
                return Ok(new { success = true, data = dataResult });

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
