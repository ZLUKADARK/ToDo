namespace ToDo.Domain.DataTransferObject.Task
{
    public class UserTaskListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
