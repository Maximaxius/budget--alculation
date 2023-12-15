using MyIWallet.Models;

namespace MyIWallet.ViewModels
{
    public class BalanceViewModel
    {
        public string Email { get; set; }

        public decimal Amount { get; set; }
        public IEnumerable<TransactionViewModel> Transactions { get; set; }

    }
}
