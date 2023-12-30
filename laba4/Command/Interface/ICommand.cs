
namespace Lab4.Command
{
    public interface ICommand
    {
        void Execute();
        string GetCommandInfo();
    }
}