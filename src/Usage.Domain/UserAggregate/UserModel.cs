using Ocdata.Operations.Authentication;

namespace Usage.Domain.UserAggregate
{
    public class UserModel : LoginModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public UserType UserType { get; set; }
    }
}
