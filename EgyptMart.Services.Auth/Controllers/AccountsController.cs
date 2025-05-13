using EgyptMart.Services.Auth.Classes;
using EgyptMart.Services.Auth.DTO;
using EgyptMart.Services.Auth.IProviderServices;
using EgyptMart.Services.Auth.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.Auth.Controllers
{
    [Route(AppRoutes.AuthPrefix)]
    [ApiController]
    public class AccountsController(IAccountsRepository repository, IJWTTokenService tokenService) : ControllerBase
    {
        [HttpPost("SupplierLogin")]

        public async Task<IActionResult> LoginIn([FromBody] LoginDTO dto)
        {
            try
            {
                var response = await repository.Login(dto);

                if (response.Count < 0 ||
                    response.FirstOrDefault() == null ||
                    response.FirstOrDefault()!.UserID == 0) throw new Exception("Username or Password incorrect or account blocked");

                var user = response.FirstOrDefault();

                return Ok(CustomResponse.Success(user.GetItem));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }



    }
}
