using EgyptMart.Services.CMSAPI.Classes;
using EgyptMart.Services.CMSAPI.DTOS.Country;
using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace EgyptMart.Services.CMSAPI.Controllers.v2.store
{
    [Route("api/store/v2/Country")]
    [ApiController]

    public class CountryV2Controller : ControllerBase
    {
        IRepositoryWrapper _repositoryWrapper;
        public CountryV2Controller(IRepositoryWrapper repository)
        {

            _repositoryWrapper = repository;


        }



        [HttpPost("Create")]
        [EnableRateLimiting("AllRate")]
        public async Task<IActionResult> Create(CreateCountryDto model)
        {

            try
            {
                var response = await _repositoryWrapper.countryRepository.CreateCountry(model);

                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }

        }

        [HttpPut("Update")]
        [EnableRateLimiting("AllRate")]
        public async Task<IActionResult> Update(UpdateCountryDto model)
        {

            try
            {
                var response = await _repositoryWrapper.countryRepository.UpdateCountry(model);

                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }

        }


        [HttpGet("GetList/{LangId}")]
        [EnableRateLimiting("AllRate")]
        public async Task<IActionResult> GetList(byte LangId = 1)
        {

            try
            {
                var response = await _repositoryWrapper.countryRepository.GetList(LangId);

                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }

        }



        [HttpGet("GetByID/{CountryID}/{langID}")]
        [EnableRateLimiting("AllRate")]
        public async Task<IActionResult> GetByID(long CountryID, byte langID)
        {

            try
            {
                var response = await _repositoryWrapper.countryRepository.GetById(CountryID, langID);

                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }

        }

        [HttpPost("Translate")]
        [EnableRateLimiting("AllRate")]
        public async Task<IActionResult> Translate(CountryTranslateDto dto)
        {

            try
            {
                var response = await _repositoryWrapper.countryRepository.Translate(dto);

                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }

        }


    }
}
