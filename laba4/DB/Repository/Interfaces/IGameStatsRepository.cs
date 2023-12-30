using Lab3.Entity;

namespace Lab3.DB.Repository
{
    public interface IGameStatsRepository
    {
        public void Create(GameStatsEntity game);
        public IEnumerable<GameStatsEntity> Read();
        public void Update(GameStatsEntity game);
        public void Delete(int ID);
    }
}