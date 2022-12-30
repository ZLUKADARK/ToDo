using Microsoft.AspNetCore.Mvc;
using ToDo.BLL.Interfaces;
using ToDo.Domain.DataTransferObject.Task;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private IUserTaskServices _services;

        public UserTaskController(IUserTaskServices services) 
        {
            _services = services;
        }

        // GET: api/<UserTaskController>
        [HttpGet]
        public async Task<IEnumerable<UserTaskListDto>> Get()
        {
            return await _services.GetAll();
        }

        // GET api/<UserTaskController>/5
        [HttpGet("{id}")]
        public async Task<UserTaskDto> Get(int id)
        {
            return await _services.Get(id);
        }

        // POST api/<UserTaskController>
        [HttpPost]
        public async Task<int> Post([FromBody] UserTaskDto userTask)
        {
            return await _services.Create(userTask);
        }

        // PUT api/<UserTaskController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] UserTaskDto userTask)
        {
            if (id != userTask.Id)
                return false;

            return await _services.Update(userTask);
        }

        // DELETE api/<UserTaskController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _services.Delete(id);
        }
    }
}
