using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.AdsManagmentAPI.Classes;
using EgyptMart.Services.AdsManagmentAPI.DTO;
using EgyptMart.Services.AdsManagmentAPI.IRepository;
using EgyptMart.Services.AdsManagmentAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.AdsManagmentAPI.Controllers
{
    [Route("api/v1/Ads/ManageSubscriptions")]
    [ApiController]
    public class ManageSubscriptionsController(IRepositoryWrapper repositoryWrapper) : ControllerBase
    {
        [HttpGet("AdsLocationList")]
        public async Task<IActionResult> AdsLocationList()
        {
            try
            {
                List<AdsLocationsListModel> adsLupLocationsLists = await repositoryWrapper.ManageSubscriptionsRepository.GetAdsLubLocationsList();

                return Ok(CustomResponse.Success(adsLupLocationsLists));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateSubscriptionDTO dto)
        {

            try
            {
                // returned > 0 then OK
                // returned <= 0 then Throw Error
                var createdReponse = await repositoryWrapper.ManageSubscriptionsRepository.CreateSubscription(dto);
                if (createdReponse.Count <= 0) return BadRequest(CustomResponse.Error("Not created", "لم يتم الانشاء"));

                return Ok(CustomResponse.Success(createdReponse.FirstOrDefault()!));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }

        [HttpPut("Edit/{AdsPlanId}")]
        public async Task<IActionResult> Edit(long AdsPlanId, [FromBody] EditSubscriptionDTO dto)
        {
            if (AdsPlanId == 0) return BadRequest(CustomResponse.Error($"Enter {nameof(AdsPlanId)}", $"ادخل {nameof(AdsPlanId)}"));
            try
            {
                var reponse = await repositoryWrapper.ManageSubscriptionsRepository.EditSubscription(AdsPlanId, dto);

                if (reponse == 0) return BadRequest(CustomResponse.Error("Edit not changed", "لم يحدث التعديل "));

                return Ok(CustomResponse.Success(reponse));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }

        [HttpGet("GetSubscriptionsList")]
        public async Task<IActionResult> GetSubscriptionsList([FromQuery][Range(1, 2)] byte repType, [Range(0, 255)] byte langID = 1)
        {


            try
            {

                var createdReponse = await repositoryWrapper.ManageSubscriptionsRepository.GetSubscriptionsList(repType, langID);

                return Ok(CustomResponse.Success(createdReponse));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }


        [HttpPut("SetSubscriptionStatus/{AdsPlanId}")]
        public async Task<IActionResult> SetSubscriptionStatus(long AdsPlanId, [FromBody] SetSubscriptionStatusDTO dto)
        {
            try
            {
                var reponse = await repositoryWrapper.ManageSubscriptionsRepository.SetSubscriptionStatus(AdsPlanId, dto.IsActive);

                if (reponse == 0) return BadRequest(CustomResponse.Error("Status not changed", "لم تتغير الحاله"));

                return Ok(CustomResponse.Success(reponse));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }

        #region  Iteration 3
        [HttpGet("GetPlan/{AdsPlanID}")]
        public async Task<IActionResult> GetItem([Required] long AdsPlanID)
        {

            try
            {

                var response = await repositoryWrapper.ManageSubscriptionsRepository.GetSubscriptionByID(AdsPlanID);
                if (response.Count <= 0) return NotFound(CustomResponse.Error("Plan Not Found", "غير متوفر"));
                return Ok(CustomResponse.Success(response.FirstOrDefault()));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }

        [HttpGet("GetTranlsate")]
        public async Task<IActionResult> GetTranlsate([Required] long basePlanID, [Required] byte langID)
        {

            try
            {

                var response = await repositoryWrapper.ManageSubscriptionsRepository.GetTranslateByLangId(basePlanID, langID);


                return Ok(CustomResponse.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }

        [HttpPost("Translate")]
        public async Task<IActionResult> Translate([FromBody] CreateTranslatedSubscriptionDTO dto)
        {

            try
            {

                var createdReponse = await repositoryWrapper.ManageSubscriptionsRepository.CreateTranslatedSubscription(dto);
                if (createdReponse.Count <= 0 || createdReponse.FirstOrDefault()?.AdsPlanID <= 0) return BadRequest(CustomResponse.Error("Translated not created", "لم يتم انشاء الترجمه"));

                return Ok(CustomResponse.Success(createdReponse.FirstOrDefault()!));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }


        #endregion

    }
}
