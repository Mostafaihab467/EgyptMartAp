namespace EgyptMart.Services.Auth.ProviderServices
{
    public interface IHashPasswordService
    {
        public string HashedPassword(string password);

        public bool VerifyHashedPassword(string password, string hashedPassword);
    }
}
