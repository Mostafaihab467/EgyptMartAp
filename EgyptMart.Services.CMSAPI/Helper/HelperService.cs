using EgyptMart.Services.CMSAPI.Interfaces.Helper;

namespace EgyptMart.Services.CMSAPI.Helper
{
    public class HelperService : IHelperSerivce

    {
        public  string GetObjectPropertieAsString(object obj)
        {
            var properties = obj.GetType().GetProperties();
            var propertyStrings = properties.Select(p => $"{p.Name}: {p.GetValue(obj)}");
            return string.Join(", ", propertyStrings);
        }
    }
}
