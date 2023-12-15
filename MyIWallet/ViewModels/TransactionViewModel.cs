using MyIWallet.Enums;

namespace MyIWallet.ViewModels
{
    public class TransactionViewModel
    {
        public TransactionType Type { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreationTime { get; set; }

        public int Id { get; set; }

    }
}
