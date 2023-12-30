using Lab2.Accounts;
using Lab2.Stats;
using Lab3.DB.Service.Stats;

namespace Lab2.Games
{
    // клас стандартної гри, що наслідує базову гру. Звичайна гра, в якій гравці отримують чи втрачають рейтинг на який грають.
    public class StandardGame : BasicGame
    {
        public StandardGame()
        {
            Type = GameType.Standard;
        }

        public override void GameFeature()
        {
            Console.WriteLine("Rating must be positive");
            Console.WriteLine("All players gain or lose rating");
        }

        // перевизначений метод симуляції гри
        public override void PlayGame(GameAccount Playa1, GameAccount Playa2, GameStatsService Service, int rating)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Game rating mustn't be negative or equal to zero");
            }

            this.GameRating = rating;

            string result = this.RandomResult(Playa1.UserName, Playa2.UserName);
            if (result == Playa1.UserName)
            {
                Playa1.WinGame(rating);
                Playa2.LoseGame(rating);
                GameStats gameStats = new(rating, Playa1.UserName, Playa2.UserName, this.Type.ToString(), GameID);
                Service.CreateGame(gameStats);
                GameID++;
            }
            else
            {
                Playa2.WinGame(rating);
                Playa1.LoseGame(rating);
                GameStats gameStats = new(rating, Playa2.UserName, Playa1.UserName, this.Type.ToString(), GameID);
                Service.CreateGame(gameStats);
                GameID++;
            }
        }
    }
}
