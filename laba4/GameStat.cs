namespace Lab2.Stats;

public class GameStats
{
    public readonly int GameRating;
    public readonly string WinnerName;
    public readonly string LoserName;
    public readonly string GameResult;
    public readonly string GameType;
    public readonly int GameID;

    public GameStats(int GameRating, string WinnerName, string LoserName, string GameType, int GameID)
    {
        this.GameRating = GameRating;
        this.WinnerName = WinnerName;
        this.LoserName = LoserName;
        this.GameType = GameType;
        this.GameID = GameID;
    }

}