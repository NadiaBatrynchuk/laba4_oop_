using Lab2.Stats;
using Lab3.Entity;
using Lab3.DB.Repository;

namespace Lab3.DB.Service.Stats
{
    public class GameStatsService : IGameStatsService
    {
        private IGameStatsRepository gameStatsRepository;

        public GameStatsService(DbContext context)
        {
            gameStatsRepository = new GameStatsRepository(context);
        }
        public void CreateGame(GameStats gameStats)
        {
            GameStatsEntity gameStatsEntity = SetValues(gameStats);
            gameStatsRepository.Create(gameStatsEntity);
        }

        public List<GameStats> ReadGames()
        {
            return gameStatsRepository.Read().Select(game => Map(game)).ToList();
        }

        public List<GameStats> ReadGamesByPlayerName(string PlayerName)
        {
            var gameStatsEntities = gameStatsRepository
                                        .Read()
                                        .Where(game => game.WinnerName == PlayerName || game.LoserName == PlayerName)
                                        .ToList();

            return gameStatsEntities.Select(game => Map(game)).ToList();
        }

        public GameStats Map(GameStatsEntity stats)
        {
            GameStats gameStats = new GameStats(stats.GameRating, stats.WinnerName, stats.LoserName, stats.GameType, stats.GameID);
            return gameStats;
        }

        private GameStatsEntity SetValues(GameStats gameStats)
        {
            return new()
            {
                GameRating = gameStats.GameRating,
                WinnerName = gameStats.WinnerName,
                LoserName = gameStats.LoserName,
                GameType = gameStats.GameType,
                GameID = gameStats.GameID
            };
        }

    }
}