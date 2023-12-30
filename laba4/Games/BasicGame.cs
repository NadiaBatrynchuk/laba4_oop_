using Lab2.Accounts;
using Lab3.DB.Service.Stats;

namespace Lab2.Games
{

    public abstract class BasicGame
    {
        public abstract void GameFeature();

        public int GameRating = 0;
        public GameType Type { get; protected init; }

        protected static int GameID = 1;

        public string RandomResult(string Player1, string Player2)
        {
            Random random = new Random();
            int result = random.Next(0, 100);
            if (result % 2 == 0) return Player2;
            return Player1;
        }

        public abstract void PlayGame(GameAccount Winna, GameAccount Loosa, GameStatsService Service, int rating = 0);
    }

    public enum GameType
    {
        Standard,
        Training,
        OnePlayerRating
    }

}