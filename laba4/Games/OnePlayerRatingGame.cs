using Lab2.Accounts;
using Lab2.Stats;
using Lab3.DB.Service.Stats;

namespace Lab2.Games
{
    // клас гри, в якій рейтинг може змінитися лише в одного гравця.
    public class OnePlayerRatingGame : BasicGame
    {
        public OnePlayerRatingGame()
        {
            Type = GameType.OnePlayerRating;
        }

        public override void GameFeature()
        {
            Console.WriteLine("Rating must be positive");
            Console.WriteLine("Only one player gain or lose rating");
        }

        // перевизначений метод симуляції гри
        public override void PlayGame(GameAccount RatingPlaya, GameAccount NonRatingPlaya, GameStatsService Service, int rating)
        {
            if (rating <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Game rating mustn't be negative or equal to zero");
            }

            this.GameRating = rating;
            string result = this.RandomResult(RatingPlaya.UserName, NonRatingPlaya.UserName);
            if (result == RatingPlaya.UserName)
            {
                NonRatingPlaya.LoseGame(0);
                RatingPlaya.WinGame(rating);
                GameStats gameStats = new(rating, RatingPlaya.UserName, NonRatingPlaya.UserName, this.Type.ToString(), GameID);
                Service.CreateGame(gameStats);
                GameID++;
            }
            else
            {
                NonRatingPlaya.WinGame(0);
                RatingPlaya.LoseGame(rating);
                GameStats gameStats = new(rating, NonRatingPlaya.UserName, RatingPlaya.UserName, this.Type.ToString(), GameID);
                Service.CreateGame(gameStats);
                GameID++;
            }
        }
    }
}