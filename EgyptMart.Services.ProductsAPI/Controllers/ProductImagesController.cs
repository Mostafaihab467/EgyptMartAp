using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.ProductsAPI.Classes;
using EgyptMart.Services.ProductsAPI.DTO;
using EgyptMart.Services.ProductsAPI.DTOs;
using EgyptMart.Services.ProductsAPI.IRepository;
using EgyptMart.Services.ProductsAPI.Validations;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.ProductsAPI.Controllers
{
    [Route("api/ProductImages")]
    [ApiController]
    public class ProductImagesController : Controller
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IConfiguration _configuration;

        public ProductImagesController(IRepositoryWrapper repoWrapper, IConfiguration iConfig)
        {
            _repoWrapper = repoWrapper;
            _configuration = iConfig;
        }

        [HttpGet("Get/{ProductID}")]
        public async Task<IActionResult> GetImages([FromRoute] long ProductID)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductImagesRepository.GetImages(ProductID);

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                if (typeof(InvalidOperationException) == ex.GetType())
                    return BadRequest(CustomResponse.Error("ProductID not found", "لا يوجد ProductID"));
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpPost("UploadProductImage")]
        public async Task<IActionResult> UploadProductImage(UploadProductImageDTO Model)
        {
            long BlockNumber = 0;
            if (Model.fileBytes == null || Model.fileBytes.Length == 0)
                return BadRequest(new { success = false, ResponseArMsg = "No file uploaded.", ResponseEngMsg = "No file uploaded." });
            BlockNumber = 1;
            try
            {
                BlockNumber = 2;

                // TO DO: Define the file path where the PDF will be saved
                Stream stream = new MemoryStream(Model.fileBytes);
                string BaseProductImgPath = _configuration.GetValue<string>("AppSettings:ProductImgPath");

                #region Make Directory for Product Images
                string ProductImgsDirPath = BaseProductImgPath + Model.ProductID;
                try
                {
                    if (!Directory.Exists(ProductImgsDirPath))
                    {
                        Directory.CreateDirectory(ProductImgsDirPath);
                    }
                }
                catch { }
                #endregion

                #region Make New File Name
                string NewFileName = $"{Guid.NewGuid().ToString().Replace("-", "")}.png";


                #endregion

                #region Save the Image
                try
                {
                    string FilePath = ProductImgsDirPath + "\\" + NewFileName;
                    if (!System.IO.File.Exists(FilePath))
                    {
                        using (var fileStream = System.IO.File.Create(FilePath))
                        {
                            BlockNumber = 5;
                            stream.CopyTo(fileStream);
                        }
                    }
                }
                catch { }
                #endregion


                var DataResult = await _repoWrapper.ProductImagesRepository.CreateImages(Model.ProductID, NewFileName, Model.IsThumbMain, Model.IsMain);
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
        public async Task<IActionResult> EditImages([FromBody] EditeProductImagesDTO productImages)
        {
            try
            {
                if (productImages.fileBytes == null || productImages.fileBytes.Length == 0)
                    return BadRequest(new { success = false, ResponseArMsg = "No file uploaded.", ResponseEngMsg = "No file uploaded." });


                Stream stream = new MemoryStream(productImages.fileBytes);
                string BaseProductImgPath = _configuration.GetValue<string>("AppSettings:ProductImgPath");
                string ProductImgsDirPath = BaseProductImgPath + productImages.ProductID;
                string imageName = System.IO.Path.GetFileName(new Uri(productImages.ImageURL).LocalPath);
                string FilePath = ProductImgsDirPath + "\\" + imageName;



                #region Delete Old File
                if (System.IO.File.Exists(FilePath))
                {
                    System.IO.File.Delete(FilePath);
                }
                #endregion
                #region Save the Image
                try
                {

                    if (!System.IO.File.Exists(FilePath))
                    {
                        using (var fileStream = System.IO.File.Create(FilePath))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
                catch { }
                #endregion


                var DataResult = await _repoWrapper.ProductImagesRepository.EditImages(productImages.ImageID, imageName, productImages.IsThumbMain, productImages.IsMain);
                if (DataResult == 0)
                    throw new Exception();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpDelete("Remove/{ImageID}")]
        public async Task<IActionResult> DeleteImages([FromRoute] long ImageID)
        {
            try
            {
                var DataResult = await _repoWrapper.ProductImagesRepository.DeleteImages(ImageID);
                if (DataResult == 0)
                    throw new InvalidOperationException();
                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                if (typeof(InvalidOperationException) == ex.GetType())
                    return BadRequest(CustomResponse.Error("ImageID not found", "لا يوجد ImageID"));
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }


        #region 3D Models
        [DisableRequestSizeLimit]
        [RequestSizeLimit(2147483648)]
        [HttpPost("3Ds/Upload/{ProductID}")]
        public async Task<IActionResult> Upload3DModel([Required][MinValidator(1)] long ProductID, [FromBody] Upload3dModel ModelBase64)
        {

            try
            {

                Stream stream = new MemoryStream(Convert.FromBase64String(ModelBase64.Base64Model));
                string BasePath3DPath = _configuration.GetValue<string>("AppSettings:Product3DModelsPath");

                #region Make Directory for Product 3d models
                string Product3dModelDirPath = Path.Combine(BasePath3DPath, ProductID.ToString());

                if (Directory.Exists(Product3dModelDirPath))
                {
                    Directory.Delete(Product3dModelDirPath, true);
                }
                Directory.CreateDirectory(Product3dModelDirPath);

                #endregion

                #region Make New File Name
                string NewFileName = Guid.NewGuid().ToString().Normalize().Replace("-", "") + ".glb";

                #endregion

                #region Save the Image
                try
                {
                    string FilePath = Path.Combine(Product3dModelDirPath, NewFileName);
                    if (!System.IO.File.Exists(FilePath))
                    {
                        using var fileStream = System.IO.File.Create(FilePath);

                        stream.CopyTo(fileStream);
                    }
                }
                catch { }
                #endregion


                var DataResult = await _repoWrapper.ProductImagesRepository.Insert3DModel(ProductID, NewFileName);

                if (DataResult < 1) throw new Exception("Not saved");

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));

            }
        }


        [HttpGet("3Ds/Get/{ProductID}")]
        public async Task<IActionResult> Get3DModel([Required][MinValidator(1)] long ProductID)
        {

            try
            {
                var DataResult = await _repoWrapper.ProductImagesRepository.GetProduct3DModels(ProductID);

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpDelete("3Ds/Remove/{ModelID}")]
        public async Task<IActionResult> Remove3DModel([Required][MinValidator(1)] long ModelID)
        {

            try
            {

                var DataResult = await _repoWrapper.ProductImagesRepository.Remove3DModel(ModelID);
                if (DataResult < 1) throw new Exception("Not deleted");

                return Ok(CustomResponse.Success(DataResult));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }
        #endregion

    }
}
