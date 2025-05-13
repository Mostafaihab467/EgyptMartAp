using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.ProductsAPI.Classes;
using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.IRepository;
using EgyptMart.Services.ProductsAPI.Validations;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.ProductsAPI.Controllers
{
    [Route("api/v1/ProductsFilter")]
    [ApiController]
    public class ProductsFilterController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public ProductsFilterController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        [HttpGet("ByCategory/{OwnerID}/{CategoryID}/{RepType}")]
        public async Task<IActionResult> ByCategory([FromRoute] GetFilteredProductsByCategory model, [Range(0, 255)] byte LangID = 1, [MinValidator(1)] int PageNumber = 1, [Range(1, 100)] int SizePerPage = 50)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRepository.GetFilteredProductsByCategory(model.OwnerID, model.RepType, model.CategoryID, LangID, PageNumber, SizePerPage);
                if (DataResult.Count > 0) return Ok(CustomResponse.Success(new { DataResult[0].TotalCount, Items = DataResult.Select(item => item.GetList()) }));
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpGet("ByTitle/{ProductTitle}")]
        public async Task<IActionResult> ByTitle([FromRoute] string ProductTitle, [Range(0, 255)] byte LangID = 1, [MinValidator(1)] int PageNumber = 1, [Range(1, 100)] int SizePerPage = 50)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRepository.GetFilteredProductsByTitle(ProductTitle, LangID, PageNumber, SizePerPage);
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
