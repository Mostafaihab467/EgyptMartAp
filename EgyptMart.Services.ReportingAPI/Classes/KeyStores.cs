using System.Text;

namespace EgyptMart.Services.ReportingAPI.Classes
{
    public class KeyStores
    {
        public static readonly string JWT_SECRET_KEY = "dede3bb24f14e4b2c38f4b546737cd942b9b232727fe035fa5cb5888d00e362e";
        public static readonly string JWT_Issuer = "EgyptMart";
        public static readonly string JWT_Audience = "EgyptMartSite";
        public static readonly int JWT_ExpirationMinutes = 60;

        //login
        public static readonly string key = "NlOd2ZNXdgDdz0k?vQP@sFWOXBOGp4)1";
        public static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("Q8FJKuy9DJOziXao");
        //Front
        public static readonly string BasicAuthKey = "N3LPkfD5vbfG@0mv0#Lh6h^)C32JGUvO";
        public static readonly byte[] BasicAuthInitVectorBytes = Encoding.ASCII.GetBytes("ESzejuwF6mpDcP09");
        //Back
        public static readonly string BackBasicAuthKey = "QOJrLWqVBEUKhPViobc6LZYE3K0ZJ6Yt";
        public static readonly byte[] BackBasicAuthInitVectorBytes = Encoding.ASCII.GetBytes("8O8Z2Pd9xc2yB4GA");

        public static readonly byte[] IV = Encoding.ASCII.GetBytes("Q9FJKuyFDJOziXao");
        public static readonly byte[] key2 = Encoding.ASCII.GetBytes("NlOd1ZNXdgDdB0k?vQP@sFWOXBOGp4)1");
    }
}
