using EgyptMart.Services.ReportingAPI.Classes;
using EgyptMart.Services.ReportingAPI.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.ReportingAPI.Controllers
{
    [Route("api/v1/Reporting/AdminDashboard")]
    [ApiController]
    public class AdminDashboardController(IWrapperRepository repositorys) : ControllerBase
    {
        [HttpGet("ViewCountByAge")]
        public async Task<IActionResult> ViewCountByAge()
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.ViewCountByAge();
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpGet("UsersSubscriptionWillFinish")]
        public async Task<IActionResult> UserSubscriptionWillFinish(int WillFinishDays = 5)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.UserSubscriptionWillFinish(WillFinishDays);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("UserSubscriptionCountByPlan")]
        public async Task<IActionResult> UserSubscriptionCountByPlan()
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.UserSubscriptionCountByPlan();
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("TrendingUserSubscriptionsCount")]
        public async Task<IActionResult> TrendingUserSubscriptionsCount(int topSelect = 5)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.TrendingUserSubscriptionsCount(topSelect);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("TrendingProductHistoryGetTop10")]
        public async Task<IActionResult> TrendingProductHistoryGetTop10(int lastXMonths = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.TrendingProductHistoryGetTop10(lastXMonths);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("TrendingCategory")]
        public async Task<IActionResult> TrendingCategory(int days = 30, int top = 5)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.TrendingCategoryGetAll(days, top);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpGet("TotalViewsByWeekdays")]
        public async Task<IActionResult> TotalViewsByWeekdays()
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.TotalViewsByWeekdays();
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpGet("TotalViewByRegister")]
        public async Task<IActionResult> TotalViewByRegister(int days)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.TotalViewByRegister(days);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("TotalProductViewByGender")]
        public async Task<IActionResult> TotalProductViewByGender()
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.TotalProductViewByGender();
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("TotalCostByPlan")]
        public async Task<IActionResult> TotalCostByPlan()
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.TotalCostByPlan();
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("TopUsersViewProducts")]
        public async Task<IActionResult> TopUsersViewProducts(int days = 3, int top = 10)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.TopUsersView(days, top);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpGet("TopRateProducts")]
        public async Task<IActionResult> TopRateProducts(int top = 10)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.TopRateProducts(top);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("ProductTotalView")]
        public async Task<IActionResult> ProductTotalView(long productID, int days = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.ProductViewCountGetByDays(productID, days);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("ProductsViewCountEveryDay")]
        public async Task<IActionResult> ProductsViewCountDays(int days = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.ProductViewCountByEveryLastDays(days);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("PlatformsViewCount")]
        public async Task<IActionResult> PlatformsViewCount(int days = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.PlatformsViewsCount(days);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("Pending/SubscriptionCount")]
        public async Task<IActionResult> PendingSubscriptionCount()
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.PendingUsersSubscriptionCount();
                return Ok(CustomResponse.Success(response.FirstOrDefault()));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("Pending/UsersVerifiedCount")]
        public async Task<IActionResult> PendingUsersVerifiedCount()
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.PendingUsersCount();
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("Pending/ProductsVerifiedCount")]
        public async Task<IActionResult> PendingProductsVerifiedCountt()
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.PendingProductsCount();
                return Ok(CustomResponse.Success(response.FirstOrDefault()));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("Pending/AdsVerifiedCount")]
        public async Task<IActionResult> PendingAdsVerifiedCount()
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.PendingAdsPlansCount();
                return Ok(CustomResponse.Success(response.FirstOrDefault()));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("OSViewsCount")]
        public async Task<IActionResult> OSViewsCount(int days = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.OSViewsCount(days);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpGet("LocationViewCount")]
        public async Task<IActionResult> LocationViewCount(int days = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.LocationViewsCount(days);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpGet("LastMonthTotalViewByRegister")]
        public async Task<IActionResult> RegisterUsersViewEveryMonths(int lastMonths = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.LastXMonthTotalViewByRegister(lastMonths);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpGet("LastMonthsUserJoined")]
        public async Task<IActionResult> LastMonthsUserJoined(int lastMonths = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.LastMonthsUserJoined(lastMonths);
                return Ok(CustomResponse.Success(response.FirstOrDefault()));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("LastDaysUserJoined")]
        public async Task<IActionResult> LastDayssUserJoined(int lastDays = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.LastDaysUserJoined(lastDays);
                return Ok(CustomResponse.Success(response.FirstOrDefault()));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpGet("IpAdressViewCount")]
        public async Task<IActionResult> IpAdressViewCount(int lastDays = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.IPViewsCount(lastDays);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

        [HttpGet("CategoryViewSumByDays")]
        public async Task<IActionResult> CategoryViewSumByDays(int lastDays = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.CategoryViewSumByDays(lastDays);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpGet("BrowserViewsCount")]
        public async Task<IActionResult> BrowserViewsCount(int lastDays = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.BrowserViewsCount(lastDays);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }


        [HttpGet("AllProductsViewCount")]
        public async Task<IActionResult> ProductsViewCount(int lastDays = 3)
        {
            try
            {
                var response = await repositorys.AdminDashboardRepository.AllProductViewCountGetByDays(lastDays);
                return Ok(CustomResponse.Success(response));
            }
            catch (Exception e)
            {
                return BadRequest(CustomResponse.Error(e.Message));
            }
        }

    }
}
