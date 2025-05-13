using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.DTOS.Country;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models.Country;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class CountryRepository : ICountryRepository
    {
       public   DBMasterContext _context;

        public CountryRepository(DBMasterContext context)
        {
            _context = context;
        }






        public async Task<int> CreateCountry(CreateCountryDto dto)
        {
            var parameters = new[]
             {
                new SqlParameter("@CountryTitle", SqlDbType.NVarChar, 50) { Value = dto.CountryTitle },

            };

            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_Create_Country @CountryTitle ", parameters);
            return result;
        }


        public async Task<int> Translate(CountryTranslateDto dto)
        {
            var parameters = new[]
             {
                new SqlParameter("@CountryTitle", SqlDbType.NVarChar, 50) { Value = dto.CountryTitle },
                new SqlParameter("@CountryID", SqlDbType.BigInt, 50) { Value = dto.CountrtID },
                new SqlParameter("@LangID", SqlDbType.TinyInt, 50) { Value = dto.LangID },

            };

            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_Country_Translate @CountryTitle ,@CountryID ,@LangID", parameters);
            return result;
        }




        public async Task<int> UpdateCountry( UpdateCountryDto dto)
        {
            var parameters = new[]
            {
                new SqlParameter("@CountryID", SqlDbType.BigInt) { Value = dto.CountryID },
                new SqlParameter("@CountryTitle", SqlDbType.NVarChar, 50) { Value = dto.CountryTitle },
                new SqlParameter("@BaseId", SqlDbType.BigInt) { Value = (object?)dto.BaseId ?? DBNull.Value },
                new SqlParameter("@LangId", SqlDbType.TinyInt) { Value = (object?)dto.LangId ?? DBNull.Value }
            };

           var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_Update_Country @CountryID, @CountryTitle, @BaseId, @LangId", parameters);
            return result;
        }
        public async Task<List<CountryModel>> GetList(byte LangId)
        {
            var parameters = new[]
             {
                new SqlParameter("@LangID", SqlDbType.BigInt) { Value = LangId },

             };

            var result = await _context.Set<CountryModel>().FromSqlRaw("EXEC sp_Get_Country_GetList @LangID", parameters.ToArray()).ToListAsync();
            return result;
        }

        public async Task<CountryModel> GetById(long CountryID,byte langId)
        {
            var parameters = new[]
            {
                new SqlParameter("@CountryID", SqlDbType.BigInt) { Value = CountryID },
                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = langId },
               
            };

            var result = await _context.Set<CountryModel>().FromSqlRaw("EXEC sp_Get_Country_GetById @CountryID, @LangID", parameters).ToListAsync();
            return result.FirstOrDefault();
        }
    }
}
