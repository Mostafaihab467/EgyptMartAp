namespace EgyptMart.Services.ReportingAPI.DTO
{
    public class SDA_TotalViewsByRegisterDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int UserRegister { get; set; }
        public int ViewsCount { get; set; }
    }
}
