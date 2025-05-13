using EgyptMart.Services.Auth.Classes;
using EgyptMart.Services.Auth.DTO;
using EgyptMart.Services.Auth.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.Auth.Controllers
{
    [Route(AppRoutes.AuthPrefix)]
    [ApiController]
    public class RegisterController(IRegisterRepository repository) : ControllerBase
    {
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
