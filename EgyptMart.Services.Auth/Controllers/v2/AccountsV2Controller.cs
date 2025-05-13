using EgyptMart.Services.Auth.Classes;
using EgyptMart.Services.Auth.DTO;
using EgyptMart.Services.Auth.IProviderServices;
using EgyptMart.Services.Auth.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace EgyptMart.Services.Auth.Controllers.v2
{
    [Route("api/v2/Auth")]
    [ApiController]
    public class AccountsV2Controller(IAccountsRepository repository, IJWTTokenService tokenService) : ControllerBase
    {
        [HttpPost("SupplierLogin")]
        [EnableRateLimiting("AllRate")]
        public async Task<IActionResult> LoginIn([FromBody] LoginDTO dto)
        {
            try
            {
                var response = await repository.Login(dto);

                if (response.Count < 0 ||
                    response.FirstOrDefault() == null ||
                    response.FirstOrDefault()!.UserID == 0) throw new Exception("Username or Password incorrect or account blocked");

                var user = response.FirstOrDefault();

                /// GenerateTokens
                var tokens = await tokenService.GenerateTokens(
                    user!.UserName!,
                    user.UserID.ToString(),
                    user.UserTypeID.ToString(),
                    user.IsVerfied.ToString()
                    );

                return Ok(CustomResponse.Success(new { User = user.GetItem, Tokens = tokens }));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpPost("RefreshToken")]

        public async Task<IActionResult> RefreshExpiredToken(string ExpiredToken, string RefreshToken)
        {
            try
            {
                var newJWT = await tokenService.RefreshToken(ExpiredToken, RefreshToken);

                return Ok(CustomResponse.Success(new { newJWT }));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }



    }
}
