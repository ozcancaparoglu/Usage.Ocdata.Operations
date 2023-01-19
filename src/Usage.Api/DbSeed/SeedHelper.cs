using Usage.Domain.Persistence;
using Usage.Domain.UserAggregate;

namespace Usage.Api.DbSeed
{
    public static class SeedHelper
    {
        public static void AddUserData(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<AppDbContext>();

            if (db.Users.FirstOrDefault(x => x.Username == "test") == null)
            {
                var user = new UserDomain("test", "test", "test@test.com", new DateTime(1990, 11, 05))
                {
                    CreatedDate = DateTime.Now
                };

                db.Add(user);
            }

            db.SaveChanges();
        }
    }
}
