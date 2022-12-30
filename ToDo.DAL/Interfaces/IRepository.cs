namespace ToDo.DAL.Interfaces
{
    public interface IRepository<Entity> where Entity : class
    {
        public Task<int> Create(Entity item);
        public Task<Entity> Get(int id);
        public Task<bool> Update(Entity item);
        public Task<bool> Delete(int id);
    }
}
