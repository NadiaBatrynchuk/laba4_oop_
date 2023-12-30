using Lab2.Accounts;
using Lab3.Entity;

namespace Lab3.DB
{
    public class DbContext
    {
        public List<AccountEntity> Accounts { get; set; }
        public List<GameStatsEntity> Games { get; set; }

        public DbContext()
        {
            Accounts = new()
            {
                new AccountEntity { UserName = "Petro", CurrentRating = 100, Type = AccountType.Standard, GamesCount = 0},
                new AccountEntity { UserName = "Roman", CurrentRating = 150, Type = AccountType.Standard, GamesCount = 0 }
            };
            Games = new();
        }
    }
}