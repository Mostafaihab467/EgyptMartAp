using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.DTOS.CMS;
using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.CMSAPI.Controllers
{
    [Route("api/v1/Business")]
    [ApiController]
    public class BusinessController(IRepositoryWrapper _repositoryWrapper, ILogger<CompanyProfileController> _logger) : ControllerBase
    {

        [HttpPut("CreatebussnissTranslateType")]
        public async Task<IActionResult> CreatebussnissType(BusinessTypeTranslationDto businessTypeTranslationDto)
        {

            try
            {
                var dataResult = await _repositoryWrapper.BusinessRepository.CreateBuisnessType(businessTypeTranslationDto);

                return Ok(new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing supplier.");
                return StatusCode(500, new { success = false, error = ex.Message });
            }

        }

        [HttpGet("bussnissGetById/{BusinessTypeID}/{LangID}")]
        public async Task<IActionResult> BussnissGetById(short BusinessTypeID, byte LangID)
        {

            try
            {
                var dataResult = await _repositoryWrapper.BusinessRepository.GetBusinessTypeTranslationAsync(BusinessTypeID, LangID);

                return Ok(new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing supplier.");
                return StatusCode(500, new { success = false, error = ex.Message });
            }

        }

        [HttpGet("TransLatedBussnissGetList/{LangID}")]
        public async Task<IActionResult> BussnissGetList(byte LangID)
        {

            try
            {
                var dataResult = await _repositoryWrapper.BusinessRepository.GetBuissnessTypeByList(LangID);

                return Ok(new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing supplier.");
                return StatusCode(500, new { success = false, error = ex.Message });
            }

        }

        [HttpGet("BussnissTypeChangeStatus/{BusinessTypeID}/{isActive}")]
        public async Task<IActionResult> BussnissTypeChangeStatus(byte BusinessTypeID, bool isActive)
        {

            try
            {
                var dataResult = await _repositoryWrapper.BusinessRepository.BussnissTypeChangeStatus(BusinessTypeID, isActive);

                return Ok(new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing supplier.");
                return StatusCode(500, new { success = false, error = ex.Message });
            }

        }

        [HttpPost("BussnissTypeCreate")]
        public async Task<IActionResult> BussnissTypeCreate(buissnessTypeCreateDto model)
        {

            try
            {
                var dataResult = await _repositoryWrapper.BusinessRepository.BussnissTypeCreate(model);

                return Ok(new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing supplier.");
                return StatusCode(500, new { success = false, error = ex.Message });
            }

        }
    }
}
