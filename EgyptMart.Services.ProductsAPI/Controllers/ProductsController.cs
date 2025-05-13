using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.ProductsAPI.Classes;
using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.IRepository;
using EgyptMart.Services.ProductsAPI.Validations;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.ProductsAPI.Controllers
{
    [Route("api/v1/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public ProductsController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] InsertProductListDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRepository.Create(model.OwnerID, model.ProductTitle, model.CategoryID, model.SEOKey, model.SKU, model.GSCode, model.ShortDesc, model.FullDesc, model.MinimumOrder, model.CostBefore, model.CostAfter, model.StockStatus, model.StockSimpleCounter);
                if (DataResult == null)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));

                //if (DataResult == 0)
                //    throw new Exception();


                //return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }


        [HttpPost("Translate")]
        public async Task<IActionResult> Translate([FromBody] TranslateProducttDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRepository.Translate(model.ProductsID, model.LangID, model.ProductTitle, model.SEOKey, model.ShortDesc, model.FullDesc);
                if (DataResult < 1)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));

                //if (DataResult == 0)
                //    throw new Exception();


                //return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] UpdateProductListDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var DataResult = await _repoWrapper.ProductsRepository.Edit(model.ProductsID, model.ProductTitle, model.CategoryID, model.SEOKey, model.SKU, model.GSCode, model.ShortDesc, model.FullDesc, model.MinimumOrder, model.CostBefore, model.CostAfter);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpGet("GetProduct/{ProductsID}")]
        public async Task<IActionResult> GetProduct([FromRoute] long ProductsID)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRepository.GetProductByID(ProductsID);

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpGet("GetOwnerProducts/{OwnerID}/{RepType}")]
        public async Task<IActionResult> GetOwnerProducts([FromRoute] GetOwnerProductsDTO model, [MinValidator(1)] int PageNumber = 1, [Range(1, 100)] int SizePerPage = 50)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRepository.GetMyProduct(model.OwnerID, model.RepType, PageNumber, SizePerPage);

                if (DataResult.Count > 0) return Ok(CustomResponse.Success(new { DataResult[0].TotalCount, Items = DataResult.Select(item => item.GetList()) }));

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpGet("GetOwnerProductsByCategory/{OwnerID}/{RepType}/{CategoryID}")]
        public async Task<IActionResult> GetOwnerProductsByCategory([FromRoute] GetOwnerProductsByCategoryDTO model, [MinValidator(1)] int PageNumber = 1, [Range(1, 100)] int SizePerPage = 50)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRepository.GetMyProductByCategoryID(model.OwnerID, model.RepType, model.CategoryID, PageNumber, SizePerPage);
                if (DataResult.Count > 0) return Ok(CustomResponse.Success(new { DataResult[0].TotalCount, Items = DataResult.Select(item => item.GetList()) }));
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpGet("ChangeStatus/{ProductsID}/{NewProductStatus}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] ChangeStatusProductDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRepository.ChangeStatus(model.ProductsID, model.NewProductStatus);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpGet("ChangeStockStatus/{ProductsID}/{StockStatus}/{StockSimpleCounter}")]
        public async Task<IActionResult> ChangeStockStatus([FromRoute] ChangeStockStatusProductDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRepository.ChangeStockStatus(model.ProductsID, model.StockStatus, model.StockSimpleCounter);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpGet("GetProductByLang/{ProductID}")]
        public async Task<IActionResult> GetProduct([FromRoute] long ProductID, [Required] byte LangID)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRepository.GetProductByLang(ProductID, LangID);

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpGet("GetMyProductTranslated/{OwnerID}/{RepType}/{LangID}")]
        public async Task<IActionResult> GetMyProductTranslated(long OwnerID, byte RepType, byte LangID, [MinValidator(1)] int PageNumber = 1, [Range(1, 100)] int SizePerPage = 50)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductsRepository.GetMyProductTranslated(OwnerID, RepType, LangID, PageNumber, SizePerPage);
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
