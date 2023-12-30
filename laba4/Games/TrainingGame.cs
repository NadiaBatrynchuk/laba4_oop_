using Lab2.Accounts;
using Lab2.Stats;
using Lab3.DB.Service.Stats;

namespace Lab2.Games
{
    // клас тренувальної гри, що наслідує базову гру. Рейтинг за цю гру рівний нулю, тому гравці не втрачають і не збільшують балів за поразку чи перемогу.
    public class TrainingGame : BasicGame
    {
        public TrainingGame()
        {
            Type = GameType.Training;
        }

        public override void GameFeature()
        {
            Console.WriteLine("Rating is equal to 0");
            Console.WriteLine("All players don't gain or lose rating");
        }

        // перевизначений метод симуляції гри
        public override void PlayGame(GameAccount Playa1, GameAccount Playa2, GameStatsService Service, int rating = 0)
        {
            if (rating != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Game rating must be equal to zero");
            }

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