using EgyptMart.Services.CMSAPI.Filters;
using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.CMSAPI.Controllers.v2.jpt
{
    [Route("api/jpt/v2/StoreFrontWidgets")]
    [Authorize]
    [Signture]
    [ApiController]
    public class StoreFrontWidgetsV2Controller : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;


        public StoreFrontWidgetsV2Controller(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }


        [HttpGet("TrendingProducts/{langID}")]
        public async Task<IActionResult> TrendingProducts(byte langID)
        {


            try
            {
                var dataResult = await _repositoryWrapper.trendingProductRepository.GetTrendingProducts(langID);
                return Ok(dataResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }





        [HttpGet("Widgets_Front_SpecialOffers/{langID}")]
        public async Task<IActionResult> SpecialOffers(byte langID)
        {


            try
            {
                var dataResult = await _repositoryWrapper.trendingProductRepository.GetSpecialOffers(langID);
                return Ok(dataResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }


        [HttpGet("SuccessPartners")]
        public async Task<IActionResult> SuccessPartners()
        {


            try
            {
                var dataResult = await _repositoryWrapper.trendingProductRepository.SuccessPartners();
                return Ok(dataResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, error = ex.Message });
            }
        }






    }
}
