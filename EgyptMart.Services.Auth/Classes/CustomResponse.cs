namespace EgyptMart.Services.Auth.Classes
{
    public class CustomResponse
    {
        public bool success { get; set; } = true;
        public string ResponseArMsg { get; set; } = "تم بنجاح";
        public string ResponseEngMsg { get; set; } = "success";
        public object? data { get; set; }
        public int ResponseId { get; set; } = 0;



        public static CustomResponse Error(string messageEn, string? messageAr = null)
        {
            return new CustomResponse { ResponseArMsg = messageAr ?? messageEn, ResponseEngMsg = messageEn, ResponseId = -1, success = false };
        }
        public static CustomResponse Success(object data)
        {
            return new CustomResponse { data = data };
        }

    }
}
