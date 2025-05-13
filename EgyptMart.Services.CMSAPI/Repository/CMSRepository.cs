using System.Data;
using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTO;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.DTOS.CMS;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class CMSListRepository : ICMSListRepository
    {
        private DBMasterContext _context;
        private string _verficatoinPath;
        private int _maxSizePDF;

        public CMSListRepository(DBMasterContext context, IConfiguration configuration)
        {
            _context = context;
            //_verficatoinPath = configuration.GetSection("FileUploads").GetValue<string>("VerficationsFilePath")!;
            _verficatoinPath = configuration.GetSection("AppSettings").GetValue<string>("VerficationsFilePath")!;
            _maxSizePDF = configuration.GetSection("PDFConfig").GetValue<int>("MaxfileSize");
        }

        //x
        public async Task<int> Create([FromBody] SupplierDto supplierDto)
        {


            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserID", SqlDbType.BigInt) { Value = supplierDto.UserID },
                new SqlParameter("@CompanyTitle", SqlDbType.NVarChar) { Value = supplierDto.CompanyTitle },
                new SqlParameter("@BusinessTypeID", SqlDbType.NVarChar) { Value = supplierDto.BusinessTypeID }, // Changed to SmallInt
                new SqlParameter("@BusinessRange", SqlDbType.NVarChar) { Value = supplierDto.BusinessRange },
                new SqlParameter("@BusinessProducts", SqlDbType.NVarChar) { Value = supplierDto.BusinessProducts },
               new SqlParameter("@RegisterdCapital", SqlDbType.NVarChar) { Value = supplierDto.RegisteredCapital },
             new SqlParameter("@NumberOfEmployee", SqlDbType.NVarChar) { Value = supplierDto.NumberOfEmployee.ToString() }, // Convert to string
             new SqlParameter("@TaxRegistrationNo", SqlDbType.NVarChar) { Value = supplierDto.TaxRegistrationNo },
             new SqlParameter("@CompanyBIO", SqlDbType.NVarChar) { Value = supplierDto.CompanyBIO },
            new SqlParameter("@TradeCapacity", SqlDbType.NVarChar) { Value = supplierDto.TradeCapacity }
};
            var result = await _context.Set<CreateCompanyProfileDto>().FromSqlRaw(
                "EXEC [dbo].[Pre_UsersExt_SuppliersExt_Create] @UserID, @CompanyTitle, @BusinessTypeID, @BusinessRange, @BusinessProducts, @RegisterdCapital, @NumberOfEmployee, @TaxRegistrationNo, @CompanyBIO, @TradeCapacity",
                parameters.ToArray()
            ).ToListAsync();

            return (int)(result.FirstOrDefault()?.Value ?? 0); // Return the first result or 0 if null
        }


        public async Task<CompanyProfileModelView> SuppliersByID(int userId)
        {
            var userIdParam = new SqlParameter("@UserID", userId);

            // Execute the stored procedure and retrieve data
            var result = await _context.Set<CompanyProfileModelView>()
                .FromSqlRaw("EXEC [dbo].[Pre_UsersExt_SuppliersExt_GetByID] @UserID", userIdParam)
                .ToListAsync();

            // Return the first result if it exists
            return result.FirstOrDefault();
        }

        public async Task<int> SuppliersEdit(SuppliersEditDto suppliersEditDto)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@LinkID", SqlDbType.BigInt) { Value = suppliersEditDto.LinkID },
                new SqlParameter("@CompanyTitle", SqlDbType.NVarChar) { Value = suppliersEditDto.CompanyTitle },
                new SqlParameter("@BusinessTypeID", SqlDbType.SmallInt) { Value = suppliersEditDto.BusinessTypeID },
                new SqlParameter("@BusinessRange", SqlDbType.NVarChar) { Value = suppliersEditDto.BusinessRange },
                new SqlParameter("@BusinessProducts", SqlDbType.NVarChar) { Value = suppliersEditDto.BusinessProducts },
                new SqlParameter("@RegisterdCapital", SqlDbType.NVarChar) { Value = suppliersEditDto.RegisterdCapital },
                new SqlParameter("@NumberOfEmployee", SqlDbType.NVarChar) { Value = suppliersEditDto.NumberOfEmployee },
                new SqlParameter("@TaxRegistrationNo", SqlDbType.NVarChar) { Value = suppliersEditDto.TaxRegistrationNo },
                new SqlParameter("@CompanyBIO", SqlDbType.NVarChar) { Value = suppliersEditDto.CompanyBIO },
                new SqlParameter("@TradeCapacity", SqlDbType.NVarChar) { Value = suppliersEditDto.TradeCapacity }
            };


            var result = await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[Pre_UsersExt_SuppliersExt_Edit] @LinkID, @CompanyTitle, @BusinessTypeID, @BusinessRange, @BusinessProducts, @RegisterdCapital, @NumberOfEmployee, @TaxRegistrationNo, @CompanyBIO, @TradeCapacity",
                parameters.ToArray()
            );

            return result;
        }

        public async Task<int> SuppliersEditImage(SupplierImgDto SupplierImgDto, string ProfileImage)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@UserID", SqlDbType.BigInt) { Value = SupplierImgDto.UserID },
                new SqlParameter("@ProfileImage", SqlDbType.NVarChar) { Value = ProfileImage }
            };


            var result = await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[Pre_Users_UpdateImg] @UserID, @ProfileImage",
                parameters.ToArray()
            );

            return result;
        }

        public async Task<int> CreateTranslation(PreUsersExtSuppliersExtTranslationDto preUsersExtSuppliersExtTranslationDto)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@LinkID", SqlDbType.BigInt) { Value = preUsersExtSuppliersExtTranslationDto.LinkID },

                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = preUsersExtSuppliersExtTranslationDto.LangID },
                new SqlParameter("@CompanyTitle", SqlDbType.NVarChar) { Value = preUsersExtSuppliersExtTranslationDto.CompanyTitle },
                new SqlParameter("@BusinessRange", SqlDbType.NVarChar) { Value = preUsersExtSuppliersExtTranslationDto.BusinessRange },
                new SqlParameter("@BusinessProducts", SqlDbType.NVarChar) { Value = preUsersExtSuppliersExtTranslationDto.BusinessProducts },
                new SqlParameter("@RegisterdCapital", SqlDbType.NVarChar) { Value = preUsersExtSuppliersExtTranslationDto.RegisterdCapital },
                new SqlParameter("@NumberOfEmployee", SqlDbType.NVarChar) { Value = preUsersExtSuppliersExtTranslationDto.NumberOfEmployee  },
                new SqlParameter("@TaxRegistrationNo", SqlDbType.NVarChar) { Value = preUsersExtSuppliersExtTranslationDto.TaxRegistrationNo },
                new SqlParameter("@CompanyBIO", SqlDbType.NVarChar) { Value = preUsersExtSuppliersExtTranslationDto.CompanyBIO  },
                new SqlParameter("@TradeCapacity", SqlDbType.NVarChar) { Value = preUsersExtSuppliersExtTranslationDto.TradeCapacity }
            };

            var result = await _context.Database.ExecuteSqlRawAsync(
                "EXEC [dbo].[sp_InsertOrUpdate_PreUsersExtSuppliersExtTranslation]  @LinkID, @LangID, @CompanyTitle, @BusinessRange, @BusinessProducts, @RegisterdCapital, @NumberOfEmployee, @TaxRegistrationNo, @CompanyBIO, @TradeCapacity",
                parameters.ToArray()
            );

            return result;
        }

        public async Task<List<CompantTranslatedGetModel>> GetByLang(long UserID, byte LangID)
        {
            var parameters = new List<SqlParameter>
            {
            new SqlParameter("@UserID", UserID),
            new SqlParameter("@LangID", LangID)
            };
            // Execute the stored procedure and retrieve data
            var result = await _context.Set<CompantTranslatedGetModel>()
                .FromSqlRaw("EXEC [dbo].[sp_GetByLang_PreUsersExtSuppliersExtTranslation] @UserID , @LangID", parameters.ToArray())
                .ToListAsync();

            // Return the first result if it exists
            return result;
        }




        public async Task<FileDataResponse> downloadFile(int ownerID)
        {
            List<SqlParameter> sqlParameters = [
            new SqlParameter("@UserID", SqlDbType.BigInt) { Value = ownerID }
                ];

            var result = await _context.Set<FilenameDto>().FromSqlRaw("EXEC [Pre_UsersExt_SuppliersExt_VerficaionPDF_GET] @UserID", sqlParameters.ToArray()).ToListAsync();
            var filedata = result.FirstOrDefault();
            if (filedata == null || filedata.Filename == null) return null;

            var filePath = Path.Combine(_verficatoinPath + "/" + ownerID, filedata.Filename);

            if (!File.Exists(filePath))
            {
                return null;
            }

            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            // Read file bytes and convert to Base64
            byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
            string base64String = Convert.ToBase64String(fileBytes);

            var file = new FileDataResponse
            {
                FileBase64 = base64String,
                Filename = filedata.Filename
            };



            return file;
        }

        public async Task<int> uploadPdf(string base64String, int ownerID)
        {

            try
            {

                if (string.IsNullOrEmpty(base64String))
                {
                    return 0;
                }

                // Decode the Base64 string into bytes
                byte[] fileBytes = Convert.FromBase64String(base64String);

                // Create a MemoryStream from the byte array
                var streams = new MemoryStream(fileBytes);

                var uniqueFilename = Guid.NewGuid().ToString();
                // Create an IFormFile instance
                IFormFile pdfFile = new FormFile(streams, 0, fileBytes.Length, "file", uniqueFilename + ".pdf")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/pdf" // Change based on file type
                };



                if (pdfFile != null && pdfFile.Length > 0)
                {

                    var fileExtension = Path.GetExtension(pdfFile.FileName);

                    if (!File.Exists(_verficatoinPath + "\\" + ownerID))
                    {
                        Directory.CreateDirectory(_verficatoinPath + "\\" + ownerID);

                    }

                    var path = Path.Combine(_verficatoinPath + "\\" + ownerID, pdfFile.FileName);

                    var fileName = pdfFile.FileName;


                    if (pdfFile.Length > _maxSizePDF)
                    {
                        return 2; // Fail: File size exceeds 2MB
                    }


                    List<SqlParameter> sqlParameters = [
                    new SqlParameter("@UserID", SqlDbType.BigInt) { Value = ownerID },
                    new SqlParameter("@FileName", SqlDbType.NVarChar) { Value = fileName },
                ];


                    var result = await _context.Database.ExecuteSqlRawAsync("EXEC [Pre_UsersExt_SuppliersExt_Create_VerficaionPDF] @UserID, @FileName", sqlParameters.ToArray());
                    if (result > 0)
                    {
                        //  return 1; // Fail: User not found

                        using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                        await pdfFile.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();


                        return await Task.FromResult(1); // succsess;
                    }
                }
                return await Task.FromResult(0); // fail
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
