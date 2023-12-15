using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyIWallet.Contexts;
using MyIWallet.Interfaces;
using MyIWallet.Models;
using MyIWallet.ViewModels;

namespace MyIWallet.Controllers
{
    [Authorize]
    public class WalletController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;
        private readonly ITransactionService _transactionService;

        public WalletController(
            ApplicationContext applicationContext,
            UserManager<User> userManager,
            ITransactionService transactionService)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
            _transactionService = transactionService;
        }


        [HttpGet]
        public async Task<IActionResult> Balance()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var wallets = await _applicationContext.Wallets
                .Where(wallet => wallet.UserId == user.Id)
                .ToListAsync();
            var userWallets = wallets
                .OrderByDescending(transaction => transaction.CreationTime)
                .ToList();

            var amount = decimal.Zero;
            if (userWallets.Any())
            {
                amount = _transactionService.CalculateBalance(userWallets);
            }

            var list = new List<TransactionViewModel>();
            foreach (var userWallet in userWallets)
            {
                var transactionViewModel = new TransactionViewModel
                {
                    CreationTime = userWallet.CreationTime,
                    Type = userWallet.Type,
                    Amount = userWallet.Amount,
                    Description = userWallet.Description,
                    Id = userWallet.Id,
                };
                list.Add(transactionViewModel);
            }

            var model = new BalanceViewModel
            {
                Email = user.Email,
                Amount = amount,
                Transactions = list,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Transaction()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Transaction(TransactionViewModel model)       //IActionResult вмсето Task<IActionResult>
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                var log = new Wallet
                {
                    UserId = user.Id,
                    Type = model.Type,
                    Description = model.Description,
                    Amount = model.Amount,
                    CreationTime = DateTime.Now,
                };

                await _applicationContext.Wallets.AddAsync(log);
                await _applicationContext.SaveChangesAsync();

                return Redirect("Balance");
            }

            return View(model);

        }
    }
}
