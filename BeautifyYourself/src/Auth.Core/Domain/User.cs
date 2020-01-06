namespace Auth.Core.Domain
{
    public class User
    {
        protected User()
        {
        }
        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
