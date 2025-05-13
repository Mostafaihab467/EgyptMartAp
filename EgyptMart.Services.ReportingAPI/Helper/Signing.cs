using System.Security.Cryptography;
using System.Text;
using EgyptMart.Services.ReportingAPI.Classes;

namespace EgyptMart.Services.ReportingAPI.Helper
{
    public class Signing
    {
        private const int keysize = 256;
        private const string Originalkey = "NlOd2ZNXdgDdz0k?vQP@sFWOXBOGp4)1";

        public static string SignMyRequest(string UserEMail, string EndPoint, string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.ASCII.GetBytes(GetMyKey(UserEMail, EndPoint));
            aes.IV = KeyStores.IV;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(plainText);
            }

            byte[] cipherTextBytes = ms.ToArray();
            return Convert.ToBase64String(cipherTextBytes);
        }
        public static string ValidateRequest(string cipherText, string AESKey)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using var aes = Aes.Create();
            aes.Key = Encoding.ASCII.GetBytes(AESKey);
            aes.IV = KeyStores.IV;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(cipherTextBytes);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
            //byte[] cipherTextBytes = ms.ToArray();
            //return Convert.ToBase64String(cipherTextBytes);
        }
        public static string GetMyKey(string UserEMail, string EndPoint)
        {
            try
            {
                string MyKey;
                UserEMail = NormalizeText(UserEMail);
                EndPoint = NormalizeText(EndPoint);
                MyKey = UserEMail + EndPoint + GetDayIndex().ToString();
                if (MyKey.Length < 32)
                {
                    MyKey = MyKey + Originalkey.Substring(0, 32 - MyKey.Length);
                }
                else
                {
                    MyKey = MyKey.Substring(0, 32);
                }
                return MyKey;
            }
            catch
            {
                return Originalkey;
            }

        }

        static string NormalizeText(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        static int GetDayIndex()
        {
            int DayID = DateTime.Today.Day;
            int MonthID = DateTime.Today.Month;
            if (MonthID == 1) { return DayID; }
            else { return ((MonthID - 1) * 30) + DayID; }
        }
    }
}
