using ToDo.Domain.DataTransferObject.Task;

namespace ToDo.BLL.Interfaces
{
    public interface IUserTaskServices
    {
        public Task<int> Create(UserTaskDto task);
        public Task<IEnumerable<UserTaskListDto>> GetAll();
        public Task<UserTaskDto> Get(int id);
        public Task<bool> Update(UserTaskDto task);
        public Task<bool> Delete(int id);
    }
}
