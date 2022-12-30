using ToDo.DAL.Data;
using ToDo.DAL.Interfaces;
using ToDo.DAL.Migrations;

namespace ToDo.DAL.Repositories
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly AppDbContext _db;

        public UserTaskRepository(AppDbContext db) 
        {
            _db = db;
        }

        public bool Create(UserTask item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserTask Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTask> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(UserTask item)
        {
            throw new NotImplementedException();
        }
    }
}
