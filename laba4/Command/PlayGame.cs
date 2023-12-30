using Lab2.Accounts;
using Lab2.Games;
using Lab3.DB.Service.Accounts;
using Lab3.DB.Service.Stats;

namespace Lab4.Command
{
    public class PlayGameCommand : ICommand
    {
        AccountService accService;
        GameStatsService statsService;
        public PlayGameCommand(AccountService accService, GameStatsService statsService)
        {
            this.accService = accService;
            this.statsService = statsService;
        }
        public void Execute()
        {
            GameFactory factory = new();
            var type = GetGameType();
            var game = factory.CreateGame(type);
            var players = GetPlayers();
            var player1 = players[0];
            var player2 = players[1];
            game.PlayGame(player1, player2, statsService, 0);
            NextActions(player1.UserName, player2.UserName);
        }

        public string GetCommandInfo()
        {
            return "Play game";
        }

        private GameType GetGameType()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(
                    "\nGame types:\n" +
                    "\t1 - Clasic\n" +
                    "\t2 - Training\n" +
                    "\t3 - Crazy\n" +
                    "Select the type of game: "
                );
                var answer = Console.ReadLine();

                if (answer == "1") return GameType.Standard;
                else if (answer == "2") return GameType.Training;
                else if (answer == "3") return GameType.OnePlayerRating;
                else Clear("Unknown command, try again!", 2000);
            }
        }

        private List<GameAccount> GetPlayers()
        {
            var players = accService.ReadAccounts();
            List<GameAccount> two_players = new();

            string players_name = string.Join("  --  ", players
                                        .Select(player => player.UserName));

            while (true)
            {
                var username = ChoiceUser(1, players_name);
                var user = players.FirstOrDefault(player => player.UserName == username);

                if (user != null)
                {
                    two_players.Add(user);
                    Clear("", 50);
                    break;
                }
                else Clear("User doesn't exist, try again", 2000);
            }
            while (true)
            {
                var username = ChoiceUser(2, players_name);
                var player = players.FirstOrDefault(plr => plr.UserName == username);

                if (player != null && two_players[0].UserName != player.UserName)
                {
                    two_players.Add(player);
                    Clear("", 50);
                    break;
                }
                else Clear("User doesn't exist or you choice this user, try again", 2000);
            }

            return two_players;
        }

        private void NextActions(string plrName1, string plrName2)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What will we do next?");
                Console.Write(
                    "\t1 - Play another game\n" +
                    "\t2 - Back to lobby\n" +
                    "Chioce an actions: "
                    );
                var answer = Console.ReadLine();

                if (answer == "1") { Execute(); Clear("", 50); break; }
                else if (answer == "2") { Clear("", 50); break; }
                else Clear("Invalid chioce, try again", 2000);
            }
        }

        private string ChoiceUser(int number, string players_name)
        {
            Clear("", 50);
            Console.WriteLine("\n///  All players  \\\\\\");
            Console.WriteLine(players_name);
            Console.Write($"Choice player №{number} by his name: ");
            var username = Console.ReadLine();
            return username;
        }

        private void Clear(string text, int time)
        {
            Console.Write(text);
            Thread.Sleep(time);
            Console.Clear();
        }

    }
}
