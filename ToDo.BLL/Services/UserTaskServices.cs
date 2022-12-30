using AutoMapper;
using System.Net.Http.Headers;
using ToDo.BLL.Interfaces;
using ToDo.DAL.Interfaces;
using ToDo.Domain.DataTransferObject.Task;
using ToDo.Domain.Entity;

namespace ToDo.BLL.Services
{
    public class UserTaskServices : IUserTaskServices
    {
        private readonly IUserTaskRepository _repository;
        private readonly IMapper _mapper;

        public UserTaskServices(IUserTaskRepository repository, IMapper mapper) 
        { 
            _repository = repository;
            _mapper = mapper; 
        }

        public async Task<int> Create(UserTaskDto task)
        {
            
            var newTask = _mapper.Map<UserTask>(task);
            
            if (task.Completed)
                newTask.CompletedDate = DateTime.Now;

            return await _repository.Create(newTask);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<UserTaskDto> Get(int id)
        {
            return _mapper.Map<UserTaskDto>(await _repository.Get(id));
        }

        public async Task<IEnumerable<UserTaskListDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserTaskListDto>>(await _repository.GetAll());
        }

        public async Task<bool> Update(UserTaskDto task)
        {
            var updateTask = _mapper.Map<UserTask>(task);
            
            if (task.Completed)
                updateTask.CompletedDate = DateTime.Now;

            return await _repository.Update(updateTask);
        }
    }
}
