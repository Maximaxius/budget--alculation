using MyIWallet.Enums;

namespace MyIWallet.Models
{
    public class Wallet
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public TransactionType Type { get; set; }       


        public string? Description { get; set; }

        public decimal Amount { get; set; }            

        public DateTime CreationTime { get; set; }
    }

}
