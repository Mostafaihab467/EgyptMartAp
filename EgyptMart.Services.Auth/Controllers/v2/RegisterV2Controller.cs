using EgyptMart.Services.Auth.Classes;
using EgyptMart.Services.Auth.DTO;
using EgyptMart.Services.Auth.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace EgyptMart.Services.Auth.Controllers
{
    [Route(AppRoutes.AuthPrefixV2)]
    [ApiController]
    public class RegisterV2Controller(IRegisterRepository repository) : ControllerBase
    {
        [EnableRateLimiting("AllRate")]
        [HttpPost("Supplier/Register")]
        public async Task<IActionResult> SupplierRegister([FromBody] RegisterSupplierDTO dto)
        {
            try
            {
                var created = await repository.RegisterSupplier(dto);
                if (created != 2) return BadRequest(CustomResponse.Error("Supplier Not Registered", "supplierحدث خطأ في تسجيل ال"));
                return Ok(CustomResponse.Success(1));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [EnableRateLimiting("AllRate")]
        [HttpPost("Customer/Register")]
        public async Task<IActionResult> CustomerRegister([FromBody] RegisterDTO dto)
        {
            try
            {

                var created = await repository.RegisterCustomer(dto);
                if (created != 2) return BadRequest(CustomResponse.Error("Customer Not Registered", "Customerحدث خطأ في تسجيل ال"));
                return Ok(CustomResponse.Success(1));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }
    }
}
