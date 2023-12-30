
namespace Lab4.Command
{
    public class ConsoleManager
    {
        public List<ICommand> Commands { get; } = new();
        public void Add(ICommand command)
        {
            Commands.Add(command);
        }

        public void Start()
        {
            while (true)
            {
                Console.Write(ShowLobby());
                var input = Console.ReadLine();
                if (int.TryParse(input, out int res) && res == Commands.Count + 1)
                {
                    break;
                }
                else if (int.TryParse(input, out int result) && result <= Commands.Count)
                {
                    Commands[result - 1].Execute();
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }

        private string ShowLobby()
        {
            string result = "Main menu\n";

            for (int i = 0; i < Commands.Count; i++)
            {
                result += $"{i + 1} - {Commands[i].GetCommandInfo()}\n";
            }
            result += $"{Commands.Count + 1} - Exit game\n" +
                      "Choose an action: ";
            return result;
        }
    }
}
