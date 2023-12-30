using Lab2.Accounts;
using Lab3.Entity;
using Lab3.DB.Repository;

namespace Lab3.DB.Service.Accounts
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository;

        public AccountService(DbContext context)
        {
            accountRepository = new AccountRepository(context);
        }

        public void CreateAccount(GameAccount account)
        {
            AccountEntity player = new();
            player.UserName = account.UserName;
            player.Type = account.Type;
            player.CurrentRating = account.CurrentRating;
            player.GamesCount = account.GamesCount;
            accountRepository.Create(player);
        }

        public void DeleteAccountByUserName(string UserName)
        {
            accountRepository.Delete(UserName);
        }

        public List<GameAccount> ReadAccountByUserName(string UserName)
        {
            List<AccountEntity> accountsEntites = accountRepository
                                                    .Read()
                                                    .Where(account => account.UserName == UserName)
                                                    .ToList();
            return accountsEntites.Select(account => Map(account)).ToList();
        }

        public List<GameAccount> ReadAccounts()
        {
            return accountRepository.Read().Select(account => Map(account)).ToList();
        }

        public void UpdatePlayerName(string PlayerName, string NewName)
        {
            var account = accountRepository.Update(PlayerName);
            account.UserName = NewName;
        }

        private GameAccount Map(AccountEntity account)
        {
            AccountFactory factory = new();
            var Account = factory.CreateAccount(account.Type, account.UserName, account.CurrentRating, account.GamesCount);
            return Account;
        }
    }
}
