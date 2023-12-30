using Lab3.Entity;

namespace Lab3.DB.Repository
{
    public interface IAccountRepository
    {
        public void Create(AccountEntity account);
        public IEnumerable<AccountEntity> Read();
        public AccountEntity Update(string PlayerName);
        public void Delete(string UserName);
    }
}