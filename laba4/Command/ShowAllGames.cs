using Lab3.DB.Service.Stats;
using Lab3.Printer;

namespace Lab4.Command
{
    public class ShowAllStatsCommand : ICommand
    {
        GameStatsService statsService;
        public ShowAllStatsCommand(GameStatsService statsService)
        {
            this.statsService = statsService;
        }

        public void Execute()
        {
            while (true)
            {
                Console.Clear();
                var players_stats = statsService.ReadGames();
                Console.Clear();
                if (players_stats.Any())
                {
                    Console.WriteLine("All game stats");
                    Printer.ShowAllGames(players_stats);
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
            return "View all statistics";
        }

        private void NextActions()
        {
            Console.Write("\nTo return to the lobby, enter any character or press \"Enter\": ");
            Console.ReadLine();
            Console.Clear();
        }
       
    }
}
