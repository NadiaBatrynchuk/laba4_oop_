using Lab3.DB.Service.Accounts;
using Lab3.Printer;

namespace Lab4.Command
{
    public class ShowPlayersCommad : ICommand
    {
        AccountService accService;
        public ShowPlayersCommad(AccountService accService)
        {
            this.accService = accService;
        }
        public void Execute()
        {
            var accounts = accService.ReadAccounts();
            Console.Clear();
            Printer.ShowAllPlayers(accounts);
            Console.Write("\nTo return to the lobby, enter any character or press \"Enter\": ");
            Console.ReadLine();
            Console.Clear();
        }

        public string GetCommandInfo()
        {
            return "View players";
        }


    }
}
