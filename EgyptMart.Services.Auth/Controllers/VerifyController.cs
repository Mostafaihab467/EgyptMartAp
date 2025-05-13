using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.Auth.Classes;
using EgyptMart.Services.Auth.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.Auth.Controllers
{
    [Route(AppRoutes.AuthPrefix)]
    [ApiController]
    public class VerifyController(IVerifyRepository repository) : ControllerBase
    {
        [HttpPut("Supplier/Verify")]
        public async Task<ActionResult<CustomResponse>> SupplierVerify([FromQuery] long userID, [FromQuery] long verifiedID, [FromQuery][Range(1, 2)] byte status)
        {
            if (userID == 0 || verifiedID == 0) return BadRequest(CustomResponse.Error($"Enter {nameof(userID)} and {nameof(verifiedID)}", $"ادخل {nameof(userID)} و {nameof(verifiedID)}"));
            try
            {
                var response = await repository.VerifySupplierRegister(userID, verifiedID, status);
                if (response == 0) return BadRequest(CustomResponse.Error($"Verified fail", "حدث خطأ في Verified"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpPut("Customer/Verify")]
        public async Task<ActionResult<CustomResponse>> CustomerVerify([FromQuery] long customerID, [FromQuery] long verifiedID)
        {
            if (customerID == 0 || verifiedID == 0) return BadRequest(CustomResponse.Error($"Enter {nameof(customerID)} and {nameof(verifiedID)}", $"ادخل {nameof(customerID)} و {nameof(verifiedID)}"));
            try
            {
                var response = await repository.VerifyCustomerRegister(customerID, verifiedID);
                if (response == 0) return BadRequest(CustomResponse.Error($"Verified fail", "حدث خطأ في Verified"));
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("PendingVerifySuppliers/Get")]
        public async Task<ActionResult<CustomResponse>> PendingVerifySuppliers()
        {
            try
            {
                var response = await repository.PendingVerifySupplier();
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("PendingVerifyCustomer/Get")]
        public async Task<ActionResult<CustomResponse>> PendingVerifyCustomer()
        {
            try
            {
                var response = await repository.PendingVerifyCustomer();
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }



    }
}
