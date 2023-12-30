using Lab3.DB.Service.Accounts;
using Lab3.DB.Service.Stats;
using Lab3.Printer;

namespace Lab4.Command
{
    public class ShowPlayerStatsByNameCommand : ICommand
    {
        GameStatsService statsService;
        AccountService accService;

        public ShowPlayerStatsByNameCommand(GameStatsService statsService, AccountService accService)
        {
            this.statsService = statsService;
            this.accService = accService;
        }

        public void Execute()
        {
            while (true)
            {
                Console.Clear();
                ShowPlayers();
                Console.Write("\nPlease input user name: ");
                var username = Console.ReadLine();
                var player_stats = statsService.ReadGamesByPlayerName(username);
                Console.Clear();
                if (player_stats.Any())
                {
                    Console.WriteLine($"All game for {username}");
                    Printer.ShowAllGames(player_stats);
                    NextActions();
                    break;
                }
                else
                {
                    Console.WriteLine("No such user exists.");
                    NextActions();
                    break;
                }
            }
        }

        public string GetCommandInfo()
        {
            return "View player statistics by name";
        }

        private void NextActions()
        {
            while (true)
            {
                Console.WriteLine("What will we do next?");
                Console.Write(
                    "1 - Try again\n" +
                    "2 - Back to lobby\n" +
                    "Choose an action: "
                );

                var answer = Console.ReadLine();

                if (answer == "1") { Clear("", 50); Execute(); break; }
                else if (answer == "2") { Clear("", 50); break; }
                else { Clear("Invalid chioce, try again", 2000); }
            }
        }

        private void ShowPlayers()
        {
            var players = accService.ReadAccounts();
            string players_name = string.Join("  --  ", players
                                        .Select(player => player.UserName));

            Console.WriteLine("\n///  All players  \\\\\\");
            Console.WriteLine(players_name);
        }

        private void Clear(string text, int time)
        {
            Console.Write(text);
            Thread.Sleep(time);
            Console.Clear();
        }
    }
}
