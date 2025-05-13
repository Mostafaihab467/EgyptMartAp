using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.Auth.Classes;
using EgyptMart.Services.Auth.DTO;
using EgyptMart.Services.Auth.Filters;
using EgyptMart.Services.Auth.IRepository;
using EgyptMart.Services.Auth.Models;
using EgyptMart.Services.Auth.ProviderServices;
using EgyptMart.Services.Auth.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.Auth.Controllers.v2
{


    [Route("api/v2/UsersManagment")]
    [Authorize]
    [Signture]
    [ApiController]
    public class UsersV2Controller(IUsersRepository usersRepository, IEmailService emailService) : ControllerBase
    {

        [HttpGet("Types/GetListWithCount")]
        public async Task<IActionResult> GetListWithCount()

        {
            try
            {
                var response = await usersRepository.GetWithCount();

                return Ok(CustomResponse.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }



        [HttpGet("Types/GetSome")]
        public async Task<IActionResult> GetSome()

        {
            try
            {
                var response = await usersRepository.GetSomeTypes();

                return Ok(CustomResponse.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }

        [HttpGet("GetListByType")]
        public async Task<IActionResult> GetListByType(
            [Required][Range(0, 255)] byte TypeID,
            [MinValidator(1)] int PageNumber = 1,
            [Range(20, 50)] int SizePerPage = 50)
        {
            try
            {
                List<UserModel> response = await usersRepository.GetListByType(TypeID, PageNumber, SizePerPage);

                return Ok(CustomResponse.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }


        [HttpGet("GetSingle")]
        public async Task<IActionResult> GetSingle([Required][MinValidator(1)] long UserID)
        {
            try
            {
                List<UserModel> response = await usersRepository.GetUserById(UserID);
                if (response == null || response.Count < 1 || response.FirstOrDefault() == null) return NoContent();
                return Ok(CustomResponse.Success(response.FirstOrDefault()!));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }



        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUserDTO dto)

        {
            try
            {
                var response = await usersRepository.CreateUser(dto);
                if (response.Count < 1 || response.FirstOrDefault() < 1) return BadRequest(CustomResponse.Error("Not Created"));
                return Ok(CustomResponse.Success(new { UserID = response.FirstOrDefault() }));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }




        [HttpPut("BlockOrUnBlock")]
        public async Task<IActionResult> BlockOrUnBlock([Required][MinValidator(1)] long UserID, bool Active = false)

        {
            try
            {
                var response = await usersRepository.BlockOrUnBlock(UserID, Active);
                if (response < 1) return BadRequest(CustomResponse.Error("Not (blocked or UnBlocked)"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }

        // Need a 

        [HttpGet("ResetPassword")]
        public async Task<IActionResult> ResetPassword([Required][MinValidator(1)] long UserID)

        {
            // Get User Details
            // Generate Verification Code 6 and munber
            // Send to email verfiaction and store in db
            // return success to admin
            // Log to file the email reponse


            try
            {
                var founduser = await usersRepository.GetUserById(UserID);
                if (founduser == null || founduser.Count < 1 || founduser.FirstOrDefault() == null) return NotFound(CustomResponse.Error("Not Found"));
                string generetedCode = RandomCode.GenerateActivationCode();
                if (await usersRepository.StoreCode(founduser.FirstOrDefault().UserName, generetedCode) < 1) throw new Exception("Code doesnt stored");

                // Here send code to Email user but dont wait the response and return success
                await emailService.SendEmail(founduser.FirstOrDefault().UserName, "Reset Password Code", HTMLTemplate.VerifyCodeHTML(founduser.FirstOrDefault().UserName, generetedCode));
                // Host handle this 
                await usersRepository.SetFirstLogin(UserID, true);

                return Ok(CustomResponse.Success(1));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message));
            }
        }
    }
}
