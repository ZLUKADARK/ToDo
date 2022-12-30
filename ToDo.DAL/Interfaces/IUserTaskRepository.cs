using ToDo.DAL.Migrations;

namespace ToDo.DAL.Interfaces
{
    public interface IUserTaskRepository : IRepository<UserTask>
    {
        //public IEnumerable<UserTask> GetAll(int userId); Это должно быть в случае появление пользователей
        public IEnumerable<UserTask> GetAll(); //Это имитация
    }
}
