using System.Security.Cryptography;
using System.Text;
using EgyptMart.Services.ReportingAPI.Classes;

namespace EgyptMart.Services.ReportingAPI.Helper
{
    public class Encryption
    {
        private Encryption()
        {
        }
        private static Encryption _instance;
        public static Encryption Get()
        {
            if (_instance == null)
            {
                _instance = new Encryption();
            }
            return _instance;
        }


        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        public string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(KeyStores.key, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, KeyStores.initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }
        public string Decrypt(string cipherText)
        {
            if (!NullString(cipherText))
            {
                // cipherText = cipherText.Replace("+", " ");
                cipherText = cipherText.Replace(" ", "+");
                int mod4 = cipherText.Length % 4;
                if (mod4 > 0)
                {
                    cipherText += new string('=', 4 - mod4);
                }
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(KeyStores.key, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, KeyStores.initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                    string x = plainTextBytes.Length.ToString();
                                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        public string DecryptBasicAuth(string cipherText)
        {
            if (!NullString(cipherText))
            {
                // cipherText = cipherText.Replace("+", " ");
                cipherText = cipherText.Replace(" ", "+");
                int mod4 = cipherText.Length % 4;
                if (mod4 > 0)
                {
                    cipherText += new string('=', 4 - mod4);
                }
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(KeyStores.BackBasicAuthKey, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, KeyStores.BackBasicAuthInitVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                    string x = plainTextBytes.Length.ToString();
                                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        public string DecryptFrontBasicAuth(string cipherText)
        {
            if (!NullString(cipherText))
            {
                // cipherText = cipherText.Replace("+", " ");
                cipherText = cipherText.Replace(" ", "+");
                int mod4 = cipherText.Length % 4;
                if (mod4 > 0)
                {
                    cipherText += new string('=', 4 - mod4);
                }
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(KeyStores.BasicAuthKey, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, KeyStores.BasicAuthInitVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                    string x = plainTextBytes.Length.ToString();
                                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }
        public bool NullString(string ToCheck)
        {
            if (ToCheck != null)
            {
                if (ToCheck.Trim().Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }
        public string EncryptAES(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = KeyStores.key2;
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

        public string DecryptAES(string cipherText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using var aes = Aes.Create();
            aes.Key = KeyStores.key2;
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
    }
}
