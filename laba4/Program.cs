using Lab3.DB;
using Lab3.DB.Service.Accounts;
using Lab3.DB.Service.Stats;
using Lab4.Command;

class Program
{
    static void Main()
    {
        DbContext context = new();
        GameStatsService gameStatsService = new(context);
        AccountService accountService = new(context);
        ConsoleManager manager = new();
        manager.Add(new AddPLayerCommand(accountService));
        manager.Add(new PlayGameCommand(accountService, gameStatsService));
        manager.Add(new ShowPlayersCommad(accountService));
        manager.Add(new ShowAllStatsCommand(gameStatsService));
        manager.Add(new ShowPlayerStatsByNameCommand(gameStatsService, accountService));
        manager.Start();
    }
}
    