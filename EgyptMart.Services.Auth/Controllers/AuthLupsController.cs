using EgyptMart.Services.Auth.Classes;
using EgyptMart.Services.Auth.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.Auth.Controllers
{
    [Route(AppRoutes.AuthPrefix)]
    [ApiController]
    public class AuthLupsController(IAuthLupsRepository repository) : ControllerBase
    {

        [HttpGet("AuthLups/GetBusinessType")]
        public async Task<IActionResult> GetBusinessType()
        {
            try
            {
                var list = await repository.GetLupBusinessTypeLists();
                if (list == null || list.Count == 0) return NotFound(CustomResponse.Error("Not found Bussines Types", "غير متوفر قائمه bussiness type"));
                return Ok(CustomResponse.Success(list));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }



        [HttpGet("AuthLups/GetCountryList")]
        public async Task<IActionResult> GetCountryList()
        {
            try
            {
                var list = await repository.GetLupCountryList();
                if (list == null || list.Count == 0) return NotFound(CustomResponse.Error("Not found Country List", "غير متوفر قائمه Country List"));
                return Ok(CustomResponse.Success(list));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }
    }
}
