using EgyptMart.Services.CMSAPI.Classes;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.DTOS.CMS;
using EgyptMart.Services.CMSAPI.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EgyptMart.Services.CMSAPI.Controllers
{
    [ApiController]
    [Route("api/v1/CompanyProfile")]
    public class CompanyProfileController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ILogger<CompanyProfileController> _logger;
        private readonly IConfiguration _configuration;

        public CompanyProfileController(IRepositoryWrapper repositoryWrapper, ILogger<CompanyProfileController> logger, IConfiguration iConfig)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
            _configuration = iConfig;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSupplier([FromBody] SupplierDto supplierDto)
        {
            if (supplierDto == null)
            {
                _logger.LogWarning("CreateSupplier called with null data.");
                return BadRequest("Supplier data is required.");
            }

            try
            {
                var dataResult = await _repositoryWrapper.CMSListRepository.Create(supplierDto);
                _logger.LogInformation("Successfully created supplier: {SupplierDetails}", supplierDto);
                return Ok(dataResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating supplier: {Error}", ex.Message);
                return BadRequest(new { succsess = "fail", error = ex.Message });
            }
        }

        [HttpGet("GetByID/{userID}")]
        public async Task<IActionResult> GetSupplier(int userID)
        {
            if (userID <= 0)
            {
                _logger.LogWarning("GetSupplier called with invalid userID: {UserID}", userID);
                return BadRequest("Invalid user ID.");
            }

            try
            {
                var dataResult = await _repositoryWrapper.CMSListRepository.SuppliersByID(userID);
                if (dataResult == null)
                {
                    _logger.LogWarning("No supplier found for userID: {UserID}", userID);
                    return NotFound("Supplier not found.");
                }

                _logger.LogInformation("Successfully retrieved supplier for userID: {UserID}", userID);
                return Ok(dataResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving supplier: {Error}", ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([FromBody] SuppliersEditDto supplierDto)
        {
            if (supplierDto == null)
            {
                _logger.LogWarning("Edit called with null data.");
                return BadRequest("Supplier data is required.");
            }

            try
            {
                var dataResult = await _repositoryWrapper.CMSListRepository.SuppliersEdit(supplierDto);
                _logger.LogInformation("Successfully edited supplier: {SupplierDetails}", supplierDto);
                return Ok(dataResult);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error while editing supplier: {Error}", ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("EditImage")]
        public async Task<IActionResult> EditImage([FromBody] SupplierImgDto SupplierImgDto)
        {
            if (SupplierImgDto.ImageFile == null || SupplierImgDto.ImageFile.Length == 0)
                return BadRequest(new { success = false, ResponseArMsg = "No file uploaded.", ResponseEngMsg = "No file uploaded." });

            // TO DO: Define the file path where the PDF will be saved
            Stream stream = new MemoryStream(SupplierImgDto.ImageFile);
            string BaseProfileImgPath = _configuration.GetValue<string>("AppSettings:ProfileImgPath");
            string NewFileName = SupplierImgDto.UserID.ToString() + ".jpg";
            string FilePath = BaseProfileImgPath + "\\" + NewFileName;

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

            try
            {
                var dataResult = await _repositoryWrapper.CMSListRepository.SuppliersEditImage(SupplierImgDto, NewFileName);
                _logger.LogInformation("Successfully edited supplier: {SupplierDetails}", SupplierImgDto);
                return Ok(dataResult);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error while editing supplier: {Error}", ex.Message);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost("Create_Translate")]
        public async Task<IActionResult> Create_Translate(PreUsersExtSuppliersExtTranslationDto preUsersExtSuppliersExtTranslationDto)
        {

            try
            {
                var dataResult = await _repositoryWrapper.CMSListRepository.CreateTranslation(preUsersExtSuppliersExtTranslationDto);

                return Ok(new { success = true, data = dataResult });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing supplier.");
                return StatusCode(500, new { success = false, error = ex.Message });
            }

        }
        [HttpGet("GetByLang/{UserID}/{LangID}")]
        public async Task<IActionResult> GetByLang(long UserID, byte LangID)
        {

            try
            {
                var dataResult = await _repositoryWrapper.CMSListRepository.GetByLang(UserID, LangID);
                if (dataResult.Count > 0) return Ok(new { success = true, data = dataResult.LastOrDefault() });
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while editing supplier.");
                return StatusCode(500, new { success = false, error = ex.Message });
            }

        }




        [HttpGet("download_verficationFilePDf/{ownerID}")]
        public async Task<IActionResult> DownloadFile(int ownerID)
        {
            try
            {

                var file = await _repositoryWrapper.CMSListRepository.downloadFile(ownerID);
                if (file == null)
                {

                    return NotFound(CustomResponse.Error("Your file not found", "غير موجود"));
                }
                return Ok(CustomResponse.Success(file));
            }
            catch (Exception ex)
            {

                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadPdf([FromBody] string base64File, int ownerID)
        {
            try
            {
                var result = await _repositoryWrapper.CMSListRepository.uploadPdf(base64File, ownerID);
                // Indicate incorrect file type

                if (result == -2)
                    return BadRequest(CustomResponse.Error("Incorrect file type Must Be PDF"));

                if (result == -3)
                    return BadRequest(CustomResponse.Error("Indicate incorrect MIME type"));

                if (result == 2)
                {
                    return BadRequest(CustomResponse.Error("File Must Be less than 2MB"));
                }
                if (result == 1)
                {
                    return Ok(CustomResponse.Success("File Uploaded Successfully"));
                }
                return BadRequest(CustomResponse.Error("File upload failed, May be  Not supplier"));
            }
            catch (Exception ex)
            {
                return BadRequest(CustomResponse.Error(ex.Message, "خطأ"));
            }
        }

    }
}