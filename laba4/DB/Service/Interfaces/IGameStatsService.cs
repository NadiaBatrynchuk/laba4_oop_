using Lab2.Stats;

namespace Lab3.DB.Service.Stats
{
    public interface IGameStatsService
    {
        public void CreateGame(GameStats gameStats);
        public List<GameStats> ReadGames();
        public List<GameStats> ReadGamesByPlayerName(string PlayerName);
    }
}