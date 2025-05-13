using EgyptMart.Services.CMSAPI.DTOS.Country;
using EgyptMart.Services.CMSAPI.Models.Country;

namespace EgyptMart.Services.CMSAPI.IRepository
{
    public interface ICountryRepository
    {

        public  Task<int> CreateCountry(CreateCountryDto dto);

        public Task<int> UpdateCountry(UpdateCountryDto dto);


        public  Task<CountryModel> GetById(long CountryID, byte langId);



        public Task<List<CountryModel>> GetList(byte LangId);


        public  Task<int> Translate(CountryTranslateDto dto);



    }
}
