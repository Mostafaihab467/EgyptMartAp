using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.CMSAPI.Classes;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.CMSAPI.Controllers
{
    [Route("api/v1/Widget_ContactUs")]
    [ApiController]
    public class WidgetContactUsController(IRepositoryWrapper repositorys) : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateWidgetContactUsDTO dto)
        {
            try
            {
                var response = await repositorys.WidgetContactUsRepository.Create(dto);
                if (response != 1) return NotFound(CustomResponse.Error("Not Created", "لم يتم الإنشاء"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpPost("Translate")]
        public async Task<IActionResult> Translate(TranslateContactUsDTO dto)
        {
            try
            {
                var response = await repositorys.WidgetContactUsRepository.Translate(dto);
                if (response < 1) return BadRequest(CustomResponse.Error("Not Created may be base id contact us not found", "لم يتم الإنشاء"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([Required][Range(1, 255)] byte LangID = 1)
        {
            try
            {
                var response = await repositorys.WidgetContactUsRepository.GetList(LangID);

                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpPut("Update/{ContactUSID}")]
        public async Task<IActionResult> Update([Required][Range(1, 255)] byte ContactUSID, [FromBody] CreateWidgetContactUsDTO dto)
        {
            try
            {
                var response = await repositorys.WidgetContactUsRepository.Update(ContactUSID, dto);
                if (response < 1) throw new Exception("Not updated may be contact us id not found");
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }
    }
}
