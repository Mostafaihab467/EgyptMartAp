using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.ProductsAPI.Classes;
using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.Filters;
using EgyptMart.Services.ProductsAPI.IRepository;
using EgyptMart.Services.ProductsAPI.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.ProductsAPI.Controllers.v2.jpt
{
    [Route("api/jpt/v2/ProductsRatings")]
    [Authorize]
    [Signture]
    [ApiController]
    public class ProductsRatingsV2Controller : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public ProductsRatingsV2Controller(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductsRatingsDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRatingsRepository.CreateRating(model.ProductID, model.UserID, model.RatingScore, model.RatingTitle, model.LinkedPO, model.RatingDesc);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditProductsRatingsDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRatingsRepository.EditRating(model.RatingID, model.RatingScore, model.RatingTitle, model.RatingDesc);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpPut("Approve")]
        public async Task<IActionResult> Approve([FromBody] ApproveProductsRatingsDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRatingsRepository.ApproveRating(model.RatingID, model.ApprovalStatu, model.ActionBy);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpGet("GetProductReviews/{ProductID}/{RepType}")]
        public async Task<IActionResult> GetProductReviews([FromRoute] GetProductReviewDTO model, [MinValidator(1)] int PageNumber = 1, [Range(1, 100)] int SizePerPage = 50)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRatingsRepository.GetProductReviews(model.ProductID, model.RepType, PageNumber, SizePerPage);
                if (DataResult.Count > 0) return Ok(CustomResponse.Success(new { DataResult[0].TotalCount, Items = DataResult.Select(item => item.GetList()) }));
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }
    }
}
