using Lab2.Accounts;

namespace Lab3.Entity
{
    public class AccountEntity
    {
        public string UserName { get; set; }
        public AccountType Type { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
    }

    public class GameStatsEntity
    {
        public int GameRating;
        public string WinnerName;
        public string LoserName;
        public string GameResult;
        public string GameType;
        public int GameID;
    }
}
