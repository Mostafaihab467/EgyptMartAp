using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.CMSAPI.Classes;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace EgyptMart.Services.CMSAPI.Controllers.v2.store
{
    [Route("api/store/v2/WishList")]
    [ApiController]
    //[EnableRateLimiting("IpRateLimit")]
    public class WishListV2Controller(IRepositoryWrapper repositorys) : ControllerBase
    {




        [EnableRateLimiting("AllRate")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([Required][MinValidator(1)] Int64 UserID, [Required][MinValidator(1)] Int64 ProductID)
        {
            try
            {
                var DataResult = await repositorys.WishListRepository.Create(ProductID, UserID);
                if (DataResult == null)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpPost("Remove")]
        public async Task<IActionResult> Remove([Required][MinValidator(1)] Int64 ProductID, [Required][MinValidator(1)] long UserID)
        {
            try
            {
                var DataResult = await repositorys.WishListRepository.Remove(ProductID, UserID);
                if (DataResult == null)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpGet("MyWishList")]
        public async Task<IActionResult> MyWishList([Required][MinValidator(1)] Int64 UserID, [Required][Range(1, 255)] byte LangID)
        {
            try
            {
                var DataResult = await repositorys.WishListRepository.GetMyWishList(UserID, LangID);
                if (DataResult == null)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }
    }
}
