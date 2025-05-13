using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.Auth.Classes;
using EgyptMart.Services.Auth.DTO;
using EgyptMart.Services.Auth.Filters;
using EgyptMart.Services.Auth.IRepository;
using EgyptMart.Services.Auth.ProviderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace EgyptMart.Services.Auth.Controllers.v2
{
    [Route("api/v2/Auth")]
    [ApiController]
    public class RecoveryV2Controller(IRecoveryRepository recoveryRepository, IAccountsRepository accountRepository, IEmailService emailService) : ControllerBase
    {
        [Authorize]
        [Signture]
        [HttpPut("FailCounter/Reset")]
        public async Task<IActionResult> FailCounterReset([FromBody] RecoveryUserDTO updateDto)
        {
            try
            {
                var created = await recoveryRepository.ResetLoginFaildCounter(updateDto.UserName);
                if (created != 1) return BadRequest(CustomResponse.Error("Reset login counter failed", "حدث خطأ"));
                return Ok(CustomResponse.Success(1));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("ForgotPassword/RaisResetCode")]
        [EnableRateLimiting("AllRate")]
        public async Task<IActionResult> RaisResetCode([Required][MaxLength(100)] string userName)
        {
            try
            {
                /// Check username found or not 
                var isUserExsit = await recoveryRepository.CheckExistEmail(userName);

                if (isUserExsit.Count == 0 || isUserExsit.FirstOrDefault() < 1) return NotFound(CustomResponse.Error("Username not found", "السمتخدم غير موجود"));

                /// If found generate random number 6
                string randomActivationCode = RandomCode.GenerateActivationCode();

                /// Store in database 
                var saveInDb = await recoveryRepository.RaisResetCode(userName, randomActivationCode);

                if (saveInDb != 1) return BadRequest(CustomResponse.Error("Proccess failed", "فشلت العمليه"));

                /// Send email to user with this random number
                await emailService.SendEmail(userName, "Reset Password Code", HTMLTemplate.VerifyCodeHTML(userName, randomActivationCode));

                return Ok(CustomResponse.Success(1));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("ForgotPassword/CheckResetCode")]
        [EnableRateLimiting("AllRate")]
        public async Task<IActionResult> CheckResetCode([Required][MaxLength(100)] string userName, [Required] string activationCode)
        {
            try
            {
                var response = await recoveryRepository.VerfiyActivationCode(userName, activationCode);
                if (response.Count != 1 || response.FirstOrDefault() != 1) return BadRequest(CustomResponse.Error("Not valid code", "الكود غير صحيح"));
                return Ok(CustomResponse.Success(1));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpPut("ForgotPassword/CreatePassword")]
        [EnableRateLimiting("AllRate")]
        public async Task<IActionResult> CreatePassord([Required][MaxLength(100)] string UserName, [FromBody] ChangePasswordDTO Dto)
        {
            try
            {
                var response = await recoveryRepository.ForgotChangePassword(UserName, Dto.NewPassword.Trim());
                if (response < 1) return BadRequest(CustomResponse.Error("Not created password"));
                return Ok(CustomResponse.Success(1));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [Authorize]
        [Signture]
        [HttpPut("AdminPassword/ChangePassword")]
        public async Task<IActionResult> ChangePassword([Required] long UserID, [FromBody] ChangePasswordDTO dto)
        {
            try
            {
                var response = await recoveryRepository.ChangePassword(UserID, dto.NewPassword.Trim());
                if (response < 1) return BadRequest(CustomResponse.Error("Not changed password"));
                return Ok(CustomResponse.Success(1));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [Authorize]
        [Signture]
        [HttpPut("Password/ReplaceOldPassword")]
        public async Task<IActionResult> ReplaceOldPassword([Required] long UserID, [FromBody] ReplaceOldPasswordDTO dto)
        {
            try
            {

                var response = await recoveryRepository.ReplacePassword(UserID, dto.OldPassword, dto.NewPassword.Trim());

                if (response.Count < 1) throw new Exception("Somthing wrong happen");

                /// Response 0 == inccorrect password
                /// -1 == Many try login
                /// -2 == Blocked account

                if (response.FirstOrDefault() == 0) throw new Exception("Password Incorrect");
                else if (response.FirstOrDefault() == -1) throw new Exception("Many try login, account blocked");
                else if (response.FirstOrDefault() == -2) throw new Exception("Account blocked");

                return Ok(CustomResponse.Success(1));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }
    }
}
