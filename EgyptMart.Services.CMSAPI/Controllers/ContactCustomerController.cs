using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.CMSAPI.Classes;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Validations;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.CMSAPI.Controllers
{
    [Route("api/v1/ContactCustomer")]
    [ApiController]
    public class ContactCustomerController(IRepositoryWrapper repositorys) : ControllerBase
    {

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateContactCustomerDTO dto)
        {
            try
            {
                var response = await repositorys.ContactCustomerRepository.Create(dto);
                if (response.Count == 0 ||
                    response.FirstOrDefault()?.ContactID == null ||
                    response.FirstOrDefault()?.ContactID < 1) return NotFound(CustomResponse.Error("Not created", "لم يتم الانشاء"));
                return Ok(CustomResponse.Success(response.FirstOrDefault()));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }
        [HttpPut("Reply")]
        public async Task<IActionResult> Reply([FromBody] ReplyContactCustomerDTO dto)
        {
            try
            {
                var response = await repositorys.ContactCustomerRepository.SupplierReply(dto);
                if (response < 1) return NotFound(CustomResponse.Error("Not replyed", "لم يتم الرد"));
                return Ok(CustomResponse.Success(1));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpPost("AddMessage")]
        public async Task<IActionResult> AddMessage([FromBody] AddContactCustomerMessageDTO dto)
        {
            try
            {
                var response = await repositorys.ContactCustomerRepository.AddMessage(dto);
                if (response < 1) return NotFound(CustomResponse.Error("Not added", "لم يتم الاضافه"));
                return Ok(CustomResponse.Success(1));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([Required] long UserID)
        {
            try
            {
                var response = await repositorys.ContactCustomerRepository.GetList(UserID);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([Required][MinValidator(1)] long ContactID, [Required][MinValidator(1)] long UserID)
        {
            try
            {
                var response = await repositorys.ContactCustomerRepository.GetSingleReplys(ContactID, UserID);

                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }
    }
}
