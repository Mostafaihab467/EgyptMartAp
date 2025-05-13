using EgyptMart.Services.ReportingAPI.Classes;
using EgyptMart.Services.ReportingAPI.Filters;
using EgyptMart.Services.ReportingAPI.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.ReportingAPI.Controllers
{
    [Route("api/v2/Reporting/SupplierDashboard")]
    [Authorize]
    [Signture]
    [ApiController]
    public class SupplierV2Controller : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public SupplierV2Controller(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }




        [HttpGet("ViewCountByAge/{SupplierID}")]
        public async Task<IActionResult> Get(int SupplierID)
        {


            try
            {


                var result = await _repositoryWrapper.supplierDashBoardrpository.ViewCountByAgeget(SupplierID);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent); ;
                }

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }



        }

        //[HttpPut("TrendingProductInsert")]
        //public async Task<IActionResult> TrendingProductInsert(SDA_TrendingProductInsertDto dto)
        //{


        //    try
        //    {


        //        var result = await _repositoryWrapper.supplierDashBoardrpository.TrendingProductInsertDto(dto);

        //        return Ok(CustomResponse.Success(result));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(CustomResponse.Error(ex.Message));
        //    }



        //}


        [HttpGet("TrendingProduct_History_GetByLast4Months")]
        public async Task<IActionResult> SDA_TrendingProduct_History_GetByLast4Months(long productId, long ownerId)
        {


            try
            {


                var result = await _repositoryWrapper.supplierDashBoardrpository.TrendingProduct_History_GetByLast4Months(productId, ownerId);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }

        }


        [HttpGet("TrendingProduct_GetTopByOwner/{days}/{ownerId}/{top}/{LangID}")]
        public async Task<IActionResult> TrendingProduct_GetTopByOwner(int days, long ownerId, int top, byte LangID = 1)
        {
            try
            {
                var result = await _repositoryWrapper.supplierDashBoardrpository.GetTopTrendingProductsAsync(days, ownerId, top, LangID);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }

        }



        [HttpGet("TrendingCategory_GetByOwner/{days}/{ownerId}/{top}/{LangID}")]
        public async Task<IActionResult> SDA_TrendingCategory_GetByOwner(long ownerId, int days = 30, int top = 5, byte LangID = 1)
        {
            try
            {
                var result = await _repositoryWrapper.supplierDashBoardrpository.GetTrendingCategoriesByOwnerAsync(ownerId, days, top, LangID);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }

        }



        [HttpGet("GetTotalViewsByWeekdays/{supplierId}/{LangID}")]
        public async Task<IActionResult> GetTotalViewsByWeekdaysAsync(long supplierId, byte LangID)
        {
            try
            {
                var result = await _repositoryWrapper.supplierDashBoardrpository.GetTotalViewsByWeekdaysAsync(supplierId, LangID);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }

        }

        [HttpGet("GetTotalViewsByRegister/{OwnerID}/{days}/{top}")]
        public async Task<IActionResult> GetTotalViewsByRegisterAsync(long OwnerID, int days, int top = 5)
        {
            try
            {
                var result = await _repositoryWrapper.supplierDashBoardrpository.GetTotalViewsByRegisterAsync(OwnerID, days, top);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }

        }



        [HttpGet("GetTotalProductViewByGender/{ownerId}")]
        public async Task<IActionResult> GetTotalProductViewByGenderAsync(long ownerId)
        {
            try
            {
                var result = await _repositoryWrapper.supplierDashBoardrpository.GetTotalProductViewByGenderAsync(ownerId);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }

        }


        [HttpGet("GetTopUsersView/{supplierId}/{top}/{lastDays}")]
        public async Task<IActionResult> GetTopUsersViewAsync(long supplierId, int top = 5, int lastDays = 3)
        {
            try
            {
                var result = await _repositoryWrapper.supplierDashBoardrpository.GetTopUsersViewAsync(supplierId, top, lastDays);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }

        }
        [HttpGet("GetTopRatedProducts/{ownerId}/{top}")]
        public async Task<IActionResult> GetTopRatedProductsAsync(long ownerId, int top = 5, byte langID = 1)

        {
            try
            {
                var result = await _repositoryWrapper.supplierDashBoardrpository.GetTopRatedProductsAsync(ownerId, top, langID);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }

        }



        //[HttpPut("update-views/{productId}")]
        //public async Task<IActionResult> UpdateProductViews(long productId)   
        //    {
        //        try
        //        {
        //            var result = await _repositoryWrapper.supplierDashBoardrpository.UpdateProductViewCountAsync(productId);

        //            return Ok(CustomResponse.Success(result));
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(CustomResponse.Error(ex.Message));
        //        }
        //    }

        [HttpGet("GetProductViewCountByDaysAsync/{productId}/{days}")]
        public async Task<IActionResult> GetProductViewCountByDaysAsync(long productId, int days)
        {
            try
            {
                var result = await _repositoryWrapper.supplierDashBoardrpository.GetProductViewCountByDaysAsync(productId, days);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }
        [HttpGet("GetTopReviewedProducts/{ownerId}/{orderByDesc}/{LangID}")]
        public async Task<IActionResult> GetTopReviewedProductsAsync(long ownerId, bool orderByDesc, byte LangID = 1)
        {
            try
            {
                var result = await _repositoryWrapper.supplierDashBoardrpository.GetTopReviewedProductsAsync(ownerId, orderByDesc, LangID);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }


        [HttpGet("GetProductViewCountByLastDays/{ownerId}/{days}")]
        public async Task<IActionResult> GetProductViewCountByLastDaysAsync(long ownerId, int days)
        {
            try
            {
                var result = await _repositoryWrapper.supplierDashBoardrpository.GetProductViewCountByLastDaysAsync(ownerId, days);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }



        [HttpGet("GetCategoryProductCounts/{ownerId}/{langId}")]
        public async Task<IActionResult> GetCategoryProductCountsAsync(long ownerId, byte langId = 1)
        {
            try
            {
                var result = await _repositoryWrapper.supplierDashBoardrpository.GetCategoryProductCountsAsync(ownerId, langId);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }



        [HttpGet("GetAdsSubscriptionStatus/{userId}")]
        public async Task<IActionResult> GetAdsSubscriptionStatusAsync(long userId)
        {
            try
            {
                var result = await _repositoryWrapper.supplierDashBoardrpository.GetAdsSubscriptionStatusAsync(userId);

                return Ok(CustomResponse.Success(result));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }




    }
}
