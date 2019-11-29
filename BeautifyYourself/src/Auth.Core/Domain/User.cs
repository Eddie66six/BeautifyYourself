namespace Auth.Core.Domain
{
    public class User
    {
        protected User()
        {
        }
        public User(string name, string eMail)
        {
            Name = name;
            EMail = eMail;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}
