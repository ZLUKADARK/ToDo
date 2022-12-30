namespace ToDo.DAL.Interfaces
{
    public interface IRepository<Entity> where Entity : class
    {
        public bool Create(Entity item);
        public Entity Get(int id);
        public bool Update(Entity item);
        public bool Delete(int id);
    }
}
