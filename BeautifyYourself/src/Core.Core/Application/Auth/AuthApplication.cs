using Core.Core.Domain;
using Core.Core.Domain.Auth;

namespace Core.Core.Application.Auth
{
    public class AuthApplication : BaseApplication, IAuthApplication
    {
        private readonly IAuthRepository _authRepository;
        public AuthApplication(IUnitOfWork unitOfWork, IAuthRepository authRepository) : base(unitOfWork)
        {
            _authRepository = authRepository;
        }

        public dynamic Login(UserViewModel user)
        {
            var userObj = _authRepository.Login(new User(user.EMail, user.Password));
            if(userObj == null)
            {
                AddError("Usuario não encontrado");
                return null;
            }
            return userObj;
        }
    }
}
