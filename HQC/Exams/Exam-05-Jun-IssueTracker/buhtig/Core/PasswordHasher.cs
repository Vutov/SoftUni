namespace IssueTracker.Core
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            var hashedPassword = SHA1.Create()
                .ComputeHash(Encoding.Default.GetBytes(password))
                .Select(x => x.ToString());

            return string.Join(string.Empty, hashedPassword);
        }
    }
}