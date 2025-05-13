using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.ProductsAPI.Classes;
using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.IRepository;
using EgyptMart.Services.ProductsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.ProductsAPI.Controllers
{
    [Route("api/v1/CategoryList")]
    [ApiController]

    public class CategoryListController : Controller
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly ILogger<CategoryListController> _logger;
        public CategoryListController(IRepositoryWrapper repoWrapper, ILogger<CategoryListController> logger)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] InsertCategoryListDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.CategoryListRepository.Create(model.CategoryTitle, model.ParentID, model.LangID, model.DisplayOrder, model.CategoryImageURL);
                if (DataResult == 0)
                    throw new Exception();

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] ChangeStatusDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.CategoryListRepository.Edit(model.CategoryID, model.CategoryTitle, model.DisplayOrder);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "An error occurred while updating the category with ID {CategoryID} \n\tCategory Title {CategoryTitle}\n\tDisplay Order {DisplayOrder}", model.CategoryID, model.CategoryTitle, model.DisplayOrder);
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpDelete("Delete/{CategoryID}")]
        public async Task<IActionResult> Delete(int CategoryID)
        {
            try
            {
                var DataResult = await _repoWrapper.CategoryListRepository.Delete(CategoryID);
                if (DataResult == 0)
                    return BadRequest(new { success = false, ResponseArMsg = "خطأ", ResponseEngMsg = "Fail", data = new List<object> { } });
                return Ok(new { success = true, ResponseArMsg = "ناجح", ResponseEngMsg = "Success", data = DataResult });
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "An error occurred while getting the category with ID {CategoryID}", CategoryID);
                return BadRequest(new { success = false, ResponseArMsg = ex.Message, ResponseEngMsg = ex.Message, data = new List<object> { } });
            }
        }

        [HttpPost("Translate")]
        public async Task<IActionResult> Translate([FromBody] TranslateCategoryDTO model)
        {
            try
            {
                List<CategoryListTranslateModel> CatList = await _repoWrapper.CategoryListRepository.Translate(model);
                if (CatList.Count == 0)
                    return BadRequest(new { success = false, ResponseArMsg = "خطأ", ResponseEngMsg = "Fail", data = new List<object> { } });
                return Ok(new { success = true, ResponseArMsg = "ناجح", ResponseEngMsg = "Success", data = CatList });
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Tranlsation error", model.CategoryID);
                return BadRequest(new { success = false, ResponseArMsg = ex.Message, ResponseEngMsg = ex.Message, data = new List<object> { } });
            }
        }

        [HttpGet("GetTopLevel")]
        public async Task<IActionResult> GetTopLevel([FromQuery] GetTopLevelDTO model)
        {
            try
            {

                List<CategoryListModelView> DataResult = await _repoWrapper.CategoryListRepository.GetTopLevel(model.LangID, model.RepType);
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }

        }


        [HttpGet("GetChilds")]
        public async Task<IActionResult> GetChilds([Range(0, 255)] byte langID = 1)
        {
            try
            {

                List<CategoryListModelView> DataResult = await _repoWrapper.CategoryListRepository.GetChildList(langID);
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }

        }


        [HttpGet("GetChild/{ParentID}/{RepType}/{LangID}")]
        public async Task<IActionResult> GetChild([FromRoute] GetCategoryByParentIDDTO model)
        {
            try
            {
                List<CategoryListModelView> DataResult = await _repoWrapper.CategoryListRepository.GetChildCategory(model.ParentID, model.RepType, model.LangID);

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "An error occurred while getting the categories List with ParentID {ParentID}", model.ParentID);
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpGet("GetParent/{ChildID}")]
        public async Task<IActionResult> GetParent([Required] int ChildID)
        {
            try
            {
                List<CategoryListModelView> DataResult = await _repoWrapper.CategoryListRepository.GetParentByChild(ChildID);

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "An error occurred while getting the categories List with ParentID {ParentID}", model.ParentID);
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] GenaricChangeStatusDTO model)
        {
            try
            {
                var DataResult = await _repoWrapper.CategoryListRepository.ChangeStatus(model.RID, model.NewStatus);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "An error occurred while Change Category Status");
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }


        [HttpGet("GetByLang/{BaseID}")]
        public async Task<IActionResult> GetByLang([Required] int BaseID, [Required] short LangID)
        {
            try
            {
                List<CategoryListTranslateModel> CatList = await _repoWrapper.CategoryListRepository.GetByLang(BaseID, LangID);

                return Ok(new { success = true, ResponseArMsg = "ناجح", ResponseEngMsg = "Success", data = CatList });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Get By Lang Category");
                return BadRequest(new { success = false, ResponseArMsg = ex.Message, ResponseEngMsg = ex.Message, data = new List<object> { } });
            }
        }

    }
}
