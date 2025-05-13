using System.Security.Cryptography;

namespace EgyptMart.Services.Auth.Classes
{
    public class RandomCode
    {
        public static string GenerateActivationCode()
        {
            byte[] randomNumber = new byte[4];  // 4 bytes gives us a range of 0 to 4,294,967,295
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }

            int otp = BitConverter.ToInt32(randomNumber, 0) & 0xFFFFFF; // Mask the value to get a 6-digit number
            otp = otp % 1000000; // Ensure OTP is within 6-digit range
            return otp.ToString("D6"); // Ensure 6 digits with leading zero if needed
        }
    }
}
