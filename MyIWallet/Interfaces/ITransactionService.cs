using MyIWallet.Models;

namespace MyIWallet.Interfaces
{
    public interface ITransactionService
    {
        public decimal CalculateBalance(IEnumerable<Wallet> transactions);
    }
}
