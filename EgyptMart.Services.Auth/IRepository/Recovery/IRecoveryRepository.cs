namespace EgyptMart.Services.Auth.IRepository
{
    public interface IRecoveryRepository
    {
        public Task<int> ResetLoginFaildCounter(string username);
        public Task<int> RaisResetCode(string username, string activationCode);
        public Task<List<byte>> VerfiyActivationCode(string username, string activationCode);
        public Task<List<byte>> CheckExistEmail(string username);
        public Task<int> ForgotChangePassword(string username, string newPassword);
        public Task<int> ChangePassword(long userID, string newPassword);
        public Task<List<int>> ReplacePassword(long userID, string oldPassword, string newPassword);
        public Task<List<int>> CheckPassword(long userID, string password);
    }
}
