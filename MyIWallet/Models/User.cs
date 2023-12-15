using Microsoft.AspNetCore.Identity;

namespace MyIWallet.Models
{
    public class User : IdentityUser
    {
        public List<Wallet> Transactions { get; set; }
    }
}
