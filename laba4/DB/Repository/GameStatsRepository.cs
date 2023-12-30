using Lab3.Entity;

namespace Lab3.DB.Repository
{
    public class GameStatsRepository : IGameStatsRepository
    {
        private DbContext context;

        public GameStatsRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(GameStatsEntity game)
        {
            context.Games.Add(game);
        }

        public IEnumerable<GameStatsEntity> Read()
        {
            return context.Games;
        }

        public void Update(GameStatsEntity game)
        {
            throw new NotImplementedException(); // ???
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException(); // ???
        }
    }
}
