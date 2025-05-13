using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.AdsManagmentAPI.Classes;
using EgyptMart.Services.AdsManagmentAPI.DTO;
using EgyptMart.Services.AdsManagmentAPI.Filters;
using EgyptMart.Services.AdsManagmentAPI.IRepository;
using EgyptMart.Services.AdsManagmentAPI.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.AdsManagmentAPI.Controllers.v2.jpt
{
    [Route("api/jpt/v2/Ads/UserSubscription")]
    [Authorize]
    [Signture]
    [ApiController]
    public class UserSubscriptionsV2Controller : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IConfiguration _configuration;

        public UserSubscriptionsV2Controller(IRepositoryWrapper repository, IConfiguration iConfig)
        {
            _repository = repository;
            _configuration = iConfig;
        }

        [HttpPost("Subscribe")]
        public async Task<ActionResult<CustomResponse>> Subscribe([FromBody] UserSubscriptionsCreateDTO dto)
        {
            try
            {
                if (dto.ImageFile == null || dto.ImageFile.Length == 0)
                    return BadRequest(new { success = false, ResponseArMsg = "No file uploaded.", ResponseEngMsg = "No file uploaded." });

                // TO DO: Define the file path where the PDF will be saved
                Stream stream = new MemoryStream(dto.ImageFile);
                string BaseAdsImgPath = _configuration.GetValue<string>("AppSettings:AdsImgPath");
                string RandFileName = Guid.NewGuid().ToString();
                string NewFileName = RandFileName + ".jpg";

                try
                {
                    string FilePath = BaseAdsImgPath + "\\" + NewFileName;
                    if (!System.IO.File.Exists(FilePath))
                    {
                        using var fileStream = System.IO.File.Create(FilePath);
                        stream.CopyTo(fileStream);
                    }
                }
                catch { }

                var response = await _repository.UserSubscriptionsRepository.Subscribe(dto, NewFileName);
                if (response != 1) return BadRequest(CustomResponse.Error("Not subscribed", "لم يتم الاشتراك"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }


        }


        [HttpGet("MySubscriptions/{UserID}")]
        public async Task<ActionResult<CustomResponse>> MyList([Required][MinValidator(1)] long UserID, [Range(1, 255)] byte LangID = 1)
        {

            try
            {
                var response = await _repository.UserSubscriptionsRepository.MySubscriptionsGet(UserID, LangID);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }


        [HttpGet("GetAdsInfo")]
        public async Task<ActionResult<CustomResponse>> GetAdsInfo([FromQuery] long LocationID)
        {
            if (LocationID == 0) return BadRequest(CustomResponse.Error($"Enter {nameof(LocationID)}", $"ادخل {nameof(LocationID)}"));
            try
            {
                var response = await _repository.UserSubscriptionsRepository.UserSubscriptionByLocation(LocationID);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }
    }
}
