using MyIWallet.Enums;
using MyIWallet.Interfaces;
using MyIWallet.Models;

namespace MyIWallet.Services
{
    public class TransactionService : ITransactionService
    {
        public decimal CalculateBalance(IEnumerable<Wallet> wallets)
        {
            var amounts = new List<decimal>();
            foreach (var wallet in wallets)
            {
               var amount = wallet.Amount;
                if (wallet.Type == TransactionType.Expense)
                {
                   amount *= -1;
                }

                amounts.Add(amount);
            }
            return amounts.Sum();
        }
    }
}
