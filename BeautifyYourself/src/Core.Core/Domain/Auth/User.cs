namespace Core.Core.Domain.Auth
{
    public class User: Entity
    {
        public User(string eMail, string password)
        {
            Email = eMail;
            Password = password;
            Validate();
        }
        protected override void Validate()
        {
        }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
