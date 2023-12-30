namespace Lab2.Accounts;

public class GameAccount
{
    public string UserName { get; set; }
    public int BaseRating { get; set; }

    public AccountType Type = AccountType.Standard;

    private int currentRating;
    public int CurrentRating
    {
        get
        {
            return currentRating;
        }
        set
        {
            currentRating = value < 1? 1 : value;
        }
    }

    public int GamesCount { get; set; }

    public GameAccount(string UserName, int BaseRating, int GamesCount)
    {
        this.UserName = UserName;
        this.BaseRating = Math.Max(1, BaseRating);
        this.CurrentRating = BaseRating;
        this.GamesCount = GamesCount;
    }

    public virtual void WinGame(int GameRating)
    {
        this.CurrentRating += GameRating;
        this.GamesCount++;
    }

    public virtual void LoseGame(int GameRating)
    {
        this.CurrentRating -= GameRating;
        this.GamesCount++;
    }
}

public enum AccountType
{
    Standard,
    Training,
    Premium
}