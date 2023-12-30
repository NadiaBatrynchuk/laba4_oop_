namespace Lab2.Accounts;

// клас Преміум акаунту, на якому знімається вдвічі менше та нараховується в 1.5 разів більше балів.
public class PremiumAccount : GameAccount
{
    public PremiumAccount(string UserName, int CurrentRating, int GamesCount) : base(UserName, CurrentRating, GamesCount)
    {
        Type = AccountType.Premium;
    }

    // перевизначений метод перемоги в грі
    public override void WinGame(int GameRating)
    {
        this.CurrentRating += GameRating * 3 / 2;
        this.GamesCount++;
    }

    // перевизначений метод програшу в грі
    public override void LoseGame(int GameRating)
    {
        this.CurrentRating -= GameRating / 2;
        this.GamesCount++;
    }
}