using EgyptMart.Services.ProductsAPI.Classes;
using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace EgyptMart.Services.ProductsAPI.Controllers.v2.store
{
    [Route("api/store/v2/Attribute")]
    [ApiController]
    public class AttributeV2Controller(IRepositoryWrapper repoWrapper) : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper = repoWrapper;

        [EnableRateLimiting("AllRate")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateAttributeDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.AttributeRepository.CreateAttribute(model.AttributeTitle, model.AttributeTypeID, model.ShowAcrossAllCategory, model.RcBy);
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
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] EdiAttributeDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.AttributeRepository.EditAttribute(model.AttributeID, model.AttributeTitle, model.AttributeTypeID, model.ShowAcrossAllCategory);
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
        public async Task<IActionResult> Translate([FromBody] TranslateAttributeDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.AttributeRepository.TranslateAttribute(model);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ في انشاء الترجمة"));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpPost("SetLink/{AttributeID}/{CategoryID}")]
        public async Task<IActionResult> SetLink([FromRoute] long AttributeID, [FromRoute] long CategoryID)
        {
            try
            {
                var DataResult = await _repoWrapper.AttributeRepository.SetLinkAttribute(AttributeID, CategoryID);
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
        [HttpPut("ChangeStatus/{AttributeID}/{IsActive}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] long AttributeID, [FromRoute] bool IsActive)
        {
            try
            {
                var DataResult = await _repoWrapper.AttributeRepository.ChangeStatusAttribute(AttributeID, IsActive);
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
        [HttpDelete("BreakLink/{LinkID}")]
        public async Task<IActionResult> BreakLink([FromRoute] long LinkID)
        {
            try
            {
                var DataResult = await _repoWrapper.AttributeRepository.BreakLinkAttribute(LinkID);
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
        [HttpGet("GetTranslateByID/{AttributeID}/{LangID}")]
        public async Task<IActionResult> GetTranslateByID(long AttributeID, byte LangID)
        {
            try
            {
                var DataResult = await _repoWrapper.AttributeRepository.GetProductAttributeTrabslatedById(AttributeID, LangID);
                if (DataResult.Count < 0 || DataResult.FirstOrDefault() == null)
                    return Ok(CustomResponse.Success(data: new List<object>()));

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpGet("GetLinkMatrix")]
        public async Task<IActionResult> GetList(int AttributID)
        {
            try
            {
                var DataResult = await _repoWrapper.AttributeRepository.GetLinkMatrix(AttributID);
                if (DataResult.Count == 0)
                    return Ok(CustomResponse.Success(data: "No Data Found"));

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var DataResult = await _repoWrapper.AttributeRepository.GetList();
                if (DataResult.Count == 0)
                    return Ok(CustomResponse.Success(data: "No Data Found"));

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }
    }
}
