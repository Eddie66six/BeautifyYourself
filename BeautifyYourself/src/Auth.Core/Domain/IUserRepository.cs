namespace Auth.Core.Domain
{
    public interface IUserRepository
    {
        User GetUser(string email, string password);
    }
}
