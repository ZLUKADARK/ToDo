using AutoMapper;
using ToDo.Domain.DataTransferObject.Task;
using ToDo.Domain.Entity;

namespace ToDo.BLL.Automapper
{
    public class UserTaskProfile : Profile
    {
        public UserTaskProfile() 
        {
            CreateMap<UserTaskDto, UserTask>().ReverseMap();
            CreateMap<UserTaskListDto, UserTask>().ReverseMap();
        }
    }
}
