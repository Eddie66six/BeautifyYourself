using Auth.Core.Domain;
using System.Linq;

namespace Auth.Repository
{
    public class UserRepository: IUserRepository
    {
        protected readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }

        public User GetUser(string email, string password)
        {
            return _context.Users.FirstOrDefault();
        }
    }
}
