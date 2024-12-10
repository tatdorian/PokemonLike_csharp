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
    }
}