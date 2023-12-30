using Lab3.Entity;

namespace Lab3.DB.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private DbContext context;

        public AccountRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(AccountEntity account)
        {
            context.Accounts.Add(account);
        }
        public IEnumerable<AccountEntity> Read()
        {
            return context.Accounts;
        }

        public AccountEntity Update(string playerName)
        {
            var account = context.Accounts.FirstOrDefault(account => account.UserName == playerName);
            return account;
        }

        public void Delete(string UserName)
        {
            AccountEntity account = context.Accounts.FirstOrDefault(acc => acc.UserName == UserName);

            if (account != null)
                context.Accounts.Remove(account);
            else
                Console.WriteLine("Користувача не знайдено");
        }
    }
}