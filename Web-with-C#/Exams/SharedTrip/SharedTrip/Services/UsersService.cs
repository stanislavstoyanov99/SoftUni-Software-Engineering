namespace SharedTrip.Services
{
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;

    using SIS.MvcFramework;

    using Models;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext dbContext;

        public UsersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password),
                Role = IdentityRole.User
            };

            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var passwordHash = this.Hash(password);

            var userId = this.dbContext.Users
                .Where(x => x.Username == username && x.Password == passwordHash)
                .Select(x => x.Id)
                .FirstOrDefault();

            return userId;
        }

        public bool IsEmailUsed(string email)
        {
            return this.dbContext.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameUsed(string username)
        {
            return this.dbContext.Users.Any(x => x.Username == username);
        }

        private string Hash(string input)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));

            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
