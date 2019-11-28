namespace Core.Core.Domain.Auth
{
    public class User: Entity
    {
        public User(string eMail, string password)
        {
            EMail = eMail;
            Password = password;
            Validate();
        }
        protected override void Validate()
        {
        }
        public string EMail { get; private set; }
        public string Password { get; private set; }
    }
}
