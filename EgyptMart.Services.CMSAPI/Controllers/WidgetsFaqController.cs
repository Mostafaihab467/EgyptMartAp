using System.ComponentModel.DataAnnotations;
using System.Data;
using EgyptMart.Services.CMSAPI.Classes;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EgyptMart.Services.CMSAPI.Controllers
{
    [Route("api/v1/WidgetsFAQ")]
    [ApiController]
    public class WidgetsFAQController(IRepositoryWrapper repositorys) : ControllerBase
    {

        [HttpGet("GetSignleById/{QID}")]
        public async Task<IActionResult> GetSingle(int QID)
        {
            try
            {
                var response = await repositorys.WidgetFAQRepository.GetWidgetFAQById(QID);
                if (response.Count == 0) return NotFound(CustomResponse.Error("FAQ not found", "غير متوفر"));
                return Ok(CustomResponse.Success(response.FirstOrDefault()));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var response = await repositorys.WidgetFAQRepository.GetWidgetFAQForAdmin();
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([Required] byte LangID)
        {
            try
            {
                var response = await repositorys.WidgetFAQRepository.GetWidgetFAQForFront(LangID);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpGet("GetByLang")]
        public async Task<IActionResult> GetByLang([Required] int BaseID, [Required] byte LangID)
        {

            try
            {
                var response = await repositorys.WidgetFAQRepository.GetWidgetFAQByLang(BaseID, LangID);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("GetByLangActived")]
        public async Task<IActionResult> GetByLangActived([Required] int BaseID, [Required] byte LangID)
        {

            try
            {
                var response = await repositorys.WidgetFAQRepository.GetWidgetFAQByLangActived(BaseID, LangID);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateWidgetFAQDTO widgetFAQDTO)
        {

            try
            {
                var response = await repositorys.WidgetFAQRepository.CreateWidgetFAQ(widgetFAQDTO);
                if (response != 1) return BadRequest(CustomResponse.Error($"not created", "لم يتم الانشاء"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }

        }

        [HttpPost("Translate")]
        public async Task<IActionResult> Translate([FromBody] TranslateWidgetFAQDTO faqDTO)
        {

            try
            {
                var response = await repositorys.WidgetFAQRepository.TranslateWidgetFAQ(faqDTO);
                if (response != 1) return BadRequest(CustomResponse.Error($"not created", "لم يتم الانشاء"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }

        }

        // Need Edit remove ImageURL
        [HttpPut("Edit/{QID}")]
        public async Task<IActionResult> Edit(int QID, [FromBody] CreateWidgetFAQDTO widgetDTO)
        {
            try
            {
                var response = await repositorys.WidgetFAQRepository.EditWidgetFAQ(QID, widgetDTO);
                if (response != 1) return BadRequest(CustomResponse.Error($"not updated", "لم يتم التحديث"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpPut("ChangeStatus/{QID}")]
        public async Task<IActionResult> ChangeStatus(int QID, [Required] bool IsActive)
        {
            try
            {
                var response = await repositorys.WidgetFAQRepository.ChangeWidgetFAQStatus(QID, IsActive);
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
