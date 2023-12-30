using Lab2.Accounts;

namespace Lab3.DB.Service.Accounts
{
    public interface IAccountService
    {
        public void CreateAccount(GameAccount account);
        public void DeleteAccountByUserName(string UserName);
        public void UpdatePlayerName(string PrevName, string NewName);
        public List<GameAccount> ReadAccounts();
        public List<GameAccount> ReadAccountByUserName(string UserName);
    }
}