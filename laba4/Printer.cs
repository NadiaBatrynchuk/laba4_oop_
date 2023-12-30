using Lab2.Accounts;
using Lab2.Stats;

namespace Lab3.Printer
{
    class Printer
    {
        public static void ShowAllPlayers(List<GameAccount> players)
        {
            // Console.WriteLine("--- All Players ---");
            foreach (var player in players)
            {
                Console.WriteLine($"Name: {player.UserName}");
                Console.WriteLine($"Type: {player.Type}");
                Console.WriteLine($"Rating: {player.CurrentRating}");
                Console.WriteLine($"Games Count: {player.GamesCount}");
                Console.WriteLine("-------------------");
            }
        }

        public static void ShowAllGames(List<GameStats> games)
        {
            // Console.WriteLine("---  All Games  ---");
            foreach (var game in games)
            {
                Console.WriteLine($"Winner: {game.WinnerName}");
                Console.WriteLine($"Loser: {game.LoserName}");
                Console.WriteLine($"Game Type: {game.GameType}");
                Console.WriteLine($"Game Rating: {game.GameRating}");
                Console.WriteLine($"Game ID: {game.GameID}");
                Console.WriteLine("-------------------");
            }
        }

        /*public static void ShowOnePlayerGames(string UserName, List<GameStats> Games )
        {
            Console.WriteLine("--- One Player Games ---");
            foreach (var game in Games)
            {
                if (game.WinnerName == UserName || game.LoserName == UserName)
                {
                    Console.WriteLine($"Winner: {game.WinnerName}");
                    Console.WriteLine($"Loser: {game.LoserName}");
                    Console.WriteLine($"Game Type: {game.GameType}");
                    Console.WriteLine($"Game Rating: {game.GameRating}");
                    Console.WriteLine($"Game ID: {game.GameID}");
                    Console.WriteLine("------------------------");
                }
            }
        }*/
    }
}
