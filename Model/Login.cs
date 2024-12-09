using System.Security.Cryptography;
using System.Text;
using PokemonLikeCsharp.Model;

namespace PokemonLikeCsharp.Model
{
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public virtual ICollection<Player> Players { get; set; } = new List<Player>();

        public bool VerifyPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedPassword = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
                return hashedPassword == PasswordHash;
            }
        }

        public void SetPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                PasswordHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
