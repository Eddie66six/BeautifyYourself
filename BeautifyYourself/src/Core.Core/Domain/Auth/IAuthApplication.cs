namespace Core.Core.Domain.Auth
{
    public interface IAuthApplication
    {
        dynamic Login(UserViewModel user);
    }
}
