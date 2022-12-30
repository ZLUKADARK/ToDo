using Microsoft.EntityFrameworkCore;
using System.Data;
using ToDo.DAL.Data;
using ToDo.DAL.Interfaces;
using ToDo.Domain.Entity;

namespace ToDo.DAL.Repositories
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly AppDbContext _db;

        public UserTaskRepository(AppDbContext db) 
        {
            _db = db;
        }

        public async Task<int> Create(UserTask item)
        {
            try
            {
                await _db.UserTask.AddAsync(item);
                await _db.SaveChangesAsync();
                return item.Id;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var task = await _db.UserTask.FindAsync(id);
                if (task != null)
                {
                    _db.UserTask.Remove(task);
                    await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UserTask> Get(int id)
        {
            return await _db.UserTask.FindAsync(id);
        }

        public async Task<IEnumerable<UserTask>> GetAll()
        {
            return await _db.UserTask.ToListAsync();
        }

        public async Task<bool> Update(UserTask item)
        {
            var result = _db.Entry<UserTask>(item);
            result.State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteCompleted()
        {
            var delete = await _db.UserTask.Where(x => x.Completed 
                        && x.CompletedDate != DateTime.MinValue 
                        && x.CompletedDate <= DateTime.Now.AddDays(-30)).ToListAsync();
            try
            {
                _db.UserTask.RemoveRange(delete);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
