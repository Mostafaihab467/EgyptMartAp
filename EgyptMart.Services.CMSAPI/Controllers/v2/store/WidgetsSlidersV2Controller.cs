using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.CMSAPI.Classes;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EgyptMart.Services.CMSAPI.Controllers.v2.store
{
    [Route("api/store/v2/WidgetsSliders")]
    [ApiController]
    //[EnableRateLimiting("IpRateLimit")]
    public class WidgetsSlidersV2Controller(IRepositoryWrapper repositorys, IConfiguration configuration) : ControllerBase
    {

        [EnableRateLimiting("AllRate")]
        [HttpGet("GetSignleById/{SliderID}")]
        public async Task<IActionResult> GetSingle(int SliderID)
        {
            try
            {
                var response = await repositorys.WidgetSliderRepository.GetWidgetSliderById(SliderID);
                if (response.Count == 0) return NotFound(CustomResponse.Error("Slider not found", "غير متوفر"));
                return Ok(CustomResponse.Success(response.FirstOrDefault()));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [EnableRateLimiting("AllRate")]
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var response = await repositorys.WidgetSliderRepository.GetWidgetSliderForAdmin();
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpGet("Get")]
        public async Task<IActionResult> Get([Required] byte LangID)
        {
            try
            {
                var response = await repositorys.WidgetSliderRepository.GetWidgetSliderForFront(LangID);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [EnableRateLimiting("AllRate")]
        [HttpGet("GetByLang")]
        public async Task<IActionResult> GetByLang([Required] int BaseID, [Required] byte LangID)
        {

            try
            {
                var response = await repositorys.WidgetSliderRepository.GetWidgetSliderByLang(BaseID, LangID);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpGet("GetActivedByLang")]
        public async Task<IActionResult> GetActivedByLang([Required] int BaseID, [Required] byte LangID)
        {

            try
            {
                var response = await repositorys.WidgetSliderRepository.GetWidgetSliderByLangForFront(BaseID, LangID);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [EnableRateLimiting("AllRate")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateWidgetSliderDTO widgetsliderDTO)
        {

            try
            {

                #region Convert To Stream

                Stream stream = new MemoryStream(Convert.FromBase64String(widgetsliderDTO.ImageBase64));
                string BaseSliderImgPath = configuration.GetValue<string>("AppSettings:SldiersImgPath");
                string RandFileName = Guid.NewGuid().ToString();
                string NewFileName = RandFileName + ".jpg";
                #endregion

                #region Save the Image To Server
                try
                {
                    string FilePath = BaseSliderImgPath + "\\" + NewFileName;
                    if (!System.IO.File.Exists(FilePath))
                    {
                        using var fileStream = System.IO.File.Create(FilePath);
                        stream.CopyTo(fileStream);
                    }
                }
                catch { }
                #endregion

                #region Store in DB
                var response = await repositorys.WidgetSliderRepository.CreateWidgetSlider(widgetsliderDTO, NewFileName);
                #endregion

                if (response != 1) return BadRequest(CustomResponse.Error($"not created", "لم يتم الانشاء"));

                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }

        }



        [EnableRateLimiting("AllRate")]
        [HttpPost("Translate")]
        public async Task<IActionResult> Translate([FromBody] TranslateWidgetSliderDTO widgetsliderDTO)
        {

            try
            {
                var response = await repositorys.WidgetSliderRepository.TranslateWidgetSlider(widgetsliderDTO);
                if (response != 1) return BadRequest(CustomResponse.Error($"not created", "لم يتم الانشاء"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }

        }

        // Need Edit remove ImageURL
        [EnableRateLimiting("AllRate")]
        [HttpPut("Edit/{SliderID}")]
        public async Task<IActionResult> Edit(int SliderID, [FromBody] UpdateWidgetSliderDTO widgetDTO)
        {
            try
            {
                var response = await repositorys.WidgetSliderRepository.EditWidgetSlider(SliderID, widgetDTO);
                if (response != 1) return BadRequest(CustomResponse.Error($"not updated", "لم يتم التحديث"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [EnableRateLimiting("AllRate")]
        [HttpPut("EditImage/{SliderID}")]
        public async Task<IActionResult> EditImage(int SliderID, [FromBody][Required] string ImageBase64)
        {
            try
            {
                #region Convert To Stream

                Stream stream = new MemoryStream(Convert.FromBase64String(ImageBase64));
                string BaseSliderImgPath = configuration.GetValue<string>("AppSettings:SldiersImgPath");
                string RandFileName = Guid.NewGuid().ToString();
                string NewFileName = RandFileName + ".jpg";
                #endregion

                #region Save the Image To Server
                try
                {
                    string FilePath = BaseSliderImgPath + "\\" + NewFileName;
                    if (!System.IO.File.Exists(FilePath))
                    {
                        using var fileStream = System.IO.File.Create(FilePath);
                        stream.CopyTo(fileStream);
                    }
                }
                catch { }
                #endregion
                var response = await repositorys.WidgetSliderRepository.EditWidgetSliderImage(SliderID, NewFileName);
                if (response != 1) return BadRequest(CustomResponse.Error($"not updated", "لم يتم التحديث"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [EnableRateLimiting("AllRate")]
        [HttpPut("ChangeStatus/{SliderID}")]
        public async Task<IActionResult> ChangeStatus(int SliderID, [Required] bool IsActive)
        {
            try
            {
                var response = await repositorys.WidgetSliderRepository.ChangeWidgetSliderStatus(SliderID, IsActive);
                if (response != 1) return BadRequest(CustomResponse.Error($"not updated", "لم يتم التحديث"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }





    }
}
