using Ocdata.Operations.Entities;

namespace Usage.Domain.UserAggregate
{
    public class UserDomain : EntityBase
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public UserType UserType { get; private set; }

        public UserDomain(string username, string password, string email, DateTime birthDate, UserType userType = UserType.User)
        {
            Username = username;
            Password = password;
            Email = email;
            BirthDate = birthDate;
            UserType = userType;
        }

        public void SetUserDomain(string username, string password, string email, DateTime birthDate, UserType userType = UserType.User)
        {
            Username = username;
            Password = password;
            Email = email;
            BirthDate = birthDate;
            UserType = userType;
        }
    }
}
