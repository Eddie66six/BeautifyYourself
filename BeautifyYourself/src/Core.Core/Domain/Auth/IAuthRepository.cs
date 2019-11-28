using System.Threading.Tasks;

namespace Core.Core.Domain.Auth
{
    public interface IAuthRepository
    {
        dynamic Login(User user);
    }
}
