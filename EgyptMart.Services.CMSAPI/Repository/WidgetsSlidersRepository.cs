using System.Data;
using EgyptMart.Services.CMSAPI.Data;
using EgyptMart.Services.CMSAPI.DTOS;
using EgyptMart.Services.CMSAPI.IRepository;
using EgyptMart.Services.CMSAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.CMSAPI.Repository
{
    public class WidgetsSlidersRepository(DBMasterContext context) : IWidgetSliderRepository
    {

        public Task<int> CreateWidgetSlider(CreateWidgetSliderDTO dto, string imageURL)
        {

            var parameters = new List<SqlParameter> {
                  new ("@ShortTitle", SqlDbType.NVarChar, 50) { Value = dto.ShortTitle },

                    new ("@MainTitle", SqlDbType.NVarChar, 150) { Value = dto.MainTitle },

                    new ("@Call2ActionMsg", SqlDbType.NVarChar, 30) { Value = dto.Call2ActionMsg },

                   new ("@ImageURL", SqlDbType.NVarChar, 50) { Value = imageURL }  ,

                    new ("@Call2ActionURL", SqlDbType.VarChar) { Value = dto.Call2ActionURL },

                    new ("@DisplayOrder", SqlDbType.SmallInt) { Value = dto.DisplayOrder }
            };

            return context.Database.ExecuteSqlRawAsync("EXEC Widgets_Sliders_Create @ShortTitle, @MainTitle, @Call2ActionMsg, @ImageURL, @Call2ActionURL, @DisplayOrder", parameters);
        }


        public Task<int> EditWidgetSlider(int sliderID, UpdateWidgetSliderDTO dto)
        {
            List<SqlParameter> parameters = [
                    new SqlParameter("@SliderID" , SqlDbType.Int) {Value = sliderID},

                    new SqlParameter("@ShortTitle", SqlDbType.NVarChar, 50) { Value = dto.ShortTitle },

                    new SqlParameter("@MainTitle", SqlDbType.NVarChar, 150) { Value = dto.MainTitle },

                    new SqlParameter("@Call2ActionMsg", SqlDbType.NVarChar, 30) { Value = dto.Call2ActionMsg },

                    new SqlParameter("@Call2ActionURL", SqlDbType.VarChar) { Value = dto.Call2ActionURL },

                    new SqlParameter("@DisplayOrder", SqlDbType.SmallInt) { Value = dto.DisplayOrder }
                ];

            return context.Database.ExecuteSqlRawAsync("EXEC Widgets_Sliders_Edit @SliderID, @ShortTitle, @MainTitle, @Call2ActionMsg, @Call2ActionURL, @DisplayOrder", parameters);
        }

        public Task<int> EditWidgetSliderImage(int sliderID, string imageURL)
        {
            List<SqlParameter> parameters = [
                    new SqlParameter("@SliderID" , SqlDbType.Int) {Value = sliderID},
                    new SqlParameter("@ImageURL", SqlDbType.NVarChar, 50) { Value = imageURL},
     ];
            return context.Database.ExecuteSqlRawAsync("EXEC Widgets_Sliders_EditIMage @SliderID, @ImageURL", parameters);
        }


        public Task<int> ChangeWidgetSliderStatus(int sliderID, bool IsActive)
        {
            List<SqlParameter> parameters = [
                new SqlParameter("@SliderID" , SqlDbType.Int) {Value = sliderID},
                    new SqlParameter("@IsActive", SqlDbType.Bit) { Value = IsActive},
            ];
            return context.Database.ExecuteSqlRawAsync("EXEC Widgets_Sliders_ChangeStatus @SliderID, @IsActive", parameters);
        }


        public Task<List<WidgetSliderModel>> GetWidgetSliderById(int sliderID)
        {
            List<SqlParameter> parameters = [
            new SqlParameter("@SliderID" , SqlDbType.Int) {Value = sliderID}
         ];

            return context.WidgetSliderModel.FromSqlRaw("EXEC Widgets_Sliders_GetByID @SliderID", parameters[0]).ToListAsync();
        }

        public Task<List<WidgetSliderModel>> GetWidgetSliderForAdmin()
        {
            return context.WidgetSliderModel.FromSqlRaw("EXEC Widgets_Sliders_GetAdmin ").ToListAsync();
        }

        public Task<List<WidgetSliderModel>> GetWidgetSliderForFront(byte LangID)
        {
            List<SqlParameter> parameters = [
                        new SqlParameter("@LangID" , SqlDbType.TinyInt) {Value = LangID}
                ];
            return context.WidgetSliderModel.FromSqlRaw("EXEC Widgets_Sliders_GetFront @LangID", parameters[0]).ToListAsync();
        }



        public Task<int> TranslateWidgetSlider(TranslateWidgetSliderDTO dto)
        {
            List<SqlParameter> parameters = [

                    new SqlParameter("@BaseID" , SqlDbType.Int) {Value = dto.BaseID},

                    new SqlParameter("@ShortTitle", SqlDbType.NVarChar, 50) { Value = dto.ShortTitle },

                    new SqlParameter("@MainTitle", SqlDbType.NVarChar, 150) { Value = dto.MainTitle },

                    new SqlParameter("@Call2ActionMsg", SqlDbType.NVarChar, 30) { Value = dto.Call2ActionMsg },

                    new SqlParameter("@LangID" , SqlDbType.TinyInt) {Value = dto.LangID}

          ];
            return context.Database.ExecuteSqlRawAsync("EXEC Widgets_Sliders_Translate @BaseID , @ShortTitle ,@MainTitle , @Call2ActionMsg , @LangID",
                [.. parameters]);
        }

        public Task<List<WidgetSliderModel>> GetWidgetSliderByLang(int baseID, byte langID)
        {
            List<SqlParameter> parameters = [
                   new SqlParameter("@BaseID" , SqlDbType.Int) {Value = baseID},
                   new SqlParameter("@LangID" , SqlDbType.TinyInt) {Value = langID}
            ];
            return context.WidgetSliderModel.FromSqlRaw("EXEC Widgets_Sliders_GetByLang @baseID, @LangID", parameters[0], parameters[1]).ToListAsync();
        }

        public Task<List<WidgetSliderModel>> GetWidgetSliderByLangForFront(int baseID, byte langID)
        {
            List<SqlParameter> parameters = [
                new SqlParameter("@BaseID", SqlDbType.Int) { Value = baseID },
                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = langID }
         ];
            return context.WidgetSliderModel.FromSqlRaw("EXEC Widgets_Sliders_GetByLang_Actived @baseID, @LangID", parameters[0], parameters[1]).ToListAsync();
        }


    }
}
