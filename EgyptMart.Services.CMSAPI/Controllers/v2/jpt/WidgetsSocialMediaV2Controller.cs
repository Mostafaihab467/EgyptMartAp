using EgyptMart.Services.CMSAPI.DTOS.WidgetSocialMedia;
using EgyptMart.Services.CMSAPI.Filters;
using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.CMSAPI.Controllers.v2.jpt
{
    [Route("api/jpt/v2/WidgetsSocialMedia")]
    [Authorize]
    [Signture]
    [ApiController]
    public class WidgetsSocialMediaV2Controller : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILogger<WidgetsSocialMediaController> _logger;

        public WidgetsSocialMediaV2Controller(IRepositoryWrapper repositoryWrapper, ILogger<WidgetsSocialMediaController> logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Widgets_SocialMedia_CreateDto widgets_SocialMedia)
        {
            try
            {
                if (widgets_SocialMedia == null)
                {
                    return BadRequest(new
                    {
                        success = false,
                        ResponseArMsg = "بيانات غير صالحة",
                        ResponseEngMsg = "Invalid data",
                    });
                }

                var dataResult = await _repositoryWrapper.widgets_SocialMedia.Create(widgets_SocialMedia);
                return Ok(new
                {
                    success = true,
                    ResponseArMsg = "تم الإنشاء بنجاح",
                    ResponseEngMsg = "Created successfully",
                    data = dataResult
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the social media widget.");
                return BadRequest(new
                {
                    success = false,
                    ResponseArMsg = "خطأ أثناء الإنشاء",
                    ResponseEngMsg = "An error occurred while creating the widget.",
                    error = ex.Message
                });
            }
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(WidgetsSocialMediaChangeStatusDto widgetsSocialMediaChange)
        {
            try
            {
                var dataResult = await _repositoryWrapper.widgets_SocialMedia.ChangeStatus(widgetsSocialMediaChange);
                return Ok(new
                {
                    success = true,
                    ResponseArMsg = "تم تغيير الحالة بنجاح",
                    ResponseEngMsg = "Status changed successfully",
                    data = dataResult
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while changing the widget's status.");
                return BadRequest(new
                {
                    success = false,
                    ResponseArMsg = "خطأ أثناء تغيير الحالة",
                    ResponseEngMsg = "An error occurred while changing the status.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(WidgetsSocialMediaEditDto widgetsSocialMediaEditDto)
        {
            try
            {
                var dataResult = await _repositoryWrapper.widgets_SocialMedia.EditWidgetAsync(widgetsSocialMediaEditDto);
                return Ok(new
                {
                    success = true,
                    ResponseArMsg = "تم التعديل بنجاح",
                    ResponseEngMsg = "Edited successfully",
                    data = dataResult
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing the social media widget.");
                return BadRequest(new
                {
                    success = false,
                    ResponseArMsg = "خطأ أثناء التعديل",
                    ResponseEngMsg = "An error occurred while editing the widget.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(int reptype)
        {
            try
            {
                var dataResult = await _repositoryWrapper.widgets_SocialMedia.GetWidgetsSocialMediaAsync(reptype);
                return Ok(new
                {
                    success = true,
                    ResponseArMsg = "تم استرجاع البيانات بنجاح",
                    ResponseEngMsg = "Data retrieved successfully",
                    data = dataResult
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the social media widgets.");
                return BadRequest(new
                {
                    success = false,
                    ResponseArMsg = "خطأ أثناء استرجاع البيانات",
                    ResponseEngMsg = "An error occurred while retrieving the data.",
                    error = ex.Message
                });
            }
        }
    }
}
