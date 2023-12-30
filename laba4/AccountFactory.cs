namespace Lab2.Accounts;

public class AccountFactory
{
    public GameAccount CreateAccount(AccountType type, string UserName, int BaseRating, int GamesCount)
    {
        if (type == AccountType.Standard)
        {
            return new GameAccount(UserName, BaseRating, GamesCount);
        }
        else if (type == AccountType.Training)
        {
            return new TrainingAccount(UserName, BaseRating, GamesCount);
        }
        else if (type == AccountType.Premium)
        {
            return new PremiumAccount(UserName, BaseRating, GamesCount);
        }
        else
        {
            throw new ArgumentException("Непідтримуваний тип акаунту");
        }
    }
}