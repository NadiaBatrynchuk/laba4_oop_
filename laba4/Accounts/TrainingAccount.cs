namespace Lab2.Accounts;

// клас Тренувального акаунту, на якому не змінюється рейтинг за програш чи поразку
public class TrainingAccount : GameAccount
{
    public TrainingAccount(string UserName, int CurrentRating, int GamesCount) : base(UserName, CurrentRating, GamesCount)
    {
        Type = AccountType.Training;
    }

    // перевизначений метод перемоги в грі
    public override void WinGame(int GameRating)
    {

        this.GamesCount++;
    }

    // перевизначений метод програшу в грі
    public override void LoseGame(int GameRating)
    {

        this.GamesCount++;
    }
}