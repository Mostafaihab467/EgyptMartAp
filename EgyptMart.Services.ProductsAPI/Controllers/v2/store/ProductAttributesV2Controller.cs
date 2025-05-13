using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.ProductsAPI.Classes;
using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace EgyptMart.Services.ProductsAPI.Controllers.v2.store
{
    [Route("api/store/v2/ProductAttributes")]
    [ApiController]

    public class ProductAttributesV2Controller(IRepositoryWrapper repoWrapper) : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper = repoWrapper;
        [EnableRateLimiting("AllRate")]
        [HttpPost("PullInitial")]
        public async Task<IActionResult> PullInitial(Int64 ProductID)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductAttributeRepository.PullInitial(ProductID);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProductAttributesDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductAttributeRepository.CreateAttributes(model.ProductID, model.AttributeID, model.Value, model.LangID, model.DisplayOrder);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpPost("Translate")]
        public async Task<IActionResult> Translate([FromBody] TranslateProductAttributeValueDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductAttributeRepository.TranslateAttributeValue(model);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpGet("GetByLang/{ProductID}")]
        public async Task<IActionResult> GetByLang([FromRoute] long ProductID, [Required] byte LangID)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductAttributeRepository.GetAttributesByLang(ProductID, LangID);
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }


        [EnableRateLimiting("AllRate")]
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] EditProductAttributesDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductAttributeRepository.EditAtributes(model.LinkID, model.Value, model.DisplayOrder);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpDelete("Delete/{LinkID}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductAttributesDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductAttributeRepository.DeleteAttributes(model.LinkID);
                if (DataResult == 0)
                    throw new InvalidOperationException();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                if (typeof(InvalidOperationException) == ex.GetType())
                    return BadRequest(CustomResponse.Error("LinkID not found", "لا يوجد LinkID"));
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpGet("Get/{ProductID}")]
        public async Task<IActionResult> Get([FromRoute] long ProductID)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductAttributeRepository.GetAttributes(ProductID);

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }
    }
}
