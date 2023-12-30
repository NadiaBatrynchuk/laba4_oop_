using Lab3.DB.Service.Accounts;
using Lab2.Accounts;

namespace Lab4.Command
{
    internal class AddPLayerCommand : ICommand

    {
        AccountService accService;
        public AddPLayerCommand(AccountService accService)
        {
            this.accService = accService;
        }
        public void Execute()
        {
            var username = TakeName();
            var rating = TakeRating();
            var accType = TakeAccType();
            accService.CreateAccount(new AccountFactory().CreateAccount(accType, username, rating, 0));
            NextActions();
        }

        private void NextActions()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nAccount added!\nWhat will we do next?\n");
                Console.Write(
                    "1 - Add another account\n" +
                    "2 - Back to lobby\n" +
                    "Chioce an actions: "
                    );
                var answer = Console.ReadLine();

                if (answer == "1") { Execute(); Clear("", 200); break; }
                else if (answer == "2") { Clear("", 200); break; }
                else Clear("Invalid chioce, try again", 200);
            }


        }

        private string TakeName()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("\nInput UserName: ");
                var username = Console.ReadLine();
                if (username != null && username != "") { Console.Clear(); return username; }
                else
                {
                    Clear("You entered an empty line", 2000);
                }
            }
        }

        private int TakeRating()
        {
            while (true)
            {
                Console.Write("\nInput starting rating for player: ");
                var userInput = Console.ReadLine();
                try
                {
                    if (userInput != null)
                    {
                        int result = int.Parse(userInput);
                        if (result > 0) { Console.Clear(); return result; }
                    }
                }
                catch (FormatException)
                {
                    Clear("Invalid input type, try again!", 2000);
                }
                catch (OverflowException)
                {
                    Clear("The number is too large or too small!", 2000);
                }
            }
        }

        private AccountType TakeAccType()
        {
            while (true)
            {
                Console.Write(
                    "\nAll account type:\n" +
                    "\t1 - Standard Account\n" +
                    "\t2 - Training Account\n" +
                    "\t3 - Premium Account\n" +
                    "Choose a account type: ");
                var choice = Console.ReadLine();
                if (choice == "1") return AccountType.Standard;

                else if (choice == "2") return AccountType.Training;

                else if (choice == "3") return AccountType.Premium;

                else Clear("Invalid choice, try again", 2000);
            }
        }

        private void Clear(string text, int time)
        {
            Console.Write(text);
            Thread.Sleep(time);
            Console.Clear();
        }

        public string GetCommandInfo()
        {
            return "Add new account";
        }
    }
}
