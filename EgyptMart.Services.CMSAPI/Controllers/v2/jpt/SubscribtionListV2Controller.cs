using EgyptMart.Services.CMSAPI.DTOS.Subscription;
using EgyptMart.Services.CMSAPI.Filters;
using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.CMSAPI.Controllers.v2.jpt
{
    [Route("api/jpt/v2/SubscribtionList")]
    [Authorize]
    [Signture]
    [ApiController]
    public class SubscribtionListV2Controller : ControllerBase
    {

        private readonly IRepositoryWrapper _repositoryWrapper;


        public SubscribtionListV2Controller(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create(string emailAddress)
        {
            if (emailAddress == null)
            {

                return BadRequest("Supplier data is required.");
            }

            try
            {
                var dataResult = await _repositoryWrapper.subscribtionListRepository.Create(emailAddress);

                return Ok(dataResult);
            }
            catch (Exception ex)
            {

                return BadRequest(new { succsess = "fail", error = ex.Message });
            }
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> GetList(SubscribtionList_GetListDto subscribtionList_Get)
        {

            try
            {
                var dataResult = await _repositoryWrapper.subscribtionListRepository.GetList(subscribtionList_Get);

                return Ok(dataResult);
            }
            catch (Exception ex)
            {

                return BadRequest(new { succsess = "fail", error = ex.Message });
            }
        }


    }
}
