using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.CMSAPI.Controllers
{
    [Route("api/v1/Widgets_Front_ProductYouMayLike")]
    [ApiController]
    public class Widgets_Front_ProductYouMayLike : ControllerBase
    {

        private readonly IRepositoryWrapper _repositoryWrapper;

        public Widgets_Front_ProductYouMayLike(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet("ProductYouMayLike")]
        public async Task<IActionResult> ProductYouMayLike(byte langID)
        {
            try
            {
                var dataResult = await _repositoryWrapper.productYouMayLikeTRepository.GetProductsYouMayLikeAsync(langID);
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

                return BadRequest(new
                {
                    success = false,
                    ResponseArMsg = "خطأ أثناء الإنشاء",
                    ResponseEngMsg = "An error occurred while creating the widget.",
                    error = ex.Message
                });
            }
        }
    }
}
