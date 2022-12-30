using ToDo.Domain.Entity;

namespace ToDo.DAL.Interfaces
{
    public interface IUserTaskRepository : IRepository<UserTask>
    {
        //public Task<IEnumerable<UserTask>> GetAll(int userId); Это должно быть в случае появление пользователей
        public Task<IEnumerable<UserTask>> GetAll(); //Это имитация
        public Task<bool> DeleteCompleted();
    }
}
